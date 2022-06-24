using System.Linq.Expressions;
using BestPractices.Core.Repositories;
using BestPractices.Core.Services;
using BestPractices.Core.UnitOfWorks;
using BestPractices.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Service.Services;

public class Service<T> :IService<T> where T:class
{
    private IGenericRepository<T> _genericRepository;
    private IUnitOfWork _unitOfWork;

    public Service(IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork)
    {
        _genericRepository = genericRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _genericRepository.GetAll().ToListAsync();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> filter)
    {
        return _genericRepository.Where(filter);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var hasProduct =  await _genericRepository.GetByIdAsync(id);
        if (hasProduct == null)
        {
            throw new NotFoundException($"{typeof(T).Name} not found.");
        }

        return hasProduct;
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
    {
        return await _genericRepository.AnyAsync(filter);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _genericRepository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _genericRepository.AddRangeAsync(entities);
        await _unitOfWork.CommitAsync();
        return entities;
    }

    public async Task UpdateAsync(T entity)
    {
        _genericRepository.Update(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _genericRepository.Remove(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _genericRepository.RemoveRange(entities);
        await _unitOfWork.CommitAsync();
    }
}