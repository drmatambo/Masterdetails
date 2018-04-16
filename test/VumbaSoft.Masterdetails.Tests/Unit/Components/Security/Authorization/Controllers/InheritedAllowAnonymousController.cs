﻿using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Tests.Unit.Components.Security
{
    [ExcludeFromCodeCoverage]
    public class InheritedAllowAnonymousController : AllowAnonymousController
    {
        [HttpGet]
        public ViewResult InheritanceAction()
        {
            return null;
        }
    }
}
