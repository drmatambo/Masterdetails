using VumbaSoft.Masterdetails.Components.Extensions;
using VumbaSoft.Masterdetails.Objects;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Objects
{
    public class RoleViewTests
    {
        #region RoleView()

        [Fact]
        public void RoleView_CreatesEmpty()
        {
            JsTree actual = new RoleView().Permissions;

            Assert.Empty(actual.SelectedIds);
            Assert.Empty(actual.Nodes);
        }

        #endregion
    }
}
