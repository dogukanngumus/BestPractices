using System.Linq.Expressions;

namespace BestPractices.Core.Services;

public interface IService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> Where(Expression<Func<T, bool>> filter);
    Task<T> GetByIdAsync(int id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}