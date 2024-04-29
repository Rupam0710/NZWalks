using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repository;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //Create Walk
        //POST : /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddWalkRequestDto addWalkRequestDto)
        {   

            if(ModelState.IsValid)
            {
                //MAP DTO to Domain Model
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                //Use Domain Model to create Walk
                await walkRepository.CreateAsync(walkDomainModel);

                //Map Domain model back to DTO

                var walkDto = mapper.Map<WalkDto>(walkDomainModel);

                return Ok(walkDto);
            }
            
                return BadRequest(ModelState);
            
            


           // return CreatedAtAction(nameof(GetById), new { id = walkDto.Id }, walkDto);
        }

        //Get walks
        //GET : /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from database - domain models
            var walkDomain = await walkRepository.GetAllAsync();

            //Return DTOs
            return Ok(mapper.Map<List<WalkDto>>(walkDomain));
        }

        //Get walks by id
        //GET : /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var walkDomain = await walkRepository.GetByIdAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }



            //Return DTOs
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

        //Update Walk by id
        //PUT : /api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id,[FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {   
            if (ModelState.IsValid)
            {
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

                //Check if walk exists or not
                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
                if (walkDomainModel == null)
                {
                    return NotFound();
                }

                //Convert DomainModel to DTO


                //return DTO 
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
            
            
                return BadRequest(ModelState);
            
            

        }

        //Delete Region
        //DELETE :  https://localhost:port number/api/Regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }



            //Return deleted Region Back
            //Map Domain to DTO



            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }

}
