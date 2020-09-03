using Castle.DynamicProxy;
using Kutlariz.Business.Caching;
using Kutlariz.Core.ActionResult.DataResult;
using Kutlariz.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kutlariz.Business.Aspects.Caching
{
    public class CachingAspect : IInterceptor
    {
        private readonly ICacheService _cacheService;

        public CachingAspect(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public void Intercept(IInvocation invocation)
        {
            //string key = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}({string.Join(',', invocation.Arguments.Select(i => i?.ToString() ?? null))})";
            
            //if (invocation.Method.Name.StartsWith("Get"))
            //{
            //    if (_cacheService.DoesExist(key))
            //    {
            //        switch (invocation.Method.DeclaringType.Name)
            //        {
            //            case "IAccountService":
            //                invocation.ReturnValue = new SuccessDataResult<UserDto>((UserDto)_cacheService.Get(key));
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //        //invocation.ReturnValue = new SuccessDataResult()
            //}
            //else
            //{
            //    //_cacheService.Remove()
            //}
        }
    }
}
