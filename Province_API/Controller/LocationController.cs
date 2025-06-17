using Microsoft.AspNetCore.Mvc;
using Province_API.Application.Interfaces.Services;

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

        [HttpGet("provinces")]
        public IActionResult getProvinces() => Ok(_service.GetAdministrativeUnit(null));

        [HttpGet("district/{provinceID}")]
        public IActionResult getDistricts(string provinceID) => Ok(_service.GetAdministrativeUnit(provinceID));

        [HttpGet("ward/{districtID}")]
        public IActionResult getWards(string districtID) => Ok(_service.GetAdministrativeUnit(districtID));
    }
}
