using AutoMapper;
using CitiInfo.API.Models;
using CitiInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CitiInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper )
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
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            var citiEntity = await _cityInfoRepository.GetCityAsync(id, false);
            if(citiEntity == null) { return NotFound();  }
            
            var result = _mapper.Map<CityDto>(citiEntity);

            return Ok(result);
        }
    }
}
