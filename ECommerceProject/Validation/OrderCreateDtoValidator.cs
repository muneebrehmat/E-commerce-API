using ECommerceProject.DTOs.OrderDTO;
using FluentValidation;

namespace ECommerceProject.Validation
{
    public class OrderCreateDtoValidator :AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.Items).NotEmpty().WithMessage("Order must contain atleast one item");

            RuleForEach(x => x.Items)
            .SetValidator(new OrderItemDtoValidator());
        }
    }
}
