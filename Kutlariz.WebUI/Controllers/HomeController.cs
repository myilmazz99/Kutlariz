using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kutlariz.WebUI.Models;
using Kutlariz.Business.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Kutlariz.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBirthdayPersonService _birthdayPerson;
        private readonly IAccountService _accountService;

        public HomeController(IBirthdayPersonService birthdayPerson, IAccountService accountService)
        {
            _birthdayPerson = birthdayPerson;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            throw new Exception();
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = await _accountService.FindByUsername(HttpContext.User.Identity.Name);
                var birthdays = await _birthdayPerson.GetClosestThree(user.Data.Id);
                return View(birthdays.Data);
            }
            else
                return View();
        }
    }
}
