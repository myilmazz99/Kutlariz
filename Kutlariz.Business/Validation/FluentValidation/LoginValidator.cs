using FluentValidation;
using FluentValidation.Validators;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Validation.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(i => i.Password).NotEmpty().WithMessage("Parola girmek zorunludur.");
            RuleFor(i => i.Email).NotEmpty().WithMessage("Email girmek zorunludur.");
            RuleFor(i => i.Email).EmailAddress().WithMessage("Girilen email adresi geçersizdir.");
        }
    }
}
