using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Utilities.Helpers
{
    public static class TranslateIdentityErrors
    {
        public static IEnumerable<IdentityError> Translate(IEnumerable<IdentityError> errors)
        {
            foreach (var err in errors)
            {
                switch (err.Code)
                {
                    case "DuplicateEmail":
                        err.Description = "Girdiğiniz email adresi kullanımda. Devam edebilmek için farklı bir email adresi girmelisiniz.";
                        break;
                    case "DuplicateUserName":
                        err.Description = "";
                        break;
                    default:
                        break;
                }

            }

            return errors;
        }
    }
}
