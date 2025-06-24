using Microsoft.AspNetCore.Mvc;
using Province_API.Core.Application.Interfaces.Services;
using Province_API.Usecase.AdministrativeUnit;

namespace Province_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;
        private readonly AdministrativeUnitUseCase _adminUnitUC;
        public LocationController(ILocationService service, AdministrativeUnitUseCase uc)
        {
            _service = service;
            _adminUnitUC = uc;
        }

        [HttpGet("unit")]
        public IActionResult getProvinces() => Ok(_adminUnitUC.GetAllUnit());

        [HttpGet("unit/{parentID}")]
        public IActionResult getProvinces(string parentID) => Ok(_adminUnitUC.GetChildrenByID(parentID));

        [HttpGet("unit/id/{id}")]
        public IActionResult getAdministrativeUnitName(string id)
        {
            try
            {
                return Ok(_adminUnitUC.GetById(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
