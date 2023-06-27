using CitiInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CitiInfo.API.Controllers
{
    [Route("api/cities/{cityId}/[controller]")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var cityInfo = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (cityInfo == null)
            {
                return NotFound();
            }

            return Ok(cityInfo.PointsOfInterest);
        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var cityInfo = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (cityInfo == null)
            {
                return NotFound();
            }

            var pointOfInterest = cityInfo.PointsOfInterest
                .FirstOrDefault(p => p.Id == pointOfInterestId);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult CreatePointOfInterest(int cityId, PointOfInterestCreationDto pointOfInterest)
        {
            var cityInfo = CitiesDataStore.Current.Cities
               .FirstOrDefault(c => c.Id == cityId);

            if (cityInfo == null)
            {
                return NotFound();
            }

            // for demo
            var maxPointOfInterestId = CitiesDataStore.Current.Cities
                .SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterestDto = new PointOfInterestDto
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            cityInfo.PointsOfInterest.Add(finalPointOfInterestDto);

            return CreatedAtRoute("GetPointOfInterest",
                new { cityId = cityId, pointOfInterestId = finalPointOfInterestDto.Id },
                finalPointOfInterestDto);
        }

        [HttpPut("{pointOfInterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestUpdateDto pointOfInterest)
        {
            var cityInfo = CitiesDataStore.Current.Cities
              .FirstOrDefault(c => c.Id == cityId);

            if (cityInfo == null)
            {
                return NotFound();
            }

            // find point of interest
            var pointOfInterestFromStore = cityInfo.PointsOfInterest
                .FirstOrDefault(p => p.Id == pointOfInterestId);
            if(pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{pointOfInterestId}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, JsonPatchDocument<PointOfInterestUpdateDto> patchDocument)
        {
            var cityInfo = CitiesDataStore.Current.Cities
                         .FirstOrDefault(c => c.Id == cityId);

            if (cityInfo == null)
            {
                return NotFound();
            }

            // find point of interest
            var pointOfInterestFromStore = cityInfo.PointsOfInterest
                .FirstOrDefault(p => p.Id == pointOfInterestId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestUpdateDto()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description,
            };

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(pointOfInterestToPatch)){
                return BadRequest(ModelState);
            }

            return NoContent();
        }


    }
}
