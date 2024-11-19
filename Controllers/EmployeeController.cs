using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _service;
        public EmployeeController(IEmployeeServices service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _service.GetEmployees();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var employee = _service.GetById(id);
            return Ok(employee);


        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                throw new ValidationException(errors);
            }

            var newEmployeeId = _service.AddEmployee(employee);
            return Ok(newEmployeeId);
        }

    }
}
