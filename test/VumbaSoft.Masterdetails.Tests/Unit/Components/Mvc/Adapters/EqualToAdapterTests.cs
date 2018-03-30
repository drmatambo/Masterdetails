using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Resources.Form;
using VumbaSoft.Masterdetails.Tests.Objects;
using System;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Components.Mvc
{
    public class EqualToAdapterTests
    {
        #region GetClientValidationRules()

        [Fact]
        public void GetClientValidationRules_ReturnsEqualToValidationRule()
        {
            ModelMetadata metadata = new DataAnnotationsModelMetadataProvider().GetMetadataForProperty(null, typeof(AdaptersModel), "EqualTo");
            EqualToAdapter adapter = new EqualToAdapter(metadata, new ControllerContext(), new EqualToAttribute("StringLength"));

            String expectedMessage = String.Format(Validations.EqualTo, "EqualTo", "StringLength");
            ModelClientValidationRule actual = adapter.GetClientValidationRules().Single();

            Assert.Equal("*.StringLength", actual.ValidationParameters["other"]);
            Assert.Equal(expectedMessage, actual.ErrorMessage);
            Assert.Equal("equalto", actual.ValidationType);
            Assert.Single(actual.ValidationParameters);
        }

        #endregion
    }
}
