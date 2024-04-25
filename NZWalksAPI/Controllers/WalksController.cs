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
        public async Task<IActionResult> CreateAsync([FromBody]AddWalkRequestDto addWalkRequestDto)
        {
            //MAP DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            //Use Domain Model to create Walk
            await walkRepository.CreateAsync(walkDomainModel);

            //Map Domain model back to DTO

            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);


           // return CreatedAtAction(nameof(GetById), new { id = walkDto.Id }, walkDto);
        }
    }
}
