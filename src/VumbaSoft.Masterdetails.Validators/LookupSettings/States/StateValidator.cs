using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using System;

namespace VumbaSoft.Masterdetails.Validators
{
    public class StateValidator : BaseValidator, IStateValidator
    {
        public StateValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(StateView view)
        {
            return ModelState.IsValid;
        }
        public Boolean CanEdit(StateView view)
        {
            return ModelState.IsValid;
        }
    }
}
