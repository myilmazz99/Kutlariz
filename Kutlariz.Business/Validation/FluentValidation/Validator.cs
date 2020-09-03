using FluentValidation;
using Kutlariz.Core.ActionResult;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Kutlariz.Business.Validation.FluentValidation
{
    public static class Validator
    {
        public static Result Validate(object entity, IValidator validator)
        {
            var context = new ValidationContext<object>(entity);
            var validation = validator.Validate(context);

            if (!validation.IsValid)
            {
                var errors = validation.Errors;
                return new ErrorResult(
                    JsonSerializer.Serialize(errors.Select(i => new ValidationDto { PropertyName = i.PropertyName, ErrorMessage = i.ErrorMessage })),
                                            ErrorType.Validation);
            }

            return new SuccessResult();
        }
    }
}
