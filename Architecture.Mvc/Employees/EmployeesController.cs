using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Architecture.Core.Dtos;
using Architecture.Core.Services;
using Architecture.Web.Models;

namespace Architecture.Web.Employees
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<ActionResult> List()
        {
            var employees = (await _employeeService.GetAllAsync()).ToEmployeeDtos();
            ViewData["Employees"] = employees;
            ViewBag.EmployeeDropdownData = employees.Select(e => new SelectListItem {Text = e.Name, Value = e.Id.ToString()}).ToList();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("List");
            }

            await _employeeService.CreateAsync(model.ToEmployee());
            return RedirectToAction("List");
        }
    }
}