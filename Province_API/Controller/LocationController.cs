using Microsoft.AspNetCore.Mvc;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.AdministrativeUnit;

namespace Province_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IAdministrativeUnitService _services;
        public LocationController(IAdministrativeUnitService services)
        {
            _services = services;
        }

        [HttpGet("unit")]
        public async Task<IActionResult> getProvinces()
        {
            var result = await _services.GetAllUnitAsync();
            return Ok(result);
        }

        [HttpGet("unit/{parentID}")]
        public async Task<IActionResult> getProvinces(string parentID)
        {
            var result = await _services.GetChildrenByIDAsync(parentID);
            return Ok(result);
        }

        [HttpGet("unit/id/{id}")]
        public async Task<IActionResult> getAdministrativeUnitName(string id)
        {
            try
            {
                var result = await _services.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("unit/add")]
        public async Task<IActionResult> AddNewLocation([FromBody] LocationRequest req) {
            try
            {
                var result = await _services.AddNewLocationAsync(req.Name, req.Type, req.ParentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("unit/delete")]
        public async Task<IActionResult> DeleteLocation([FromBody] string id) {
            try
            {
                var result = await _services.DeleteLocationAsync(id);
                return Ok($"Deleted {result.Name}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(string id, [FromBody] LocationRequest locationRequest)
        {
            try
            {
                var result = await _services.UpdateLocationAsync(id, locationRequest.Name, locationRequest.Type, locationRequest.ParentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class LocationRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string? ParentId { get; set; }
    }
}

