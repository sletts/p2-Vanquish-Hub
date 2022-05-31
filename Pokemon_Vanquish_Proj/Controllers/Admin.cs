using DL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace Pokemon_Vanquish_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin : ControllerBase
    {
        private IUserRepoNew repo;
        private IArtworkRepo Artrepo;
        private static List<User> users = new List<User>();
        private static List<Artwork> arts = new List<Artwork>();
        public Admin(IUserRepoNew repo, IArtworkRepo Artrepo)
        {
            this.repo = repo;
            this.Artrepo = Artrepo;
        }
        /// <summary>
        /// Gets all the users from the database and returns them.
        /// </summary>
        /// <returns>A list of all Users in the Database</returns>
        [HttpGet]
        [Route("Get All Users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<User>> Get()
        {
            try
            {
                users = repo.GetAllUsers();
            }
            catch (Exception ex)
            {
                Log.Information("Bad Request exception in get user @ Admin.");
                return BadRequest(ex.Message);
            }
            Log.Information("Good request at Get User @ Admin.");
            return Ok(users);
        }
        /// <summary>
        /// Takes in a user ID and deletes them from the DB
        /// Deletes associated art images as well
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns 200 if the user was deleted. 400 if not.</returns>
        [HttpDelete]
        [Route("Remove User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromQuery][BindRequired] int id)
        {
            //remove associated images first
            var deleteArt = new List<Artwork>();
            try
            {
                deleteArt = Artrepo.GetArtByUserID(id);
            }
            catch(Exception ex)
            {
                Log.Information("Bad Request exception in delete user @ Admin, deleting associated art subsection.");
                return BadRequest(ex.Message);
            }
            foreach(var art in deleteArt)
            {
                try
                {
                    //removes associated images
                    Artrepo.DeleteArt(art.Id);
                }
                catch (Exception ex)
                {
                    Log.Information($"Failed to delete art with an id of {art.Id} with user ID of {id}");
                    return BadRequest(ex.Message);
                }
            }
            //remove user
            try
            {
                repo.DeleteUser(id);
                users = repo.GetAllUsers();
            }
            catch (Exception ex)
            {
                Log.Information("Bad Request exception in delete user @ Admin.");
                return BadRequest(ex.Message);
            }
            Log.Information("Good request at delete User @ Admin.");
            return Ok();
        }

    }
}
