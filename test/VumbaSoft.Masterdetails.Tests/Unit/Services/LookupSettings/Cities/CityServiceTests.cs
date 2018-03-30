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
    public class CityServiceTests : IDisposable
    {
        private CityService service;
        private TestingContext context;
        private City city;

        public CityServiceTests()
        {
            context = new TestingContext();
            service = new CityService(new UnitOfWork(context));

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
            CityView actual = service.Get<CityView>(city.Id);
            CityView expected = Mapper.Map<CityView>(city);

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Id, actual.Id);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region GetViews()

        [Fact]
        public void GetViews_ReturnsCityViews()
        {
            CityView[] actual = service.GetViews().ToArray();
            CityView[] expected = context
                .Set<City>()
                .ProjectTo<CityView>()
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

        #region Create(CityView view)

        [Fact]
        public void Create_City()
        {
            CityView view = ObjectFactory.CreateCityView(1);

            service.Create(view);

            City actual = context.Set<City>().AsNoTracking().Single(model => model.Id != city.Id);
            CityView expected = view;

            Assert.Equal(expected.CreationDate, actual.CreationDate);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region Edit(CityView view)

        [Fact]
        public void Edit_City()
        {
            CityView view = ObjectFactory.CreateCityView(city.Id);
            Assert.True(false, "No update made");

            service.Edit(view);

            City actual = context.Set<City>().AsNoTracking().Single();
            City expected = city;

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Id, actual.Id);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region Delete(Int32 id)

        [Fact]
        public void Delete_City()
        {
            service.Delete(city.Id);

            Assert.Empty(context.Set<City>());
        }

        #endregion

        #region Test helpers

        private void SetUpData()
        {
            city = ObjectFactory.CreateCity();

            using (TestingContext context = new TestingContext())
            {
                context.Set<City>().Add(city);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
