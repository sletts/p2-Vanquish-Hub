using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Models;
using DL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pokemon_Vanquish_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserAPI : ControllerBase
    {


        // GET: api/<UserAPI>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserAPI>
        [HttpPost]
        public void Post( string name, string email, string password, string phone)
        {

            UserRepo userRepo = new UserRepo();

            User user = new User();
            user.Name = name;
            user.Email = email;
            user.Password = password;
            user.Phone = phone; 

            userRepo.AddUser(user, "Server = tcp:steveburgos22308.database.windows.net, 1433; Initial Catalog = PokePictionary; Persist Security Info = False; User ID = steveburgos; Password = Vanquish@; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }

        // PUT api/<UserAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
