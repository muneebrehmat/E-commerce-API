using ECommerceProject.DTOs.RegisterDTO;
using FluentValidation;

namespace ECommerceProject.Validation
{
    public class RegisterDtoValidator :AbstractValidator<RegistrationDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(X => X.UserName).NotEmpty().WithMessage("Username is required").MaximumLength(50);

            RuleFor(X => X.Email).NotEmpty().WithMessage("Email is required.").
                EmailAddress().WithMessage("Valid Email Format.");

            RuleFor(X => X.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).MaximumLength(12);
        }
    }
}
