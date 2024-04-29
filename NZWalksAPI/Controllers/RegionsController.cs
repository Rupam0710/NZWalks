using AutoMapper;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repository;
using System.Collections.Generic;

namespace NZWalksAPI.Controllers
{
    //https://localhost:port number/api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContextcs dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContextcs dbContext , IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //GET ALL REGIONS
        //GET : https://localhost:port number/api/Regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            //Get data from database - domain models
            var regionsDomain = await regionRepository.GetAllAsync();

           

        

        //Return DTOs
        return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        //GET SINGLE REGION(GET REGION BY ID)
        //GET : https://localhost:port number/api/Regions/{ID}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
        //var regions = dbContext.Regions.Find(id);
        //Get data from database - domain models
        var regionDomain = await regionRepository.GetByIdAsync(id);
        if (regionDomain == null)
        {
            return NotFound();
        }

        

        //Return DTOs
        return Ok(mapper.Map<RegionDto>(regionDomain));
        }


        //POST To create a new Region
        //POST : https://localhost:port number/api/Regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto) {

            
                //Map or Convert DTOs to Domain Model

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                //Use Domain Model to create Region
                await regionRepository.CreateAsync(regionDomainModel);

                //Map Domain model back to DTO

                var regionDto = mapper.Map<RegionDto>(regionDomainModel);


                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
           
        }

        //PUT To Update a Region
        //PUT : https://localhost:port number/api/Regions/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            
                //Map RegionDTO To Region


                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                //Check if region exists or not
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                //Convert DomainModel to DTO


                //return DTO 
                return Ok(mapper.Map<RegionDto>(regionDomainModel));
          
        }

        //Delete Region
        //DELETE :  https://localhost:port number/api/Regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
        var regionDomainModel = await regionRepository.DeleteAsync(id);  
        if( regionDomainModel == null)
        {
            return NotFound();
        }



        //Return deleted Region Back
        //Map Domain to DTO

        

        return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
        }
        }

