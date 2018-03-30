using VumbaSoft.Masterdetails.Data.Mapping;
using VumbaSoft.Masterdetails.Objects;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VumbaSoft.Masterdetails.Data.Core
{
    public class Context : DbContext
    {
        #region Administration

        protected DbSet<Role> Roles { get; set; }
        protected DbSet<Account> Accounts { get; set; }
        protected DbSet<Permission> Permissions { get; set; }
        protected DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        #region Demographics

        protected DbSet<Country> Countries { get; set; }

        protected DbSet<State> States { get; set; }

        protected DbSet<City> Cities { get; set; }

        #endregion

        #region System

        protected DbSet<AuditLog> AuditLogs { get; set; }

        #endregion

        static Context()
        {
            ObjectMapper.MapObjects();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            builder.Properties<DateTime>().Configure(config => config.HasColumnType("datetime2"));
            builder.Entity<Permission>().Property(model => model.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //TODO: For testing propose only, Remove on Production
            builder.Entity<Country>().Property(model => model.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            builder.Entity<State>().Property(model => model.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            builder.Entity<City>().Property(model => model.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }

    }
}
