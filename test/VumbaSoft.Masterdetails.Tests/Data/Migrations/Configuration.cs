using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace VumbaSoft.Masterdetails.Tests.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    internal sealed class Configuration : DbMigrationsConfiguration<TestingContext>
    {
        public Configuration()
        {
            MigrationsDirectory = "Data\\Migrations";
            ContextKey = "TestingContext";
        }
    }
}
