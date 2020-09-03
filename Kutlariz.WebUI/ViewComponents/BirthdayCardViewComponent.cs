using Kutlariz.Business.Abstract;
using Kutlariz.Entities;
using Kutlariz.Entities.Dto;
using Kutlariz.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutlariz.WebUI.ViewComponents
{
    public class BirthdayCardViewComponent : ViewComponent
    {
        private IBirthdayPersonService birthdayPerson;

        public BirthdayCardViewComponent(IBirthdayPersonService birthdayPerson)
        {
            this.birthdayPerson = birthdayPerson;
        }

        public IViewComponentResult Invoke(string page, BirthdayPersonDto model)
        {
            ViewData["page"] = page;

            return View(model);
        }
    }
}
