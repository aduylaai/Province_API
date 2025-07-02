using Microsoft.AspNetCore.Mvc;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.AdministrativeUnit;

namespace Province_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        public LocationController()
        {
        }

        [HttpGet("unit")]
        public async Task<IActionResult> GetProvincesAsync([FromServices] ILocationService _get)
        {
            var result = await _get.GetAllProvincesAsync();
            return Ok(result);
        }

        [HttpGet("unit/{parentID}")]
        public async Task<IActionResult> GetChildrenByIdAsync(string parentID, [FromServices] ILocationService _get)
        {
            var result = await _get.GetChildernAdministrativeUnitsAsync(parentID);
            return Ok(result);
        }

        [HttpGet("unit/id/{id}")]
        public async Task<IActionResult> GetAdministrativeUnitNameAsync(string id, [FromServices] ILocationService _get)
        {
            try
            {
                var result = await _get.GetAdministrativeUnitAsync(id);
                if (result== null)
                {
                    return NotFound($"{id} not exist!");
                }
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("unit/add")]
        public async Task<IActionResult> AddNewLocationAsync([FromBody] LocationRequest req, [FromServices] ILocationService _create) {
            try
            {
                var result = await _create.AddNewLocationAsync(req.Name, req.Type, req.ParentId);
                return Ok($"{result.Name} created!");
            }
            catch (Exception ex)
            {
                return StatusCode(500,"Please try again later!");
            }
        }

        [HttpDelete("unit/delete/{id}")]
        public async Task<IActionResult> DeleteLocationAsync(string id, [FromServices] AdministrativeUnitDelete _delete) {
            try
            {
                var result = await _delete.DeleteLocationAsync(id);
                return Ok($"Deleted {result.Name}!");
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpDelete("unit/softdelete/{id}")]
        public async Task<IActionResult> SoftDeleteLocationAsync(string id, [FromServices] ILocationService _delete)
        {
            try
            {
                var result = await _delete.SoftDeleteByIdAsync(id);
                return Ok($"Deleted {result.Name}!");
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPut("unit/update/{id}")]
        public async Task<IActionResult> UpdateLocationAsync(string id, [FromBody] LocationRequest locationRequest, [FromServices] ILocationService _update)
        {
            try
            {
                var result = await _update.UpdateLocationAsync(id, locationRequest.Name, locationRequest.Type, locationRequest.ParentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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

