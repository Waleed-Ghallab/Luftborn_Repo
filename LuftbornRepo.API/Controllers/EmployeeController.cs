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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Employee emp = await _employeeRepository.GetByIdAsync(id);
            return Ok(emp);
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        //[HttpGet("GetOrdered")]
        //public async Task<IEnumerable<Employee>> GetOrdered(string str)
        //{
        //    return await _employeeRepository.FindAllAsync(b => b.name.Contains(str), b => b.id);
        //}

        [HttpPost]
        public IActionResult AddOne(Employee emp)
        {
            emp.depto = emp.deptID;
            return Ok(_employeeRepository.Add(emp));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _employeeRepository.Delete(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee emp)
        {
            if (id != emp.id)
            {
                return BadRequest();
            }
            emp.depto = emp.deptID;
            return Ok(await _employeeRepository.Put(id, emp));
        }
    }
}
