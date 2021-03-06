﻿using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Tests.Objects;
using System.Data.Entity;

namespace VumbaSoft.Masterdetails.Tests.Data
{
    public class TestingContext : Context
    {
        #region Tests

        protected DbSet<TestModel> TestModels { get; set; }

        #endregion

        public void DropData()
        {
            Set<RolePermission>().RemoveRange(Set<RolePermission>());
            Set<Permission>().RemoveRange(Set<Permission>());
            Set<Account>().RemoveRange(Set<Account>());
            Set<Role>().RemoveRange(Set<Role>());

            SaveChanges();
        }
    }
}
