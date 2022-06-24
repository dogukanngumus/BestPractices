using BestPractices.Core.Dtos;
using BestPractices.Core.Entities;

namespace BestPractices.Core.Services;

public interface IProductService:IService<Product>
{
    Task<CustomResponseDto<List<ProductsWithCategory>>> GetProductsWithCategory();
}