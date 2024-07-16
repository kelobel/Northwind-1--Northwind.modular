using Microsoft.AspNetCore.Mvc;
using Northwind.Regions.Application.Contracts;
using Northwind.Regions.Application.Dtos;

namespace Northwind.Regions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService regionService;

        public RegionController(IRegionService regionService)
        {
            this.regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
        }

        [HttpGet("GetRegions")]
        public IActionResult Get()
        {
            var result = this.regionService.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetRegionById/{id}")]
        public IActionResult Get(int id)
        {
            var result = this.regionService.GetById(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost("SaveRegion")]
        public IActionResult Post(RegionDtoSave regionDtoSave)
        {
            if (regionDtoSave == null)
                return BadRequest("Region data is null");

            var result = this.regionService.Add(regionDtoSave);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateRegion")]
        public IActionResult Put(RegionDtoUpdate regionDtoUpdate)
        {
            if (regionDtoUpdate == null)
                return BadRequest("Region data is null");

            var result = this.regionService.Update(regionDtoUpdate);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveRegion")]
        public IActionResult Delete(RegionDtoRemove regionDtoRemove)
        {
            if (regionDtoRemove == null)
                return BadRequest("Region data is null");

            var result = this.regionService.Remove(regionDtoRemove);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
