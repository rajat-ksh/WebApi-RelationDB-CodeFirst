using EmployeeAPI.Data;

namespace EmployeeAPI.Repository
{
    public class EmployeePersonalRepository<T> : BaseRepository<T> where T : class
    {
        public EmployeePersonalRepository(EmployeeAPIDbContext employeesAPIDbContext) : base(employeesAPIDbContext)
        {
        }

    }
}
