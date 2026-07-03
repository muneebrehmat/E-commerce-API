using ECommerceProject.DTOs.OrderDTO;
using FluentValidation;

namespace ECommerceProject.Validation
{
    public class OrderItemDtoValidator:AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
