using ECommerceProject.DTOs.ProductDTO;
using FluentValidation;

namespace ECommerceProject.Validation
{
    public class ProductUpdateDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Name required.").MaximumLength(100);

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);

            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
