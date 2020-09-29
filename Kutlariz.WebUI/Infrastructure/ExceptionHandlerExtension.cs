using Kutlariz.Business.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutlariz.WebUI.Infrastructure
{
    public static class ExceptionHandlerExtension
    {
        public static void UseExceptionHandler(this IApplicationBuilder app, ILoggerService logger)
        {
            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await Task.Run(() => logger.LogError(CheckInnerException(contextFeature.Error), ""));
                        context.Response.StatusCode = 500;
                    }
                });
            });
        }

        static Exception CheckInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                CheckInnerException(ex);
            }

            return ex;
        }
    }
}
