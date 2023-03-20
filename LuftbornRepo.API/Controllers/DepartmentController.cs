using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelinterface.Core.Interfaces;
using Modelinterface.Core.Models;
using Modelinterface.Core.Strings;
using System.Linq.Expressions;

namespace LuftbornRepo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IBaseRepository<Department> _departmentRepository;

        public DepartmentController(IBaseRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        //[HttpGet]
        //public IActionResult GetById()
        //{
        //    Department dept = _departmentRepository.GetById(2);
        //    return Ok(dept);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Department dept = await _departmentRepository.GetByIdAsync(id);
            return Ok(dept);
        }
        [HttpGet]
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }
        //[HttpGet("GetOrdered")]
        //public IActionResult GetOrdered(string str)
        //{
        //    return Ok(_departmentRepository.FindAllAsync(b => b.Name.Contains(str), b => b.id,OrderBy.Descending));
        //}
        [HttpPost]
        public  IActionResult AddOne(Department dpt)
        {
            return Ok( _departmentRepository.Add(dpt));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _departmentRepository.Delete(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Department dpt)
        {
            return Ok(await _departmentRepository.Put(id, dpt));
        }
    }
}
