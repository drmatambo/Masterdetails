using AutoMapper;
using AutoMapper.QueryableExtensions;
using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Services;
using VumbaSoft.Masterdetails.Tests.Data;
using System;
using System.Linq;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Services
{
    public class CountryServiceTests : IDisposable
    {
        private CountryService service;
        private TestingContext context;
        private Country country;

        public CountryServiceTests()
        {
            context = new TestingContext();
            service = new CountryService(new UnitOfWork(context));

            context.DropData();
            SetUpData();
        }
        public void Dispose()
        {
            service.Dispose();
            context.Dispose();
        }

        #region Get<TView>(Int32 id)

        [Fact]
        public void Get_ReturnsViewById()
        {
            CountryView actual = service.Get<CountryView>(country.Id);
            CountryView expected = Mapper.Map<CountryView>(country);

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Id, actual.Id);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region GetViews()

        [Fact]
        public void GetViews_ReturnsCountryViews()
        {
            CountryView[] actual = service.GetViews().ToArray();
            CountryView[] expected = context
                .Set<Country>()
                .ProjectTo<CountryView>()
                .OrderByDescending(view => view.Id)
                .ToArray();

            for (Int32 i = 0; i < expected.Length || i < actual.Length; i++)
            {
                Assert.Equal(expected[i].CreationDate, actual[i].CreationDate);
                Assert.Equal(expected[i].Id, actual[i].Id);
            }

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region Create(CountryView view)

        [Fact]
        public void Create_Country()
        {
            CountryView view = ObjectFactory.CreateCountryView(1);

            service.Create(view);

            Country actual = context.Set<Country>().AsNoTracking().Single(model => model.Id != country.Id);
            CountryView expected = view;

            Assert.Equal(expected.CreationDate, actual.CreationDate);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region Edit(CountryView view)

        [Fact]
        public void Edit_Country()
        {
            CountryView view = ObjectFactory.CreateCountryView(country.Id);
            Assert.True(false, "No update made");

            service.Edit(view);

            Country actual = context.Set<Country>().AsNoTracking().Single();
            Country expected = country;

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Id, actual.Id);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region Delete(Int32 id)

        [Fact]
        public void Delete_Country()
        {
            service.Delete(country.Id);

            Assert.Empty(context.Set<Country>());
        }

        #endregion

        #region Test helpers

        private void SetUpData()
        {
            country = ObjectFactory.CreateCountry();

            using (TestingContext context = new TestingContext())
            {
                context.Set<Country>().Add(country);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
