using AutoMapper;
using CitiInfo.API.Models;
using CitiInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CitiInfo.API.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/cities")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    //[Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get all Cities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOnInterestDto>>> GetCities()
        {
            var citiEntities = await _cityInfoRepository.GetCitiesAsync();
            var results = _mapper.Map<IEnumerable<CityWithoutPointsOnInterestDto>>(citiEntities);
            return Ok(results);
        }

        /// <summary>
        /// Get City by an Id
        /// </summary>
        /// <param name="id">The id of the city to get</param>
        /// <param name="includePointsOfInterest">Whether or not to include the points of interest</param>
        /// <returns>AN IActionResult</returns>
        /// <response code="200">Returns the requested city</response>
        /// <response code="400"></response>
        /// <response code="404">Return when the city is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var citiEntity = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (citiEntity == null) { return NotFound(); }
            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(citiEntity));
            }
            var result = _mapper.Map<CityWithoutPointsOnInterestDto>(citiEntity);

            return Ok(result);
        }
    }
}
