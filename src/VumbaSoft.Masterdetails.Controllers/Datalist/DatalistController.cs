using Datalist;
using VumbaSoft.Masterdetails.Components.Datalists;
using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Components.Security;
using VumbaSoft.Masterdetails.Data.Core;
using VumbaSoft.Masterdetails.Objects;
using System;
using System.Web.Mvc;
using System.Web.SessionState;

namespace VumbaSoft.Masterdetails.Controllers
{
    [AllowUnauthorized]
    [SessionState(SessionStateBehavior.ReadOnly)]
    public class DatalistController : BaseController
    {
        private IUnitOfWork UnitOfWork { get; }

        public DatalistController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [NonAction]
        public virtual JsonResult GetData(MvcDatalist datalist, DatalistFilter filter)
        {
            datalist.Filter = filter;

            return Json(datalist.GetData(), JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        public JsonResult Role(DatalistFilter filter)
        {
            return GetData(new MvcDatalist<Role, RoleView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult Country(DatalistFilter filter)
        {
            return GetData(new MvcDatalist<Country, CountryView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult State(DatalistFilter filter)
        {
            return GetData(new MvcDatalist<State, StateView>(UnitOfWork), filter);
        }

        [AjaxOnly]
        public JsonResult City(DatalistFilter filter)
        {
            return GetData(new MvcDatalist<City, CityView>(UnitOfWork), filter);
        }


        protected override void Dispose(Boolean disposing)
        {
            UnitOfWork.Dispose();

            base.Dispose(disposing);
        }
    }
}
