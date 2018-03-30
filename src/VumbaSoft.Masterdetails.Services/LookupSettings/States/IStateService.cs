using VumbaSoft.Masterdetails.Objects;
using System;
using System.Linq;

namespace VumbaSoft.Masterdetails.Services
{
    public interface IStateService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<StateView> GetViews();

        void Create(StateView view);
        void Edit(StateView view);
        void Delete(Int32 id);
    }
}
