using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.Business.Abstract
{
    public interface IOrderService
    {
        Task<Result> CompletePayment(OrderDto order);
        Task<DataResult<List<DisplayOrderDto>>> GetOrdersByUserId(string userId);
    }
}
