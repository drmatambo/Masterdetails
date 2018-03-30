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
    public class CountriesControllerTests : ControllerTests
    {
        private CountriesController controller;
        private ICountryValidator validator;
        private ICountryService service;
        private CountryView country;

        public CountriesControllerTests()
        {
            validator = Substitute.For<ICountryValidator>();
            service = Substitute.For<ICountryService>();

            country = ObjectFactory.CreateCountryView();

            controller = Substitute.ForPartsOf<CountriesController>(validator, service);
            controller.ControllerContext = new ControllerContext { RouteData = new RouteData() };
        }

        #region Index()

        [Fact]
        public void Index_ReturnsCountryViews()
        {
            service.GetViews().Returns(new CountryView[0].AsQueryable());

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

        #region Create(CountryView country)

        [Fact]
        public void Create_ProtectsFromOverpostingId()
        {
            ProtectsFromOverposting(controller, "Create", "Id");
        }

        [Fact]
        public void Create_CanNotCreate_ReturnsSameView()
        {
            validator.CanCreate(country).Returns(false);

            Object actual = (controller.Create(country) as ViewResult).Model;
            Object expected = country;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Create_Country()
        {
            validator.CanCreate(country).Returns(true);

            controller.Create(country);

            service.Received().Create(country);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            validator.CanCreate(country).Returns(true);

            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.Create(country);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Details(Int32 id)

        [Fact]
        public void Details_ReturnsNotEmptyView()
        {
            service.Get<CountryView>(country.Id).Returns(country);

            Object expected = NotEmptyView(controller, country);
            Object actual = controller.Details(country.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Edit(Int32 id)

        [Fact]
        public void Edit_ReturnsNotEmptyView()
        {
            service.Get<CountryView>(country.Id).Returns(country);

            Object expected = NotEmptyView(controller, country);
            Object actual = controller.Edit(country.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Edit(CountryView country)

        [Fact]
        public void Edit_CanNotEdit_ReturnsSameView()
        {
            validator.CanEdit(country).Returns(false);

            Object actual = (controller.Edit(country) as ViewResult).Model;
            Object expected = country;

            Assert.Same(expected, actual);
        }

        [Fact]
        public void Edit_Country()
        {
            validator.CanEdit(country).Returns(true);

            controller.Edit(country);

            service.Received().Edit(country);
        }

        [Fact]
        public void Edit_RedirectsToIndex()
        {
            validator.CanEdit(country).Returns(true);

            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.Edit(country);

            Assert.Same(expected, actual);
        }

        #endregion

        #region Delete(Int32 id)

        [Fact]
        public void Delete_ReturnsNotEmptyView()
        {
            service.Get<CountryView>(country.Id).Returns(country);

            Object expected = NotEmptyView(controller, country);
            Object actual = controller.Delete(country.Id);

            Assert.Same(expected, actual);
        }

        #endregion

        #region DeleteConfirmed(Int32 id)

        [Fact]
        public void DeleteConfirmed_DeletesCountry()
        {
            controller.DeleteConfirmed(country.Id);

            service.Received().Delete(country.Id);
        }

        [Fact]
        public void DeleteConfirmed_RedirectsToIndex()
        {
            Object expected = RedirectIfAuthorized(controller, "Index");
            Object actual = controller.DeleteConfirmed(country.Id);

            Assert.Same(expected, actual);
        }

        #endregion
    }
}
