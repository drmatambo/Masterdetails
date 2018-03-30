using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using System;
using System.Linq;

namespace VumbaSoft.Masterdetails.Services
{
    public class StateService : BaseService, IStateService
    {
        public StateService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<State, TView>(id);
        }
        public IQueryable<StateView> GetViews()
        {
            return UnitOfWork
                .Select<State>()
                .To<StateView>()
                .OrderByDescending(state => state.Id);
        }

        public void Create(StateView view)
        {
            State state = UnitOfWork.To<State>(view);

            UnitOfWork.Insert(state);
            UnitOfWork.Commit();
        }
        public void Edit(StateView view)
        {
            State state = UnitOfWork.To<State>(view);

            UnitOfWork.Update(state);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<State>(id);
            UnitOfWork.Commit();
        }
    }
}
