using DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace Pokemon_Vanquish_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewUser : ControllerBase
    {
        private IUserRepoNew repo;
        private static List<User> users = new List<User>();
        public NewUser(IUserRepoNew repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Route("Get All Users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<User>> Get()
        {
            try
            {
                users = repo.GetAllUsers();
            }
            catch (Exception ex)
            {
                //Log.Information("Bad Request exception in get user.");
                return BadRequest(ex.Message);
            }
            //Log.Information("Good request at Get User.");
            return Ok(users);
        }

        [HttpPost]
        [Route("Add User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddNewUser([FromQuery][BindRequired] string UserName, [FromQuery][BindRequired] string password,
            [FromQuery][BindRequired] string PhoneNumber, [FromQuery][BindRequired] string Email)
        {
            //check to make sure all data is entered
            if (String.IsNullOrEmpty(UserName))
                return BadRequest("Invalid Username. Please try again with valid values");
            else if (String.IsNullOrEmpty(password))
                return BadRequest("Invalid Password. Please try again with valid values");
            else if (String.IsNullOrEmpty(PhoneNumber))
                return BadRequest("Invalid Phone Number. Please try again with valid values");
            else if (String.IsNullOrEmpty(Email))
                return BadRequest("Invalid Email. Please try again with valid values");
            else if (UserName.ToLower() == "admin")
                return BadRequest("Illegal attempt at making admin account");
            //Check that there aren't duplications
            try
            {
                users = repo.GetAllUsers();
            }
            catch (Exception ex)
            {
                //Log.Information("Bad Request exception in get user.");
                return BadRequest(ex.Message);
            }
            var dupName = users.Where(p => p.Username == UserName).FirstOrDefault();
            var dupEmail = users.Where(p => p.Email == Email).FirstOrDefault();
            var dupNumber = users.Where(p => p.Phone == PhoneNumber).FirstOrDefault();
            if (dupName != null)
                return BadRequest("Name Already in use");
            else if (dupEmail != null)
                return BadRequest("Email Already in use");
            else if (dupNumber != null)
                return BadRequest("Phone Number Already in use");
            //Make a new user
            User newUser = new User();
            newUser.Username = UserName;
            newUser.Password = password;
            newUser.Email = Email;
            newUser.Phone = PhoneNumber;
            newUser.IsAdmin = false;
            //Try to add a new user
            try
            {
                repo.AddUser(newUser);
            }
            catch (Exception ex)
            {
                //Log.Information("Excetion occured in AddNewUser: " + ex);
            }
            //Log.Information("New user created w/ username: " + user.UserName);
            return CreatedAtAction("Get", newUser);
        }

        /*
         * TODO ADD AUTHENTICATE
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Authenticate([FromQuery] UserInfo user)
        {
            var token = JWTrepo.Authenticate(user);
            if (token == null)
            {
                Log.Information("Unauthorized user attempted access.");
                return Unauthorized("You do not have proper autherization to see this.");
            }
            Log.Information("Authorized user given token.");
            return Ok(token);
        }*/
    }
}
