using EmployeeAPI.Data;
using EmployeeAPI.Models.DataViewModel;
using EmployeeAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class BaseRepository<T>: IGenricRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var isEmployee = _dbSet.FindAsync(id);
            if (isEmployee !=null)
            {
                _dbContext.Remove(isEmployee);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }


        public async Task<T> GetById(Guid id) => await _dbSet.FindAsync(id);

        public Task<T> Update(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
