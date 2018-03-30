using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Validators;
using System;
using System.Linq.Expressions;

namespace VumbaSoft.Masterdetails.Tests.Unit.Validators
{
    public class BaseValidatorProxy : BaseValidator
    {
        public BaseValidatorProxy(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean BaseIsSpecified<TView>(TView view, Expression<Func<TView, Object>> property) where TView : BaseView
        {
            return IsSpecified(view, property);
        }
    }
}
