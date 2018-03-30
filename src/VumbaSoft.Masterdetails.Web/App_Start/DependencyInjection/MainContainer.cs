using LightInject;
using VumbaSoft.Masterdetails.Components.Logging;
using VumbaSoft.Masterdetails.Components.Mail;
using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Components.Security;
using VumbaSoft.Masterdetails.Controllers;
using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Data.Logging;
using VumbaSoft.Masterdetails.Services;
using VumbaSoft.Masterdetails.Validators;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Hosting;

namespace VumbaSoft.Masterdetails.Web.DependencyInjection
{
    public class MainContainer : ServiceContainer
    {
        public void RegisterServices()
        {
            Register<DbContext, Context>();
            Register<IUnitOfWork, UnitOfWork>();

            RegisterInstance<ILogger, Logger>();
            Register<IAuditLogger, AuditLogger>();

            RegisterInstance<IHasher, BCrypter>();
            RegisterInstance<IMailClient, SmtpMailClient>();

            RegisterInstance<IRouteConfig, RouteConfig>();
            RegisterInstance<IBundleConfig, BundleConfig>();

            RegisterInstance<IMvcSiteMapParser, MvcSiteMapParser>();
            RegisterInstance<IMvcSiteMapProvider>(factory => new MvcSiteMapProvider(
                HostingEnvironment.MapPath("~/Mvc.sitemap"), this.GetInstance<IMvcSiteMapParser>()));

            RegisterInstance<ILanguages>(factory => new Languages(HostingEnvironment.MapPath("~/Languages.config")));
            RegisterInstance<IAuthorizationProvider>(factory => new AuthorizationProvider(typeof(BaseController).Assembly));

            RegisterImplementations<IService>();
            RegisterImplementations<IValidator>();
        }

        private Boolean Implements<T>(Type type)
        {
            return typeof(T).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;
        }
        private void RegisterImplementations<T>()
        {
            foreach (Type type in typeof(T).Assembly.GetTypes().Where(Implements<T>))
                Register(type.GetInterface("I" + type.Name), type);
        }
        private void RegisterInstance<TService>(Func<IServiceFactory, TService> factory)
        {
            Register(factory, new PerContainerLifetime());
        }
        private void RegisterInstance<TService, TImplementation>() where TImplementation : TService
        {
            Register<TService, TImplementation>(new PerContainerLifetime());
        }
    }
}
