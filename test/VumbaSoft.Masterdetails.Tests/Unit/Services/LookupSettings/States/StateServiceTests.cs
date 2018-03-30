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
    public class StateServiceTests : IDisposable
    {
        private StateService service;
        private TestingContext context;
        private State state;

        public StateServiceTests()
        {
            context = new TestingContext();
            service = new StateService(new UnitOfWork(context));

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
            StateView actual = service.Get<StateView>(state.Id);
            StateView expected = Mapper.Map<StateView>(state);

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Id, actual.Id);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region GetViews()

        [Fact]
        public void GetViews_ReturnsStateViews()
        {
            StateView[] actual = service.GetViews().ToArray();
            StateView[] expected = context
                .Set<State>()
                .ProjectTo<StateView>()
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

        #region Create(StateView view)

        [Fact]
        public void Create_State()
        {
            StateView view = ObjectFactory.CreateStateView(1);

            service.Create(view);

            State actual = context.Set<State>().AsNoTracking().Single(model => model.Id != state.Id);
            StateView expected = view;

            Assert.Equal(expected.CreationDate, actual.CreationDate);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region Edit(StateView view)

        [Fact]
        public void Edit_State()
        {
            StateView view = ObjectFactory.CreateStateView(state.Id);
            Assert.True(false, "No update made");

            service.Edit(view);

            State actual = context.Set<State>().AsNoTracking().Single();
            State expected = state;

            Assert.Equal(expected.CreationDate, actual.CreationDate);
            Assert.Equal(expected.Id, actual.Id);

            Assert.True(false, "Not all properties tested");
        }

        #endregion

        #region Delete(Int32 id)

        [Fact]
        public void Delete_State()
        {
            service.Delete(state.Id);

            Assert.Empty(context.Set<State>());
        }

        #endregion

        #region Test helpers

        private void SetUpData()
        {
            state = ObjectFactory.CreateState();

            using (TestingContext context = new TestingContext())
            {
                context.Set<State>().Add(state);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
