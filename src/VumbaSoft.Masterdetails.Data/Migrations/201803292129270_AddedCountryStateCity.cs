namespace VumbaSoft.Masterdetails.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCountryStateCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        StateId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedById = c.Int(),
                        DeletedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 256),
                        CountryId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedById = c.Int(),
                        DeletedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Shortname = c.String(maxLength: 3),
                        Name = c.String(maxLength: 256),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedById = c.Int(),
                        UpdatedById = c.Int(),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Deleted = c.Boolean(nullable: false),
                        DeletedById = c.Int(),
                        DeletedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Account", "CreatedById", c => c.Int());
            AddColumn("dbo.Account", "UpdatedById", c => c.Int());
            AddColumn("dbo.Account", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Account", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Account", "DeletedById", c => c.Int());
            AddColumn("dbo.Account", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Role", "CreatedById", c => c.Int());
            AddColumn("dbo.Role", "UpdatedById", c => c.Int());
            AddColumn("dbo.Role", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Role", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Role", "DeletedById", c => c.Int());
            AddColumn("dbo.Role", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.RolePermission", "CreatedById", c => c.Int());
            AddColumn("dbo.RolePermission", "UpdatedById", c => c.Int());
            AddColumn("dbo.RolePermission", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.RolePermission", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.RolePermission", "DeletedById", c => c.Int());
            AddColumn("dbo.RolePermission", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Permission", "CreatedById", c => c.Int());
            AddColumn("dbo.Permission", "UpdatedById", c => c.Int());
            AddColumn("dbo.Permission", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Permission", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permission", "DeletedById", c => c.Int());
            AddColumn("dbo.Permission", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.AuditLog", "CreatedById", c => c.Int());
            AddColumn("dbo.AuditLog", "UpdatedById", c => c.Int());
            AddColumn("dbo.AuditLog", "UpdatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.AuditLog", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AuditLog", "DeletedById", c => c.Int());
            AddColumn("dbo.AuditLog", "DeletedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropIndex("dbo.State", new[] { "CountryId" });
            DropIndex("dbo.City", new[] { "StateId" });
            DropColumn("dbo.AuditLog", "DeletedDate");
            DropColumn("dbo.AuditLog", "DeletedById");
            DropColumn("dbo.AuditLog", "Deleted");
            DropColumn("dbo.AuditLog", "UpdatedDate");
            DropColumn("dbo.AuditLog", "UpdatedById");
            DropColumn("dbo.AuditLog", "CreatedById");
            DropColumn("dbo.Permission", "DeletedDate");
            DropColumn("dbo.Permission", "DeletedById");
            DropColumn("dbo.Permission", "Deleted");
            DropColumn("dbo.Permission", "UpdatedDate");
            DropColumn("dbo.Permission", "UpdatedById");
            DropColumn("dbo.Permission", "CreatedById");
            DropColumn("dbo.RolePermission", "DeletedDate");
            DropColumn("dbo.RolePermission", "DeletedById");
            DropColumn("dbo.RolePermission", "Deleted");
            DropColumn("dbo.RolePermission", "UpdatedDate");
            DropColumn("dbo.RolePermission", "UpdatedById");
            DropColumn("dbo.RolePermission", "CreatedById");
            DropColumn("dbo.Role", "DeletedDate");
            DropColumn("dbo.Role", "DeletedById");
            DropColumn("dbo.Role", "Deleted");
            DropColumn("dbo.Role", "UpdatedDate");
            DropColumn("dbo.Role", "UpdatedById");
            DropColumn("dbo.Role", "CreatedById");
            DropColumn("dbo.Account", "DeletedDate");
            DropColumn("dbo.Account", "DeletedById");
            DropColumn("dbo.Account", "Deleted");
            DropColumn("dbo.Account", "UpdatedDate");
            DropColumn("dbo.Account", "UpdatedById");
            DropColumn("dbo.Account", "CreatedById");
            DropTable("dbo.Country");
            DropTable("dbo.State");
            DropTable("dbo.City");
        }
    }
}
