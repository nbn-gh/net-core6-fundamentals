using AutoMapper;
using CitiInfo.API.Models;
using CitiInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CitiInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOnInterestDto>>> GetCities()
        {
            var citiEntities = await _cityInfoRepository.GetCitiesAsync();
            var results = _mapper.Map<IEnumerable<CityWithoutPointsOnInterestDto>>(citiEntities);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var citiEntity = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if(citiEntity == null) { return NotFound();  }
            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(citiEntity));
            }
            var result = _mapper.Map<CityWithoutPointsOnInterestDto>(citiEntity);

            return Ok(result);
        }
    }
}
