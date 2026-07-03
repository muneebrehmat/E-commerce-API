using ECommerceProject.DTOs.CategoryDTO;
using FluentValidation;

namespace ECommerceProject.Validation
{
    public class CategoryCreateDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category Name is required").MaximumLength(50);
        }
    }
}
