﻿using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Resources.Views.Administration.Roles.RoleView;
using System;
using System.Linq;

namespace VumbaSoft.Masterdetails.Validators
{
    public class RoleValidator : BaseValidator, IRoleValidator
    {
        public RoleValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(RoleView view)
        {
            Boolean isValid = ModelState.IsValid;
            isValid &= IsUniqueTitle(view);

            return isValid;
        }
        public Boolean CanEdit(RoleView view)
        {
            Boolean isValid = ModelState.IsValid;
            isValid &= IsUniqueTitle(view);

            return isValid;
        }

        private Boolean IsUniqueTitle(RoleView view)
        {
            Boolean isUnique = !UnitOfWork
                .Select<Role>()
                .Any(role =>
                    role.Id != view.Id &&
                    role.Title.ToLower() == view.Title.ToLower());

            if (!isUnique)
                ModelState.AddModelError<RoleView>(role => role.Title, Validations.UniqueTitle);

            return isUnique;
        }
    }
}
