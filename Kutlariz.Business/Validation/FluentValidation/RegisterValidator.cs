using FluentValidation;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Validation.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(i => i.Birthday).NotEmpty().WithMessage("Lütfen doğum günü tarihinizi giriniz.");
            RuleFor(i => i.Email).NotEmpty().WithMessage("Lütfen email alanını doldurunuz.");
            RuleFor(i => i.FirstName).NotEmpty().WithMessage("Lütfen adınızı giriniz.");
            RuleFor(i => i.LastName).NotEmpty().WithMessage("Lütfen soyadınızı giriniz.");
            RuleFor(i => i.Password).NotEmpty().WithMessage("Lütfen şifre belirleyiniz.");
            RuleFor(i => i.RePassword).NotEmpty().WithMessage("Lütfen şifrenizi tekrar giriniz.");

            RuleFor(i => i.RePassword).Equal(i => i.Password).WithMessage("Şifreleriniz uyuşmuyor.");
        }
    }
}
