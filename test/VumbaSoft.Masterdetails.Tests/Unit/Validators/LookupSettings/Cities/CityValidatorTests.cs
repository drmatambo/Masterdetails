using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Tests.Data;
using VumbaSoft.Masterdetails.Validators;
using System;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Validators
{
    public class CityValidatorTests : IDisposable
    {
        private CityValidator validator;
        private TestingContext context;
        private City city;

        public CityValidatorTests()
        {
            context = new TestingContext();
            validator = new CityValidator(new UnitOfWork(context));

            context.DropData();
            SetUpData();
        }
        public void Dispose()
        {
            context.Dispose();
            validator.Dispose();
        }

        #region CanCreate(CityView view)

        [Fact]
        public void CanCreate_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanCreate(ObjectFactory.CreateCityView(1)));
        }

        [Fact]
        public void CanCreate_ValidCity()
        {
            Assert.True(validator.CanCreate(ObjectFactory.CreateCityView(1)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        #endregion

        #region CanEdit(CityView view)

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectFactory.CreateCityView(city.Id)));
        }

        [Fact]
        public void CanEdit_ValidCity()
        {
            Assert.True(validator.CanEdit(ObjectFactory.CreateCityView(city.Id)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        #endregion

        #region Test helpers

        private void SetUpData()
        {
            city = ObjectFactory.CreateCity();

            context.Set<City>().Add(city);
            context.SaveChanges();
        }

        #endregion
    }
}
