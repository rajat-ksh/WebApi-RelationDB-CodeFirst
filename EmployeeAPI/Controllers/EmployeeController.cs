using EmployeeAPI.Data;
using EmployeeAPI.Models.DataViewModel;
using EmployeeAPI.Models.RequestModel;
using EmployeeAPI.Repository;
using EmployeeAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository<Employee> _employeeRepository;
        private readonly EmployeePersonalRepository<EmployeePersonalDetails> _employeePersonalRepository;
        private readonly EmployeeEducationRepository<EmployeeEducationDetails> _employeeEducationRepository;

        public EmployeeController(EmployeeAPIDbContext dbContext)
        {
            _employeeRepository = new EmployeeRepository<Employee>(dbContext);
            _employeePersonalRepository = new EmployeePersonalRepository<EmployeePersonalDetails>(dbContext);
            _employeeEducationRepository = new EmployeeEducationRepository<EmployeeEducationDetails>(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _employeeRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeAddRequestDto addEmployeeRequest)
        {
            var guid = Guid.NewGuid();
            Employee employee = PrepareEmployee(addEmployeeRequest, guid);
            EmployeePersonalDetails personalDetails = PreparePersonalDetails(addEmployeeRequest, guid);
            EmployeeEducationDetails educationDetails = PrepareEducationDetail(addEmployeeRequest, guid);

            await _employeeRepository.Add(employee);
            await _employeePersonalRepository.Add(personalDetails);
            await _employeeEducationRepository.Add(educationDetails);
            return Ok(employee);
        }

        //[HttpPut]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, EmployeeUpdateRequestDto updateEmployeeRequest)
        //{
        //    var employee = await dbContext.Employees.FindAsync(id);
        //    if (employee != null)
        //    {
        //        employee.FirstName = updateEmployeeRequest.FullName;
        //        employee.Email = updateEmployeeRequest.Email;

        //        await dbContext.SaveChangesAsync();
        //        return Ok(employee);
        //    }

        //    return NotFound();
        //}

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var isEmployeeDeleted = await _employeeRepository.Delete(id);
            return isEmployeeDeleted ? Ok() : NotFound();
        }

        static Employee PrepareEmployee(EmployeeAddRequestDto addEmployeeRequest, Guid guid)
        {
            return new Employee()
            {
                Id = guid,
                EmpId = addEmployeeRequest.EmpId,
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                Email = addEmployeeRequest.Email,
                ManagerId = addEmployeeRequest.ManagerId,
                DeptId = addEmployeeRequest.DepartmentId,
                LocationId=addEmployeeRequest.WorkLocationId
            };
        }

        static EmployeePersonalDetails PreparePersonalDetails(EmployeeAddRequestDto addEmployeeRequest, Guid guid)
        {
            return new EmployeePersonalDetails()
            {
                Id = guid,
                Address = addEmployeeRequest.Address,
                City = addEmployeeRequest.City,
                State = addEmployeeRequest.State
            };
        }

        static EmployeeEducationDetails PrepareEducationDetail(EmployeeAddRequestDto addEmployeeRequest, Guid guid)
        {
            return new EmployeeEducationDetails()
            {
                Id = guid,
                Qualification = addEmployeeRequest.Qualification,
                Marks = addEmployeeRequest.Marks,
                CollegeName = addEmployeeRequest.CollegeName
            };
        }

    }
}
