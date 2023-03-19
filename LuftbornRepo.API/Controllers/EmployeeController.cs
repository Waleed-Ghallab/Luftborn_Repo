using DAL.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelinterface.Core.Interfaces;
using Modelinterface.Core.Models;

namespace LuftbornRepo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseRepository<Employee> _employeeRepository;

        public EmployeeController(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //[HttpGet]
        //public IActionResult GetById()
        //{
        //    Employee emp= _employeeRepository.GetById(2);
        //    return Ok(emp);
        //}
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync()
        {
            Employee emp = await _employeeRepository.GetByIdAsync(2);
            return Ok(emp);
        }

        [HttpGet("GetALL")]
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        [HttpGet("GetOrdered")]
        public async Task<IEnumerable<Employee>> GetOrdered()
        {
            return await _employeeRepository.FindAllAsync(b => b.name.Contains("dutch"), b => b.id);
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            return Ok(_employeeRepository.Add(new Employee { name = "john mariston", age=26, deptID=7,
                address="city of valentine", dateofbirth="23/8/2088", depto=7, email="john@mariston",
             phone="21659976656"}));
        }
    }
}
