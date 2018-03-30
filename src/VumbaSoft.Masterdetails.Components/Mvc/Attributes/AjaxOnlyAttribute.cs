﻿using System;
using System.Reflection;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Components.Mvc
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override Boolean IsValidForRequest(ControllerContext context, MethodInfo method)
        {
            return context.HttpContext.Request.IsAjaxRequest();
        }
    }
}
