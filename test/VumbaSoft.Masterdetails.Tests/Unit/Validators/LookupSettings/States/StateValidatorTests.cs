using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Tests.Data;
using VumbaSoft.Masterdetails.Validators;
using System;
using Xunit;

namespace VumbaSoft.Masterdetails.Tests.Unit.Validators
{
    public class StateValidatorTests : IDisposable
    {
        private StateValidator validator;
        private TestingContext context;
        private State state;

        public StateValidatorTests()
        {
            context = new TestingContext();
            validator = new StateValidator(new UnitOfWork(context));

            context.DropData();
            SetUpData();
        }
        public void Dispose()
        {
            context.Dispose();
            validator.Dispose();
        }

        #region CanCreate(StateView view)

        [Fact]
        public void CanCreate_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanCreate(ObjectFactory.CreateStateView(1)));
        }

        [Fact]
        public void CanCreate_ValidState()
        {
            Assert.True(validator.CanCreate(ObjectFactory.CreateStateView(1)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        #endregion

        #region CanEdit(StateView view)

        [Fact]
        public void CanEdit_InvalidState_ReturnsFalse()
        {
            validator.ModelState.AddModelError("Test", "Test");

            Assert.False(validator.CanEdit(ObjectFactory.CreateStateView(state.Id)));
        }

        [Fact]
        public void CanEdit_ValidState()
        {
            Assert.True(validator.CanEdit(ObjectFactory.CreateStateView(state.Id)));
            Assert.Empty(validator.ModelState);
            Assert.Empty(validator.Alerts);
        }

        #endregion

        #region Test helpers

        private void SetUpData()
        {
            state = ObjectFactory.CreateState();

            context.Set<State>().Add(state);
            context.SaveChanges();
        }

        #endregion
    }
}
