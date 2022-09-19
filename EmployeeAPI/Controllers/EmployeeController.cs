using EmployeeAPI.Data;
using EmployeeAPI.Models.AuthenticationModel;
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
        private readonly EmployeeRepository<EmployeePersonalDetails> _employeePersonalRepository;
        private readonly EmployeeEducationRepository<EmployeeEducationDetails> _employeeEducationRepository;

        private readonly IJWTManagerRepository _jWTManager;


        public EmployeeController(EmployeeAPIDbContext dbContext, IJWTManagerRepository jWTManager)
        {
            _employeeRepository = new EmployeeRepository<Employee>(dbContext);
            _employeePersonalRepository = new EmployeeRepository<EmployeePersonalDetails>(dbContext);
            _employeeEducationRepository = new EmployeeEducationRepository<EmployeeEducationDetails>(dbContext);
            _jWTManager = jWTManager;
        }

        [Authorize]
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

            //await _employeeRepository.Add(employee);
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

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
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
                WorkLocation = new WorkLocation()
                {
                    Id = addEmployeeRequest.WorkLocationId
                },
                Department = new Department()
                {
                    Id = addEmployeeRequest.DepartmentId
                }

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
