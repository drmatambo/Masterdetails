﻿using VumbaSoft.Masterdetails.Resources.Form;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Components.Mvc
{
    public class RangeAdapter : RangeAttributeAdapter
    {
        public RangeAdapter(ModelMetadata metadata, ControllerContext context, RangeAttribute attribute)
            : base(metadata, context, attribute)
        {
            Attribute.ErrorMessage = Validations.Range;
        }
    }
}
