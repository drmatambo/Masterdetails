﻿using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Tests.Unit.Components.Security
{
    [ExcludeFromCodeCoverage]
    public class InheritedAuthorizedController : AuthorizedController
    {
        [HttpGet]
        public ViewResult InheritanceAction()
        {
            return null;
        }
    }
}
