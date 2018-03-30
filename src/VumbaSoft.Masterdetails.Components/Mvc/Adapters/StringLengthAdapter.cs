using VumbaSoft.Masterdetails.Resources.Form;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Components.Mvc
{
    public class StringLengthAdapter : StringLengthAttributeAdapter
    {
        public StringLengthAdapter(ModelMetadata metadata, ControllerContext context, StringLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
            Attribute.ErrorMessage = Attribute.MinimumLength == 0 ? Validations.StringLength : Validations.StringLengthRange;
        }
    }
}
