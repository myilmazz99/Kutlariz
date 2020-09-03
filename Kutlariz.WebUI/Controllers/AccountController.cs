using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Kutlariz.Business.Abstract;
using Kutlariz.Core.ActionResult;
using Kutlariz.Entities.Dto;
using Kutlariz.WebUI.Helpers;
using Kutlariz.WebUI.Infrastructure;
using Kutlariz.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutlariz.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly IBirthdayPersonService _birthdayPerson;
        private readonly IAccountService _accountService;

        public AccountController(IBirthdayPersonService birthdayPerson, IAccountService accountService)
        {
            _birthdayPerson = birthdayPerson;
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _accountService.Login(dto);
            if (result.ErrorType == ErrorType.Validation)
            {
                return ControllerHelperMethods.AddValidationErrorsToModel(result.Message, ViewData, dto);
            }

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            TempData.Put("result", new ResultModel { IsSuccess = result.IsSuccess, Message = result.Message });
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _accountService.Register(dto);
            if (result.ErrorType == ErrorType.Validation)
            {
                return ControllerHelperMethods.AddValidationErrorsToModel(result.Message, ViewData, dto);
            }

            if (!result.IsSuccess)
            {
                foreach (var item in result.Messages)
                {
                    ModelState.AddModelError("", item);
                }
                return View(dto);
            }

            TempData.Put("result", new ResultModel { IsSuccess = result.IsSuccess, Message = result.Message });
            return RedirectToAction("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var result = await _accountService.Logout();
            TempData.Put("result", new ResultModel { IsSuccess = result.IsSuccess, Message = result.Message });
            return Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var tryGetUser = await _accountService.FindByUsername(HttpContext.User.Identity.Name);
            if (!tryGetUser.IsSuccess)
            {
                TempData.Put("result", new ResultModel { IsSuccess = tryGetUser.IsSuccess, Message = tryGetUser.Message });
                return Redirect("/");
            }

            var birthdays = await _birthdayPerson.GetAllByUserId(tryGetUser.Data.Id);

            var model = new ProfileModel
            {
                BirthdayPeople = birthdays.Data,
                User = tryGetUser.Data
            };

            return View(model);
        }
    }
}