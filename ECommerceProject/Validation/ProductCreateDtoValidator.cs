using ECommerceProject.DTOs.ProductDTO;
using FluentValidation;

namespace ECommerceProject.Validation
{
    public class ProductCreateDtoValidator : AbstractValidator<CreateProductDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Name required.").MaximumLength(100);

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
