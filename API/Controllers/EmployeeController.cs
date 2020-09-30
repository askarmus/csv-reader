using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Queries;
using Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController( IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("FetchEmployeeById/{id}")]
        public IActionResult FetchEmployeeById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var result = _employeeService.FetchEmployeeById(id);

                if (result != null)
                    return Ok(result);
            }

            return NotFound("Recors is not found ");
        }

        [HttpGet("SearchEmployee")]
        public IActionResult SearchEmployee([FromQuery] EmployeeSearchQuery query)
        {
            if ( string.IsNullOrEmpty(query.FirstName) && string.IsNullOrEmpty(query.Country) && string.IsNullOrEmpty(query.LastName))
            {
                var result = _employeeService.SearchEmployee(query);

                if (result.Count > 0)
                    return Ok(result);

                return NotFound("No recors found in search criteria");
            }

            return BadRequest("Please provide minimum one search tearm");
        }

    }
}
