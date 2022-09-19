using EmployeeAPI.Models.DataViewModel;

namespace EmployeeAPI.Repository.Interfaces
{
    public interface IGenricRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T Entity);
        Task<bool> Delete(Guid id);
    }
}
