using CitiInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CitiInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityInfo = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == id);
            
            if(cityInfo == null)
            {
                return NotFound();
            }

            return Ok(cityInfo);
        }
    }
}
