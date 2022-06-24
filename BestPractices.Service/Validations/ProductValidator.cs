using BestPractices.Core.Dtos;
using BestPractices.Core.Entities;
using FluentValidation;

namespace BestPractices.Service.Validations;

public class ProductValidator:AbstractValidator<ProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required")
            .NotEmpty().WithMessage("{PropertyName} is required");

        RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue)
            .WithMessage("{PropertyName} must be greater 0");
        RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue)
            .WithMessage("{PropertyName} must be greater 0");
    }
}