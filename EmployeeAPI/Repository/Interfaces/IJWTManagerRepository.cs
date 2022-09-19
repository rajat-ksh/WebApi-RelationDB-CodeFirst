using EmployeeAPI.Models.AuthenticationModel;

namespace EmployeeAPI.Repository.Interfaces
{
    public interface IJWTManagerRepository
    {
        Token Authenticate(User users);
    }
}
