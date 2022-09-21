using EmployeeAPI.Data;

namespace EmployeeAPI.Repository
{
    public class WorkLocationRepository<T> : BaseRepository<T> where T : class
    {
        public WorkLocationRepository(EmployeeAPIDbContext employeesAPIDbContext) : base(employeesAPIDbContext)
        {
        }

    }
}
