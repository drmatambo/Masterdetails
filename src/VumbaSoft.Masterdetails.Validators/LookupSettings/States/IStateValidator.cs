using VumbaSoft.Masterdetails.Objects;
using System;

namespace VumbaSoft.Masterdetails.Validators
{
    public interface IStateValidator : IValidator
    {
        Boolean CanCreate(StateView view);
        Boolean CanEdit(StateView view);
    }
}
