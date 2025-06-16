using Microsoft.AspNetCore.Mvc;
using Province_API.Application.Interfaces;

namespace Province_API.APIController
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
        public IActionResult getProvinces() => Ok(_service.GetProvinces());

        [HttpGet("district/{provinceID}")]
        public IActionResult getDistricts(string provinceID) => Ok(_service.GetDistricts(provinceID));

        [HttpGet("ward/{districtID}")]
        public IActionResult getWards(string districtID) => Ok(_service.GetWards(districtID));
    }
}
