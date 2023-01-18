using EmployeeCrud.Services.Iservices;
using EmployeeCrud.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet("GetEmployee/{id}")]
        public IActionResult getEmployee(int id)
        {
            var response = employeeService.GetEmployee(id);
            return Ok(response);
        }
        [HttpGet("GeAllEmployee")]
        public IActionResult GeAllEmployee()
        {
            var response = employeeService.GetAllEmployees();
            return Ok(response);
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeVM employeeVM)
        {
            var response = employeeService.PostEmployee(employeeVM);
            return Ok(response);
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeVM employeeVM)
        {
            var response = employeeService.UpdateEmployee(employeeVM);
            return Ok(response);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var response = employeeService.DeleteEmployee(id);
            return Ok(response);
        }



    }
}
