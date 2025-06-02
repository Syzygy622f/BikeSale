using EntityRepository;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net;

namespace BikeSale.Controllers
{
    [ApiController]
    [Route("Bikes")]
    public class BikeController : Controller
    {
        //bruger ikke en dto til bike, da bike har alt relevant data og har ikke noget anden forbindelse der er relevant for nu.
        IBikeRepository _Repo;

        public BikeController(IBikeRepository repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Bike> bikes = await _Repo.GetBikesAsync();

            if (bikes == null)
            {
                return NotFound("Couldn't get list, try again later :(");
            }
            return Ok(bikes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Bike bike = await _Repo.GetBikeAsync(id);

            if (bike == null)
            {
                return NotFound("Couldn't find the bike, try again later :(");
            }

            return Ok(bike);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Bike bike)
        {
            bool success = false;

            if (bike != null)
            {
                try
                {
                    success = await _Repo.createBikeAsync(bike);
                }
                catch (Exception)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "internal error, please try again later");
                }
                if (success)
                {
                    return Ok();
                }
            }
            return BadRequest("didn't give the relevant values needed to create the item");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Bike bike)
        {
            bool success = false;
            if (bike != null)
            {
                try
                {
                    success = await _Repo.UpdateBikeAsync(bike);
                }
                catch (Exception)
                {
                    return NotFound("an error come, please try again later");
                }
                if (success)
                {
                    return Ok();
                }
            }
            return BadRequest("didn't give the relevant values needed to update the item");
        }
    }
}
