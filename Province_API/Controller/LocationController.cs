using Microsoft.AspNetCore.Mvc;
using Province_API.Core.Application.Interfaces.Services;

namespace Province_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;

        public LocationController(ILocationService service)
        {
            _service = service;
        }

        [HttpGet("unit")]
        public IActionResult getProvinces() => Ok(_service.GetProvinces());

        [HttpGet("unit/{parentID}")]
        public IActionResult getProvinces(string parentID) => Ok(_service.GetAdministrativeUnits(parentID));

        [HttpGet("unit/id/{id}")]
        public IActionResult getAdministrativeUnitName(string id)
        {
            try
            {
                return Ok(_service.GetAdministrativeUnitName(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
