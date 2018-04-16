﻿using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Data.Migrations
{
    public class InitialDataTests : IDisposable
    {
        private Context context;

        public InitialDataTests()
        {
            context = new Context();
        }
        public void Dispose()
        {
            context.Dispose();
        }

        #region Roles

        [Fact]
        public void RolesTable_HasSysAdmin()
        {
            Assert.NotNull(context.Set<Role>().SingleOrDefault(role => role.Title == "Sys_Admin"));
        }

        #endregion

        #region Accounts

        [Fact]
        public void AccountsTable_HasSysAdmin()
        {
            Assert.NotNull(context.Set<Account>()
                .SingleOrDefault(account =>
                    account.Username == "admin" &&
                    account.Role.Title == "Sys_Admin"));
        }

        #endregion

        #region Permissions

        [Theory]
        [InlineData("Administration", "Accounts", "Index")]
        [InlineData("Administration", "Accounts", "Create")]
        [InlineData("Administration", "Accounts", "Details")]
        [InlineData("Administration", "Accounts", "Edit")]

        [InlineData("Administration", "Roles", "Index")]
        [InlineData("Administration", "Roles", "Create")]
        [InlineData("Administration", "Roles", "Details")]
        [InlineData("Administration", "Roles", "Edit")]
        [InlineData("Administration", "Roles", "Delete")]
        public void PermissionsTable_HasPermission(String area, String controller, String action)
        {
            Assert.NotNull(context.Set<Permission>().SingleOrDefault(permission =>
                permission.Controller == controller &&
                permission.Action == action &&
                permission.Area == area));
        }

        [Fact]
        public void PermissionsTable_HasExactNumberOfPermissions()
        {
            Int32 actual = context.Set<Permission>().Count();
            Int32 expected = 35;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region RolePermissions

        [Fact]
        public void RolesPermissionsTable_HasAllSysAdminPermissions()
        {
            IEnumerable<Int32> expected = context
                .Set<Permission>()
                .Select(permission => permission.Id)
                .OrderBy(permissionId => permissionId);

            IEnumerable<Int32> actual = context
                .Set<RolePermission>()
                .Where(permission => permission.Role.Title == "Sys_Admin")
                .Select(rolePermission => rolePermission.PermissionId)
                .OrderBy(permissionId => permissionId);

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}
