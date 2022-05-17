
namespace TeamManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee employee)
        {
            _employeeService = employee;
        }

        [HttpGet("search/{criteriaValue}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Employee>>>> SearchEmployee(string criteriaValue)
        {
            var response = await _employeeService.SearchEmployeeAsync(criteriaValue);

            if (response.Success) {
                return Ok(response);
            }
            else {
                return NotFound(response);
            }
        }

        [HttpGet("SearchByEmail/{email}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Employee>>>> GetEmployeeByEmail(string email)
        {
            var response = await _employeeService.GetEmployeeByEmailAsync(email);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpGet("SearchByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Employee>>>> GetEmployeeByName(string name)
        {
            var response = await _employeeService.GetEmployeeByNameAsync(name);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpPost("Employee")]
        public async Task<ActionResult<ServiceResponse<Employee>>> AddEmployee(Employee employee)
        {
            var response = await _employeeService.AddEmployeeAsync(employee);
            return Ok(response);
        }

    }
}
