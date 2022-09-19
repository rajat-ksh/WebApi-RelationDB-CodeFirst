using EmployeeAPI.Models.DataViewModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeAPIDbContext: DbContext
    {
        public EmployeeAPIDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorkLocation> WorkLocation { get; set; }
        public DbSet<EmployeeEducationDetails> EmployeeEducation { get; set; }
        public DbSet<EmployeePersonalDetails> EmployeePersonal { get; set; }


    }
}
