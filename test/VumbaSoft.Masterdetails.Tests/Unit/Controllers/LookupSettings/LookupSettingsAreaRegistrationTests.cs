using VumbaSoft.Masterdetails.Controllers.LookupSettings;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Controllers.LookupSettings
{
    public class LookupSettingsAreaRegistrationTests
    {
        private LookupSettingsAreaRegistration areaRegistration;
        private AreaRegistrationContext registrationContext;

        public LookupSettingsAreaRegistrationTests()
        {
            areaRegistration = new LookupSettingsAreaRegistration();
            registrationContext = new AreaRegistrationContext(areaRegistration.AreaName, new RouteCollection());

            areaRegistration.RegisterArea(registrationContext);
        }

        #region AreaName

        [Fact]
        public void AreaName_IsLookupSettings()
        {
            Assert.Equal("LookupSettings", areaRegistration.AreaName);
        }

        #endregion

        #region RegisterArea(AreaRegistrationContext context)

        [Fact]
        public void RegisterArea_MultilingualRoute()
        {
            Route actual = registrationContext.Routes["LookupSettingsMultilingual"] as Route;

            Assert.Equal(new[] { "VumbaSoft.Masterdetails.Controllers.LookupSettings" }, actual.DataTokens["Namespaces"] as String[]);
            Assert.Equal("{language}/LookupSettings/{controller}/{action}/{id}", actual.Url);
            Assert.Equal(UrlParameter.Optional, actual.Defaults["id"]);
            Assert.Equal("LookupSettings", actual.DataTokens["area"]);
            Assert.Equal("LookupSettings", actual.Defaults["area"]);
            Assert.Equal("lt", actual.Constraints["language"]);
            Assert.Equal("[0-9]*", actual.Constraints["id"]);
            Assert.Equal("Index", actual.Defaults["action"]);
            Assert.Equal(2, actual.Constraints.Count);
            Assert.Equal(3, actual.DataTokens.Count);
            Assert.Equal(3, actual.Defaults.Count);
        }

        [Fact]
        public void RegisterArea_DefaultRoute()
        {
            Route actual = registrationContext.Routes["LookupSettings"] as Route;

            Assert.Equal(new[] { "VumbaSoft.Masterdetails.Controllers.LookupSettings" }, actual.DataTokens["Namespaces"] as String[]);
            Assert.Equal("LookupSettings/{controller}/{action}/{id}", actual.Url);
            Assert.Equal(UrlParameter.Optional, actual.Defaults["id"]);
            Assert.Equal("LookupSettings", actual.DataTokens["area"]);
            Assert.Equal("LookupSettings", actual.Defaults["area"]);
            Assert.Equal("en", actual.Constraints["language"]);
            Assert.Equal("[0-9]*", actual.Constraints["id"]);
            Assert.Equal("Index", actual.Defaults["action"]);
            Assert.Equal("en", actual.Defaults["language"]);
            Assert.Equal(2, actual.Constraints.Count);
            Assert.Equal(3, actual.DataTokens.Count);
            Assert.Equal(4, actual.Defaults.Count);
        }

        #endregion
    }
}
