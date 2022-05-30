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
                return BadRequest("This name is already in use for your artwork.");

            //Try to add a new artwork
            try
            {
                repo.AddArt(art);
            }
            catch (Exception ex)
            {
                //Log.Information("Excetion occured in AddNewUser: " + ex);
            }
            //Log.Information("New user created w/ username: " + user.UserName);
            return CreatedAtAction("Get", art);
        }

    }
}
