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
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync()
        {
            Department dept = await _departmentRepository.GetByIdAsync(2);
            return Ok(dept);
        }
        [HttpGet("GetALL")]
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }
        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_departmentRepository.FindAllAsync(b => b.Name.Contains("HR"), b => b.id,OrderBy.Descending));
        }
        [HttpPost("AddOne")]
        public  IActionResult AddOne()
        {
            return Ok( _departmentRepository.Add(new Department { Name = "PR"}));
        }
    }
}
