using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Kutlariz.Business.Abstract;
using Kutlariz.Business.Aspects.Caching;
using Kutlariz.Business.Aspects.Logging;
using Kutlariz.Business.Caching;
using Kutlariz.Business.Caching.Microsoft;
using Kutlariz.Business.Concrete;
using Kutlariz.Business.Logging;
using Kutlariz.Business.Logging.NLog;
using Kutlariz.Business.Services.ImageCDN;
using Kutlariz.Business.Services.ImageCDN.ImagekitCDN;
using Kutlariz.Business.Services.PaymentService;
using Kutlariz.Business.Services.PaymentService.Iyzico;
using Kutlariz.DataAccess.Abstract;
using Kutlariz.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kutlariz.Business.DependencyResolvers.Autofac
{
    public class BusinessModule : global::Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfBirthdayPersonDal<KutlarizContext>>().As<IBirthdayPersonDal> ()
                .SingleInstance();
            builder.RegisterType<BirthdayPersonManager>().As<IBirthdayPersonService>()
                .SingleInstance();

            builder.RegisterType<AccountManager>().As<IAccountService>()
                .InstancePerDependency()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingAspect));

            builder.RegisterType<EfOrderDal<KutlarizContext>>().As<IOrderDal>()
                .SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>()
                .SingleInstance()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingAspect));

            builder.RegisterType<LoggerManager>().As<ILoggerService>()
                .SingleInstance();
            builder.RegisterType<LoggingAspect>().InstancePerDependency();
            builder.RegisterType<CachingAspect>().InstancePerDependency();

            builder.RegisterType<IyzicoPaymentManager>().As<IPaymentService>()
                .SingleInstance();

            builder.RegisterType<ImageManager>().As<IImageService>()
                .SingleInstance()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingAspect));

            builder.RegisterType<MicrosoftCacheManager>().As<ICacheService>()
                .SingleInstance()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingAspect));

        }
    }
}
