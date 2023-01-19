using EmployeeCrud.Data;
using EmployeeCrud.Domain.Models;
using EmployeeCrud.Services.Iservices;
using EmployeeCrud.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService employeeService;
        public EmployeeDBContext _context;
        public EmployeeController(IEmployeeService employeeService, EmployeeDBContext context)
        {
            this.employeeService = employeeService;
            _context = context;
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
