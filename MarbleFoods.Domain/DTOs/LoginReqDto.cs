using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbleFoods.Domain.DTOs
{
    public record LoginReqDto(
        string Email,
        string Password
        );

    public class LoginRequestValidator : AbstractValidator<LoginReqDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Must(email => email.Contains("@") && email.Contains("."))
                .WithMessage("Email must contain '@' and '.'.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 20).WithMessage("Name must be between 2 and 20 characters.");
        }
    }
}
