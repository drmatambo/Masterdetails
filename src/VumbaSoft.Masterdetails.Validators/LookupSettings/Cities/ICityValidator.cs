using VumbaSoft.Masterdetails.Objects;
using System;

namespace VumbaSoft.Masterdetails.Validators
{
    public interface ICityValidator : IValidator
    {
        Boolean CanCreate(CityView view);
        Boolean CanEdit(CityView view);
    }
}
