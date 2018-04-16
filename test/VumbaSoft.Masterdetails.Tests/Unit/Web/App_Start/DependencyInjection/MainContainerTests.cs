﻿using VumbaSoft.Masterdetails.Components.Logging;
using VumbaSoft.Masterdetails.Components.Mail;
using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Components.Security;
using VumbaSoft.Masterdetails.Controllers;
using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Data.Logging;
using VumbaSoft.Masterdetails.Web;
using VumbaSoft.Masterdetails.Web.DependencyInjection;
using System;
using System.Data.Entity;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Web.DependencyInjection
{
    public class MainContainerTests
    {
        private static MainContainer container;

        static MainContainerTests()
        {
            container = new MainContainer();
            container.RegisterServices();
        }

        #region RegisterServices()

        [Theory]
        [InlineData(typeof(DbContext), typeof(Context))]
        [InlineData(typeof(IUnitOfWork), typeof(UnitOfWork))]
        [InlineData(typeof(IAuditLogger), typeof(AuditLogger))]
        public void RegisterServices_Transient(Type abstraction, Type expectedType)
        {
            Object expected = container.GetInstance(abstraction);
            Object actual = container.GetInstance(abstraction);

            Assert.IsType(expectedType, actual);
            Assert.NotSame(expected, actual);
        }

        [Theory]
        [InlineData(typeof(ILogger), typeof(Logger))]

        [InlineData(typeof(IHasher), typeof(BCrypter))]
        [InlineData(typeof(IMailClient), typeof(SmtpMailClient))]

        [InlineData(typeof(IRouteConfig), typeof(RouteConfig))]
        [InlineData(typeof(IBundleConfig), typeof(BundleConfig))]

        [InlineData(typeof(IMvcSiteMapParser), typeof(MvcSiteMapParser))]

        [InlineData(typeof(IAuthorizationProvider), typeof(AuthorizationProvider))]
        public void RegisterServices_Singleton(Type abstraction, Type expectedType)
        {
            Object expected = container.GetInstance(abstraction);
            Object actual = container.GetInstance(abstraction);

            Assert.IsType(expectedType, actual);
            Assert.Same(expected, actual);
        }

        #endregion
    }
}
