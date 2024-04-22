using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Controllers
{
    //https://localhost:port number/api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //GET : https://localhost:port number/api/Regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Region",
                    Code = "AKL",
                    RegionImageUrl = "https://a.cdn-hotels.com/gdcs/production133/d294/4e4195aa-b9ca-42cd-923f-e8a65c8c5c7b.jpg?impolicy=fcrop&w=800&h=533&q=medium",
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://wellingtonnz.bynder.com/transform/social/f2224523-265d-4578-a72a-b9b068d987ce/",
                },
            };
            return Ok(regions);
        }
    }
}
