using FluentValidation;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Validation;

public sealed class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
    }
}

public sealed class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
    }
}
