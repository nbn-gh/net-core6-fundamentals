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

        public CitiesController(ICityInfoRepository cityInfoRepository )
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOnInterestDto>>> GetCities()
        {
            var citiEntities = await _cityInfoRepository.GetCitiesAsync();
            var results = new List<CityWithoutPointsOnInterestDto>();
            foreach (var citiEntity in citiEntities)
            {
                results.Add(new CityWithoutPointsOnInterestDto
                {
                    Id = citiEntity.Id,
                    Description = citiEntity.Description,
                    Name = citiEntity.Name
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            var citiEntity = await _cityInfoRepository.GetCityAsync(id, false);
            if(citiEntity == null) { return NotFound();  }

            var result = new CityWithoutPointsOnInterestDto()
            {
                Id = citiEntity.Id,
                Description = citiEntity.Description,
                Name = citiEntity.Name
            };

            return Ok(result);
        }
    }
}
