using BestPractices.Core.Dtos;
using BestPractices.Core.Entities;

namespace BestPractices.Core.Repositories;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithCategory();
}