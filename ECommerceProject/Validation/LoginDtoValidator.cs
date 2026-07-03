using ECommerceProject.DTOs.LoginDTO;
using FluentValidation;

namespace ECommerceProject.Validation
{
    public class LoginDtoValidator :AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Required.")
                .EmailAddress().WithMessage("Valid Email Format");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Required")
                .MinimumLength(6).MaximumLength(20);
        }
    }
}
