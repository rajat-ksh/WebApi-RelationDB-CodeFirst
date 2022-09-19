using EmployeeAPI.Data;

namespace EmployeeAPI.Repository
{
    public class EmployeeEducationRepository<T>:BaseRepository<T> where T: class
    {
        public EmployeeEducationRepository(EmployeeAPIDbContext employeesAPIDbContext) : base(employeesAPIDbContext)
        {

        }
    }
}
