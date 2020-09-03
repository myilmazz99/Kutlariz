using Castle.DynamicProxy;
using Kutlariz.Business.DependencyResolvers.Autofac;
using Kutlariz.Business.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Kutlariz.Business.Aspects.Logging
{
    public class LoggingAspect : IInterceptor
    {
        private readonly ILoggerService _loggerService;

        public LoggingAspect(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void Intercept(IInvocation invocation)
        {
            _loggerService.LogInfo($"Calling method {invocation.Method.Name}");

            invocation.Proceed();

            _loggerService.LogInfo($"Done calling method {invocation.Method.Name}");
        }
    }
}
