using System.Linq.Expressions;
using BestPractices.Core.Entities;

namespace BestPractices.Core.Repositories;

public interface IGenericRepository<T>  where T: class
{
    IQueryable<T> GetAll();
    IQueryable<T> Where(Expression<Func<T, bool>> filter);
    Task<T> GetByIdAsync(int id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}