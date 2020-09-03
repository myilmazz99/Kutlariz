using FluentValidation;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Validation.FluentValidation
{
    public class BirthdayPersonValidator : AbstractValidator<AddOrUpdateBirthdayPersonDto>
    {
        public BirthdayPersonValidator()
        {
            RuleFor(i => i.Birthday).NotEmpty().WithMessage("Doğum günü tarihi girmek zorunludur.");
            RuleFor(i => i.FirstName).NotEmpty().WithMessage("İsim alanı girmek zorunludur.");
            RuleFor(i => i.LastName).NotEmpty().WithMessage("İsim alanı girmek zorunludur.");
        }
    }
}
