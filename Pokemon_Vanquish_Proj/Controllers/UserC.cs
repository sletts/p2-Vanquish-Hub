using DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace Pokemon_Vanquish_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserC : ControllerBase
    {
        private IUserRepoNew repo;
        private static List<User> users = new List<User>();
        public UserC(IUserRepoNew repo)
        {
            this.repo = repo;
        }
        
        /// <summary>
        /// Gets all the users from the database and returns them.
        /// </summary>
        /// <returns>A list of all Users in the Database</returns>
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
                Log.Information("Bad Request exception @ Get User in UserC.");
                return BadRequest(ex.Message);
            }
            Log.Information("Good request @ Get User in Userc.");
            return Ok(users);
        }
        
        /// <summary>
        /// Takes a username and returns the information of the first username with that username.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns user details if the user is found. Returns Bad request if not found.</returns>
        [HttpGet]
        [Route("Get User By Name")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<User> Get(string name)
        {
            var user = new User();
            try
            {
                user = repo.GetUserByName(name);
            }
            catch (Exception ex)
            {
                Log.Information("Bad Request exception @ Get User By Name in userC.");
                return BadRequest(ex.Message);
            }
            if(user == null)
            {
                Log.Information($"Username {name} not found @ Get User By Name in userC");
                return BadRequest($"Username {name} not found.");
            }
            Log.Information("Good Request @ Get User By Name in userC.");
            return Ok(user);
        }
        
        /// <summary>
        /// Adds a new User to the database when the needed  information is added (Username, Password, Phone Number and Email)
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <returns>201 if the user is created. 400 if there's an issue.</returns>
        [HttpPost]
        [Route("Add User")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddNewUser([FromQuery][BindRequired] string UserName, [FromQuery][BindRequired] string password,
            [FromQuery][BindRequired] string PhoneNumber, [FromQuery][BindRequired] string Email)
        {
            //check to make sure all data is entered
            if (String.IsNullOrEmpty(UserName))
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ empty username.");
                return BadRequest("Invalid Username. Please try again with valid values");
            }
            else if (String.IsNullOrEmpty(password))
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ empty password.");
                return BadRequest("Invalid Password. Please try again with valid values");
            }
            else if (String.IsNullOrEmpty(PhoneNumber))
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ empty phone number.");
                return BadRequest("Invalid Phone Number. Please try again with valid values");
            }
            else if (String.IsNullOrEmpty(Email))
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ empty email.");
                return BadRequest("Invalid Email. Please try again with valid values");
            }
            else if (UserName.ToLower() == "admin")
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ attempt at admin account making.");
                return BadRequest("Illegal attempt at making admin account");
            }
            //Check that there aren't duplications
            try
            {
                users = repo.GetAllUsers();
            }
            catch (Exception ex)
            {
                Log.Information("Bad Request exception in get all users @ AddNewUser in UserC.");
                return BadRequest(ex.Message);
            }
            var dupName = users.Where(p => p.Username == UserName).FirstOrDefault();
            var dupEmail = users.Where(p => p.Email == Email).FirstOrDefault();
            var dupNumber = users.Where(p => p.Phone == PhoneNumber).FirstOrDefault();
            if (dupName != null)
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ Duplicate Username used.");
                return BadRequest("Name Already in use");
            }
            else if (dupEmail != null)
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ Duplicate Email used.");
                return BadRequest("Email Already in use");
            }
            else if (dupNumber != null)
            {
                Log.Information("Bad Request exception @ AddNewUser in userC w/ Duplicate Phone Number used.");
                return BadRequest("Phone Number Already in use");
            }
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
                Log.Information("Excetion occured in @ AddNewUser in UserC: " + ex);
            }
            Log.Information("New user created w/ username: " + UserName + " @ AddNewUser in UserC");
            return CreatedAtAction("Get", newUser);
        }
        
        /// <summary>
        /// Taking a username and password, allow the person to change other User parts (username, password, number, email) if it's a real username and password.
        /// If not, return 204, resource not found
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="NewPhoneNumber"></param>
        /// <param name="NewEmail"></param>
        /// <param name="newUserName"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update User")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult Update([FromQuery][BindRequired] string UserName, [FromQuery][BindRequired] string password,
            [FromQuery] string NewPhoneNumber, [FromQuery] string NewEmail, [FromQuery] string newUserName, [FromQuery] string NewPassword)
        {
            //TODO
            return Ok();
        }
        /// <summary>
        /// Makes sure the person trying to login is a real person.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <returns>Returns Ok + the texts "login" if a real user attempts. Returns 400 otherwise.</returns>
        /// TODO-ish, make this use tokens instead of just checking the username and password
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Authenticate([FromQuery][BindRequired] string UserName, [FromQuery][BindRequired] string password)
        {
            try
            {
                users = repo.GetAllUsers();
            }
            catch (Exception ex)
            {
                Log.Information("Bad Request exception in GetAllUsers @ Authenticate in userC.");
                return BadRequest(ex.Message);
            }
            var test1 = users.Where(p => p.Username == UserName).ToList();
            if (test1.Count() == 0)
            {
                Log.Information("Username Not Found @ Authenticate in userC.");
                return BadRequest("Username Not Found");
            }
            var test2 = test1.Where(p => p.Password == password).ToList();
            if (test2.Count() == 0)
            {
                Log.Information("Password Not Found @ Authenticate in userC.");
                return BadRequest("Password incorrect");
            }
            Log.Information("Good request at Login User @ Authenticate in UserC.");
            return Ok("Login");
            //This is a butched way of doing it, but it works.
        }
    }
}
