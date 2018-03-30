using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using System;

namespace VumbaSoft.Masterdetails.Validators
{
    public class CityValidator : BaseValidator, ICityValidator
    {
        public CityValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CityView view)
        {
            return ModelState.IsValid;
        }
        public Boolean CanEdit(CityView view)
        {
            return ModelState.IsValid;
        }
    }
}
