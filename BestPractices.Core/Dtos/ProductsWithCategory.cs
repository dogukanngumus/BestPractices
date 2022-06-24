namespace BestPractices.Core.Dtos;

public class ProductsWithCategory:ProductDto
{
    public CategoryDto Category { get; set; }
}