using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using System;

namespace VumbaSoft.Masterdetails.Validators
{
    public class CountryValidator : BaseValidator, ICountryValidator
    {
        public CountryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CountryView view)
        {
            return ModelState.IsValid;
        }
        public Boolean CanEdit(CountryView view)
        {
            return ModelState.IsValid;
        }
    }
}
