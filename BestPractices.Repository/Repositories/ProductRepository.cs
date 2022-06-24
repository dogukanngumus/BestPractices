using BestPractices.Core.Entities;
using BestPractices.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Repository.Repositories;

public class ProductRepository:GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<List<Product>> GetProductsWithCategory()
    {
        return await _context.Products.Include(x => x.Category).ToListAsync();
    }
}