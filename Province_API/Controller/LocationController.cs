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
        public async Task<IActionResult> GetProvincesAsync([FromServices] IAdministrativeUnitUsecase _adminUnitUC)
        {
            var result = await _adminUnitUC.GetAllProvincesAsync();
            return Ok(result);
        }

        [HttpGet("unit/{parentID}")]
        public async Task<IActionResult> GetChildrenByIdAsync(string parentID, [FromServices] IAdministrativeUnitUsecase _adminUnitUC)
        {
            var result = await _adminUnitUC.GetChildrenByIDAsync(parentID);
            return Ok(result);
        }

        [HttpGet("unit/id/{id}")]
        public async Task<IActionResult> GetAdministrativeUnitNameAsync(string id, [FromServices] IAdministrativeUnitUsecase _adminUnitUC)
        {
            try
            {
                var result = await _adminUnitUC.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("unit/add")]
        public async Task<IActionResult> AddNewLocationAsync([FromBody] LocationRequest req, [FromServices] IAdministrativeUnitUsecase _adminUnitUC) {
            try
            {
                var result = await _adminUnitUC.AddNewLocationAsync(req.Name, req.Type, req.ParentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("unit/delete/{id}")]
        public async Task<IActionResult> DeleteLocationAsync(string id, [FromServices] IAdministrativeUnitUsecase _adminUnitUC) {
            try
            {
                var result = await _adminUnitUC.DeleteLocationAsync(id);
                return Ok($"Deleted {result.Name}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("unit/update/{id}")]
        public async Task<IActionResult> UpdateLocationAsync(string id, [FromBody] LocationRequest locationRequest, [FromServices] IAdministrativeUnitUsecase _adminUnitUC)
        {
            try
            {
                var result = await _adminUnitUC.UpdateLocationAsync(id, locationRequest.Name, locationRequest.Type, locationRequest.ParentId);
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

