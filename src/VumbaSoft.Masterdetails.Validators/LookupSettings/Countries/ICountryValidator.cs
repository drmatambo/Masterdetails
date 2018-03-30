using VumbaSoft.Masterdetails.Objects;
using System;

namespace VumbaSoft.Masterdetails.Validators
{
    public interface ICountryValidator : IValidator
    {
        Boolean CanCreate(CountryView view);
        Boolean CanEdit(CountryView view);
    }
}
