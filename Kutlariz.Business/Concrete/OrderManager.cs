using AutoMapper;
using Kutlariz.Business.Abstract;
using Kutlariz.Business.Services.PaymentService;
using Kutlariz.Business.Validation.FluentValidation;
using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Core.Constants;
using Kutlariz.DataAccess.Abstract;
using Kutlariz.Entities;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kutlariz.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IPaymentService paymentService, IMapper mapper)
        {
            _orderDal = orderDal;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<Result> CompletePayment(OrderDto order)
        {
            var validation = Validator.Validate(order, new OrderValidation());
            if (!validation.IsSuccess) return validation;

            if(order.PaymentType == PaymentType.Credit)
            {
                var payment = _paymentService.Pay(order);

                if (payment.Status != "success") return new ErrorResult(payment.ErrorMessage);
            }

            await _orderDal.Create(_mapper.Map<Order>(order));

            return new SuccessResult(ResultMessages.PaymentSuccess);
        }

        public async Task<DataResult<List<DisplayOrderDto>>> GetOrdersByUserId(string userId)
        {
            var orders = await _orderDal.GetAll(i => i.UserId == userId);
            return new SuccessDataResult<List<DisplayOrderDto>>(_mapper.Map<List<DisplayOrderDto>>(orders));
        }
    }
}
