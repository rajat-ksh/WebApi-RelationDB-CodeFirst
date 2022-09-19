using EmployeeAPI.Data;
using EmployeeAPI.Models.DataViewModel;
using EmployeeAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository<T> : BaseRepository<T> where T: class
    {
        public EmployeeRepository(EmployeeAPIDbContext employeesAPIDbContext): base(employeesAPIDbContext)
        {
        }
        
    }
}
