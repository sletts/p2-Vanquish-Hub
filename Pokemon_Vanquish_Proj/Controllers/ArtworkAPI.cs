using DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pokemon_Vanquish_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworkAPI : ControllerBase
    {
        private IArtworkRepo repo;
        private static List<Artwork> arts = new List<Artwork>();
        public ArtworkAPI(IArtworkRepo repo)
        {
            this.repo = repo;
        }
        
        /// <summary>
        /// Gets all the art works from the database and returns them.
        /// </summary>
        /// <returns>A list of all artworks in the Database w/ 200, or 400 if it doesn't work.</returns>
        [HttpGet]
        [Route("Get All Artworks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<User>> Get()
        {
            try
            {
                arts = repo.GetAllArtworks();
            }
            catch (Exception ex)
            {
                //Log.Information("Bad Request exception in get user.");
                return BadRequest(ex.Message);
            }
            //Log.Information("Good request at Get User.");
            return Ok(arts);
        }
        
        /// <summary>
        /// Adds a new art work to the datase.
        /// </summary>
        /// <param name="art"></param>
        /// <returns>200 if a new artwork is added. 400 if there is an issue doing so.</returns>
        [HttpPost]
        [Route("Add Artwork")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddNewArtwork([FromQuery][BindRequired] Artwork art)
        {
            try
            {
                arts = repo.GetAllArtworks();
            }
            catch (Exception ex)
            {
                //Log.Information("Bad Request exception in get user.");
                return BadRequest(ex.Message);
            }

            if (arts.Where(a => a.ArtWorkName == art.ArtWorkName).ToList().Count() > 0)
            {
                return BadRequest("This name is already in use for your artwork.");
            }

            //Try to add a new artwork
            try
            {
                repo.AddArt(art);
            }
            catch (Exception ex)
            {
                //Log.Information("Excetion occured in AddNewUser: " + ex);
                return BadRequest("The artwork couldn't be added. Error: " + ex);
            }
            //Log.Information("New user created w/ username: " + user.UserName);
            return CreatedAtAction("Get", art);
        }

        /// <summary>
        /// Deletes an art piece by based the associated ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete Art Piece")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Delete(int id)
        {
            try
            {
                repo.DeleteArt(id);
            }
            catch(Exception ex)
            {
                return BadRequest($"Couldn't delete artwork with an id of: {id}. Exception: {ex}");
            }
            return Ok();
        }

        /// <summary>
        /// Gets all art by whatever User ID is taken in
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns>A list of all art with the same UserID if its Ok. Returns 400 if it doesn't work.</returns>
        [HttpGet]
        [Route("Get Art by UserID")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<Artwork>> GetArtByUserID(int UserID)
        {
            try
            {
                arts = repo.GetAllArtworks();
            }
            catch (Exception ex)
            {
                return BadRequest($"Couldn't Get Art by UserID with a UserID of {UserID}");
            }
            return Ok(arts);
        }

        /// <summary>
        /// Takes in a user ID. Finds all art associated with said ID and delets it.
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete Art by UserID")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult DeleteByUserID(int UserID)
        {
            var deleteList = new List<Artwork>();
            try
            {
                deleteList = repo.GetArtByUserID(UserID);
            }
            catch(Exception ex)
            {
                return BadRequest($"Couldn't Delete Art by UserID with a UserID of {UserID}");
            }
            foreach (Artwork art in deleteList)
            {
                try
                {
                    repo.DeleteArt(art.Id);
                }
                catch
                {
                    return BadRequest($"Couldn't Delete Art with an ID of {art.Id}");
                }
            }
            return Ok();
        }
    }
}
