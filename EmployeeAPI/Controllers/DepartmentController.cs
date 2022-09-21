using EmployeeAPI.Data;
using EmployeeAPI.Models.DataViewModel;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository<Department> _departmentRepository;
        public DepartmentController(EmployeeAPIDbContext dbContext)
        {
            _departmentRepository = new DepartmentRepository<Department>(dbContext);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            return Ok(await _departmentRepository.GetAll());
        }

    }
}
