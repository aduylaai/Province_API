using Microsoft.AspNetCore.Mvc;
using Province_API.Usecase.AdministrativeUnit;

namespace Province_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly AdministrativeUnitGet _adminUnitGet;
        private readonly AdministrativeUnitCreate _adminUnitCreate;
        private readonly AdministrativeUnitDelete _adminUnitDelete;
        public LocationController(AdministrativeUnitGet get,AdministrativeUnitCreate create, AdministrativeUnitDelete delete)
        {
            _adminUnitGet = get;
            _adminUnitCreate = create;  
            _adminUnitDelete = delete;
        }

        [HttpGet("unit")]
        public IActionResult getProvinces() => Ok(_adminUnitGet.GetAllUnit());

        [HttpGet("unit/{parentID}")]
        public IActionResult getProvinces(string parentID) => Ok(_adminUnitGet.GetChildrenByID(parentID));

        [HttpGet("unit/id/{id}")]
        public IActionResult getAdministrativeUnitName(string id)
        {
            try
            {
                return Ok(_adminUnitGet.GetById(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("unit/add")]
        public async Task<IActionResult> AddNewLocation([FromBody] AddNewLocationRequest req) {
            try
            {
                var result = await _adminUnitCreate.AddNewLocation(req.Name, req.Type, req.ParentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("unit/delete")]
        public async Task<IActionResult> DeleteLocation([FromBody] string id) {
            try
            {
                var result = await _adminUnitDelete.DeleteLocation(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class AddNewLocationRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string? ParentId { get; set; }
    }
}

