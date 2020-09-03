using FluentValidation;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Validation.FluentValidation
{
    public class OrderValidation : AbstractValidator<OrderDto>
    {
        public OrderValidation()
        {
            RuleFor(i => i.AddressDescription).NotEmpty().WithMessage("Adres detay alanı boş bırakılamaz.");
        }
    }
}
