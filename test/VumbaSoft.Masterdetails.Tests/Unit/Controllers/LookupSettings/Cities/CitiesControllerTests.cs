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
    public class CitiesControllerTests : ControllerTests
    {
        private CitiesController controller;
        private ICityValidator validator;
        private ICityService service;
        private CityView city;

        public CitiesControllerTests()
        {
            validator = Substitute.For<ICityValidator>();
            service = Substitute.For<ICityService>();

            city = ObjectFactory.CreateCityView();

            controller = Substitute.ForPartsOf<CitiesController>(validator, service);
            controller.ControllerContext = new ControllerContext { RouteData = new RouteData() };
        }

        #region Index()

        [Fact]
        public void Index_ReturnsCityViews()
        {
            service.GetViews().Returns(new CityView[0].AsQueryable());

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

        #region Create(CityView city)

        [Fact]
        public void Create_ProtectsFromOverpostingId()
        {
            ProtectsFromOverposting(controller, "Create", "Id");
        }

        [Fact]
        public void Create_CanNotCreate_ReturnsSameView()
        {
            validator.CanCreate(city).Returns(false);

            Object actual = (controller.Create(city) as ViewResult).Model;
            Object expected = city;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_City()
        {
            validator.CanCreate(city).Returns(true);

            controller.Create(city);

            service.Received().Create(city);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(city).Returns(true);

            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.Create(city);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Details(Int32 id)

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<CityView>(city.Id).Returns(city);

            Object expected = NotEmptyView(controller, city);
            Object actual = controller.Details(city.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Edit(Int32 id)

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<CityView>(city.Id).Returns(city);

            Object expected = NotEmptyView(controller, city);
            Object actual = controller.Edit(city.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Edit(CityView city)

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(city).Returns(false);

            Object actual = (controller.Edit(city) as ViewResult).Model;
            Object expected = city;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_City()
        {
            validator.CanEdit(city).Returns(true);

            controller.Edit(city);

            service.Received().Edit(city);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(city).Returns(true);

            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.Edit(city);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Delete(Int32 id)

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<CityView>(city.Id).Returns(city);

            Object expected = NotEmptyView(controller, city);
            Object actual = controller.Delete(city.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region DeleteConfirmed(Int32 id)

        [Fact]
        public void DeleteConfirmed_DeletesCity()
        {
            controller.DeleteConfirmed(city.Id);

            service.Received().Delete(city.Id);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex()
        {
            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.DeleteConfirmed(city.Id);

            Assert.Same(expected, actual);
        }

        #endregion
    }
}
