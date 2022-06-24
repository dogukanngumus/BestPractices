using AutoMapper;
using BestPractices.Core.Dtos;
using BestPractices.Core.Entities;

namespace BestPractices.Service.Mappings;

public class Mapping:Profile
{
    public Mapping()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
        CreateMap<Product, ProductsWithCategory>().ReverseMap();
    }
}