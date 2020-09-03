using Kutlariz.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kutlariz.WebUI.Helpers
{
    public static class ControllerHelperMethods
    {
        public static IActionResult AddValidationErrorsToModel(string errors,
                                                                ViewDataDictionary viewData,
                                                                object model = null)
        {
            var errorsJson = JsonSerializer.Deserialize<IEnumerable<ValidationDto>>(errors);
            foreach (var error in errorsJson)
            {
                viewData.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            viewData.Model = model;
            return new ViewResult { ViewData = viewData };
        }
    }
}
