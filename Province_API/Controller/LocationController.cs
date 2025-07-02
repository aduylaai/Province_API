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
        public async Task<IActionResult> GetProvincesAsync([FromServices] AdministrativeUnitGet _get)
        {
            var result = await _get.GetAllProvincesAsync();
            return Ok(result);
        }

        [HttpGet("unit/{parentID}")]
        public async Task<IActionResult> GetChildrenByIdAsync(string parentID, [FromServices] AdministrativeUnitGet _get)
        {
            var result = await _get.GetChildrenByIDAsync(parentID);
            return Ok(result);
        }

        [HttpGet("unit/id/{id}")]
        public async Task<IActionResult> GetAdministrativeUnitNameAsync(string id, [FromServices] AdministrativeUnitGet _get)
        {
            try
            {
                var result = await _get.GetByIdAsync(id);
                if (result.Id== null)
                {
                    return NotFound("Unit not exist!");
                }
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("unit/add")]
        public async Task<IActionResult> AddNewLocationAsync([FromBody] LocationRequest req, [FromServices] AdministrativeUnitCreate _create) {
            try
            {
                var result = await _create.AddNewLocationAsync(req.Name, req.Type, req.ParentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("unit/softdelete/{id}")]
        public async Task<IActionResult> SoftDeleteLocationAsync(string id, [FromServices] AdministrativeUnitDelete _delete)
        {
            try
            {
                var result = await _delete.SoftDeleteLocationAsync(id);
                return Ok($"Deleted {result.Name}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("unit/update/{id}")]
        public async Task<IActionResult> UpdateLocationAsync(string id, [FromBody] LocationRequest locationRequest, [FromServices] AdministrativeUnitUpdate _update)
        {
            try
            {
                var result = await _update.UpdateLocationAsync(id, locationRequest.Name, locationRequest.Type, locationRequest.ParentId);
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

