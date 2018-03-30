using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Services;
using VumbaSoft.Masterdetails.Validators;
using System;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Controllers.LookupSettings
{
    [Area("LookupSettings")]
    public class StatesController : ValidatedController<IStateValidator, IStateService>
    {
        public StatesController(IStateValidator validator, IStateService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(Service.GetViews());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")] StateView state)
        {
            if (!Validator.CanCreate(state))
                return View(state);

            Service.Create(state);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<StateView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<StateView>(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StateView state)
        {
            if (!Validator.CanEdit(state))
                return View(state);

            Service.Edit(state);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<StateView>(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Service.Delete(id);

            return RedirectIfAuthorized("Index");
        }
    }
}
