﻿using VumbaSoft.Masterdetails.Components.Security;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Tests.Unit.Components.Security
{
    [AllowAnonymous]
    [ExcludeFromCodeCoverage]
    public class AllowAnonymousController : AuthorizedController
    {
        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        [AllowUnauthorized]
        public ViewResult AuthorizedAction()
        {
            return null;
        }
    }
}
