using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kutlariz.Business.Abstract;
using Kutlariz.Business.Services.ImageCDN;
using Kutlariz.Core.ActionResult;
using Kutlariz.Entities.Dto;
using Kutlariz.WebUI.Helpers;
using Kutlariz.WebUI.Infrastructure;
using Kutlariz.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kutlariz.WebUI.Controllers
{
    public class BirthdayController : Controller
    {
        private readonly IBirthdayPersonService _birthdayPerson;
        private readonly IAccountService _accountService;
        private readonly IImageService _imageService;

        public BirthdayController(
            IBirthdayPersonService birthdayPerson,
            IAccountService accountService,
            IImageService imageService)
        {
            _birthdayPerson = birthdayPerson;
            _accountService = accountService;
            _imageService = imageService;
        }

        public async Task<IActionResult> AddOrUpdate(int? Id)
        {
            if (Id == null)
            {
                return View(new BirthdayPersonDto { });
            }

            var result = await _birthdayPerson.GetById((int)Id);

            if (result.Data == null)
            {
                return View(new BirthdayPersonDto { });
            }

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(BirthdayPersonDto model, IFormFile profilePicture)
        {
            var userId = _accountService.GetUserId(HttpContext.User);
            model.UserId = userId.Data;

            if (profilePicture != null && profilePicture.ContentType.Contains("image"))
            {
                var url = await _imageService.Upload(profilePicture);
                model.ProfilePictureUrl = url;
            }

            var result = await _birthdayPerson.AddOrUpdate(model);
            if (result.ErrorType == ErrorType.Validation)
                return ControllerHelperMethods.AddValidationErrorsToModel(result.Message, ViewData, model);

            TempData.Put("result", new ResultModel { IsSuccess = result.IsSuccess, Message = result.Message });
            return RedirectToAction("Profile", "Account");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _birthdayPerson.Delete(Id);
            TempData.Put("result", new ResultModel { IsSuccess = result.IsSuccess, Message = result.Message });
            return RedirectToAction("Profile", "Account", new { userName = User.Identity.Name });
        }
    }
}