using VumbaSoft.Masterdetails.Objects;
using System;
using System.Linq;

namespace VumbaSoft.Masterdetails.Services
{
    public interface ICityService : IService
    {
        TView Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CityView> GetViews();

        void Create(CityView view);
        void Edit(CityView view);
        void Delete(Int32 id);
    }
}
