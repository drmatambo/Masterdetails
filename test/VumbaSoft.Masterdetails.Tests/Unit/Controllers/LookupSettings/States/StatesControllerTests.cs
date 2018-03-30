using VumbaSoft.Masterdetails.Controllers.LookupSettings;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Services;
using VumbaSoft.Masterdetails.Validators;
using NSubstitute;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Controllers.LookupSettings
{
    public class StatesControllerTests : ControllerTests
    {
        private StatesController controller;
        private IStateValidator validator;
        private IStateService service;
        private StateView state;

        public StatesControllerTests()
        {
            validator = Substitute.For<IStateValidator>();
            service = Substitute.For<IStateService>();

            state = ObjectFactory.CreateStateView();

            controller = Substitute.ForPartsOf<StatesController>(validator, service);
            controller.ControllerContext = new ControllerContext { RouteData = new RouteData() };
        }

        #region Index()

        [Fact]
        public void Index_ReturnsStateViews()
        {
            service.GetViews().Returns(new StateView[0].AsQueryable());

            Object actual = controller.Index().Model;
            Object expected = service.GetViews();

            Assert.Same(expected, actual);
        }

        #endregion

        #region Create()

        [Fact]
        public void Create_ReturnsEmptyView()
        {
            ViewResult actual = controller.Create();

            Assert.Null(actual.Model);
        }

        #endregion

        #region Create(StateView state)

        [Fact]
        public void Create_ProtectsFromOverpostingId()
        {
            ProtectsFromOverposting(controller, "Create", "Id");
        }

        [Fact]
        public void Create_CanNotCreate_ReturnsSameView()
        {
            validator.CanCreate(state).Returns(false);

            Object actual = (controller.Create(state) as ViewResult).Model;
            Object expected = state;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_State()
        {
            validator.CanCreate(state).Returns(true);

            controller.Create(state);

            service.Received().Create(state);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(state).Returns(true);

            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.Create(state);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Details(Int32 id)

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<StateView>(state.Id).Returns(state);

            Object expected = NotEmptyView(controller, state);
            Object actual = controller.Details(state.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Edit(Int32 id)

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<StateView>(state.Id).Returns(state);

            Object expected = NotEmptyView(controller, state);
            Object actual = controller.Edit(state.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Edit(StateView state)

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(state).Returns(false);

            Object actual = (controller.Edit(state) as ViewResult).Model;
            Object expected = state;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_State()
        {
            validator.CanEdit(state).Returns(true);

            controller.Edit(state);

            service.Received().Edit(state);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(state).Returns(true);

            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.Edit(state);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Delete(Int32 id)

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<StateView>(state.Id).Returns(state);

            Object expected = NotEmptyView(controller, state);
            Object actual = controller.Delete(state.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region DeleteConfirmed(Int32 id)

        [Fact]
        public void DeleteConfirmed_DeletesState()
        {
            controller.DeleteConfirmed(state.Id);

            service.Received().Delete(state.Id);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex()
        {
            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.DeleteConfirmed(state.Id);

            Assert.Same(expected, actual);
        }

        #endregion
    }
}
