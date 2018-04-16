﻿using VumbaSoft.Masterdetails.Resources;
using System.Collections.Generic;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Components.Mvc
{
    public class EqualToAdapter : DataAnnotationsModelValidator<EqualToAttribute>
    {
        public EqualToAdapter(ModelMetadata metadata, ControllerContext context, EqualToAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            Attribute.OtherPropertyDisplayName = ResourceProvider.GetPropertyTitle(Metadata.ContainerType, Attribute.OtherPropertyName);
            Attribute.OtherPropertyDisplayName = Attribute.OtherPropertyDisplayName ?? Attribute.OtherPropertyName;

            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ValidationParameters["other"] = "*." + Attribute.OtherPropertyName;
            rule.ErrorMessage = ErrorMessage;
            rule.ValidationType = "equalto";

            return new[] { rule };
        }
    }
}
