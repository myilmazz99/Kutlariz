using Kutlariz.Business.Abstract;
using Kutlariz.Core.ActionResult;
using Kutlariz.Entities.Dto;
using Kutlariz.WebUI.Helpers;
using Kutlariz.WebUI.Infrastructure;
using Kutlariz.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutlariz.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBirthdayPersonService _birthdayService;
        private readonly IAccountService _accountService;

        public OrderController(IOrderService orderService, IAccountService accountService, IBirthdayPersonService birthdayService)
        {
            _orderService = orderService;
            _accountService = accountService;
            _birthdayService = birthdayService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var birthdayPersonResult = await _birthdayService.GetById(id);
            if (birthdayPersonResult.IsSuccess)
            {
                var model = new OrderModel
                {
                    Order = new OrderDto(),
                    BirthdayPersonDetails = birthdayPersonResult.Data
                };

                return View(model);
            }

            TempData.Put("result", new ResultModel { IsSuccess = birthdayPersonResult.IsSuccess, Message = birthdayPersonResult.Message });
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderModel model)
        {
            model.Order.Email = HttpContext.User.Identity.Name;
            model.Order.UserId = _accountService.GetUserId(HttpContext.User).Data;

            var result = await _orderService.CompletePayment(model.Order);
            if (result.ErrorType == ErrorType.Validation)
                return ControllerHelperMethods.AddValidationErrorsToModel(result.Message, ViewData, model);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("paymentError", result.Message);
                return View(model);
            }

            TempData.Put("result", new ResultModel { IsSuccess = true, Message = result.Message });
            return RedirectToAction("Orders");
        }

        public async Task<IActionResult> Orders()
        {
            var userId = _accountService.GetUserId(HttpContext.User);
            var orders = await _orderService.GetOrdersByUserId(userId.Data);
            return View(orders.Data);
        }
    }
}
