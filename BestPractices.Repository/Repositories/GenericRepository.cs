using System.Linq.Expressions;
using BestPractices.Core.Entities;
using BestPractices.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Repository.Repositories;

public class GenericRepository<T>:IGenericRepository<T> where T: class
{
    protected readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> filter)
    {
        return _dbSet.Where(filter);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.AnyAsync(filter);
    }

    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Remove(T entity)
    {
        _context.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.RemoveRange(entities);
    }
}