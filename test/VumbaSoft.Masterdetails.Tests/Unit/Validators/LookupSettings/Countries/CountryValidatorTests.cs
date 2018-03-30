using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Tests.Data;
using VumbaSoft.Masterdetails.Validators;
using System;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Validators
{
    public class CountryValidatorTests : IDisposable
    {
        private CountryValidator validator;
        private TestingContext context;
        private Country country;

        public CountryValidatorTests()
        {
            context = new TestingContext();
            validator = new CountryValidator(new UnitOfWork(context));

            context.DropData();
            SetUpData();
        }
        public void Dispose()
        {
            context.Dispose();
            validator.Dispose();
        }

        #region CanCreate(CountryView view)

        [Fact]
        public void CanCreate_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanCreate(ObjectFactory.CreateCountryView(1)));
        }

        [Fact]
        public void CanCreate_ValidCountry()
        {
            Assert.True(validator.CanCreate(ObjectFactory.CreateCountryView(1)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        #endregion

        #region CanEdit(CountryView view)

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectFactory.CreateCountryView(country.Id)));
        }

        [Fact]
        public void CanEdit_ValidCountry()
        {
            Assert.True(validator.CanEdit(ObjectFactory.CreateCountryView(country.Id)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        #endregion

        #region Test helpers

        private void SetUpData()
        {
            country = ObjectFactory.CreateCountry();

            context.Set<Country>().Add(country);
            context.SaveChanges();
        }

        #endregion
    }
}
