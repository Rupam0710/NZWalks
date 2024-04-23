using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Controllers
{
    //https://localhost:port number/api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContextcs dbContext;
        public RegionsController(NZWalksDbContextcs dbContext)
        {
            this.dbContext = dbContext;
        }
        //GET ALL REGIONS
        //GET : https://localhost:port number/api/Regions
        [HttpGet]
        public IActionResult GetAll()
        {   
            //Get data from database - domain models
            var regionsDomain = dbContext.Regions.ToList();

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }

            //Return DTOs
            return Ok(regionsDto);
        }

        //GET SINGLE REGION(GET REGION BY ID)
        //GET : https://localhost:port number/api/Regions/{ID}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {
            //var regions = dbContext.Regions.Find(id);
            //Get data from database - domain models
            var regionDomain = dbContext.Regions.FirstOrDefault(x=>x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map Domain Models to DTOs
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            //Return DTOs
            return Ok(regionDto);
        }


        //POST To create a new Region
        //POST : https://localhost:port number/api/Regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto) {

            //Map or Convert DTOs to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

            //Use Domain Model to create Region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            //Map Domain model back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

    }
}
