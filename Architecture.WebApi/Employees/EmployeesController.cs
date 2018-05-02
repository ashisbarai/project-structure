using System.Threading.Tasks;
using System.Web.Http;
using Architecture.Core.Dtos;
using Architecture.Core.Services;

namespace Architecture.WebApi.Employees
{
    [RoutePrefix("api/employee")]
    public class EmployeesController : ApiController
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees.ToEmployeeDtos());
        }
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody] EmployeeDto employee)
        {
            await _employeeService.CreateAsync(employee.ToEmployee());
            return Ok();
        }
    }
}