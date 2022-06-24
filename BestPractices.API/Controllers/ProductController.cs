using AutoMapper;
using BestPractices.API.Filters;
using BestPractices.Core.Dtos;
using BestPractices.Core.Entities;
using BestPractices.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.API.Controllers;

public class ProductController:CustomBaseController
{
    private readonly IMapper _mapper;
    private readonly IProductService _service;

    public ProductController(IMapper mapper, IProductService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var product = await _service.GetAllAsync();
        var productDtos = _mapper.Map<List<ProductDto>>(product.ToList());
        return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetProductsWithCategory()
    {
        return CreateActionResult(await _service.GetProductsWithCategory());
    }
    
    [ServiceFilter(typeof(NotFoundFilter<Product>))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
    }
    
    [HttpPost]
    public async Task<IActionResult> Save(ProductDto productDto)
    {
        var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
        var newProductDto = _mapper.Map<ProductDto>(product);
        return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, newProductDto));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(ProductDto productDto)
    {
        await _service.UpdateAsync(_mapper.Map<Product>(productDto));
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id )
    {
        var product = await _service.GetByIdAsync(id);
        await _service.RemoveAsync(_mapper.Map<Product>(product));
        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
    }
}