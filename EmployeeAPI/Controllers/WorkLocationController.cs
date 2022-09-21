using EmployeeAPI.Data;
using EmployeeAPI.Models.DataViewModel;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly WorkLocationRepository<Department> _workLocationRepository;
        public WorkLocationController(EmployeeAPIDbContext dbContext)
        {
            _workLocationRepository = new WorkLocationRepository<Department>(dbContext);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            return Ok(await _workLocationRepository.GetAll());
        }
    }
}
