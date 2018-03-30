using System;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Controllers.LookupSettings
{
    public class LookupSettingsAreaRegistration : AreaRegistration
    {
        public override String AreaName => "LookupSettings";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context
                .MapRoute(
                    "LookupSettingsMultilingual",
                    "{language}/LookupSettings/{controller}/{action}/{id}",
                    new { area = "LookupSettings", action = "Index", id = UrlParameter.Optional },
                    new { language = "lt", id = "[0-9]*" },
                    new[] { "VumbaSoft.Masterdetails.Controllers.LookupSettings" });

            context
                .MapRoute(
                    "LookupSettings",
                    "LookupSettings/{controller}/{action}/{id}",
                    new { language = "en", area = "LookupSettings", action = "Index", id = UrlParameter.Optional },
                    new { language = "en", id = "[0-9]*" },
                    new[] { "VumbaSoft.Masterdetails.Controllers.LookupSettings" });
        }
    }
}
