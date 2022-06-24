using AutoMapper;
using BestPractices.Core.Dtos;
using BestPractices.Core.Entities;
using BestPractices.Core.Repositories;
using BestPractices.Core.Services;
using BestPractices.Core.UnitOfWorks;

namespace BestPractices.Service.Services;

public class ProductService:Service<Product>,IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IGenericRepository<Product> genericRepository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(genericRepository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<CustomResponseDto<List<ProductsWithCategory>>> GetProductsWithCategory()
    {
        var product = await _productRepository.GetProductsWithCategory();
        var dto = _mapper.Map<List<ProductsWithCategory>>(product);
        return CustomResponseDto<List<ProductsWithCategory>>.Success(200, dto);
    }

}