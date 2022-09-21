using EmployeeAPI.Data;

namespace EmployeeAPI.Repository
{
    public class DepartmentRepository<T> : BaseRepository<T> where T : class
    {
        public DepartmentRepository(EmployeeAPIDbContext employeesAPIDbContext) : base(employeesAPIDbContext)
        {

        }
    }
}
