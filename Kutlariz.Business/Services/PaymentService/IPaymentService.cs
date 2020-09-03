using Iyzipay.Model;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Services.PaymentService
{
    public interface IPaymentService
    {
        Payment Pay(OrderDto dto);
    }
}
