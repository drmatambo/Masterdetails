using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Services;
using VumbaSoft.Masterdetails.Validators;
using System;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Controllers.LookupSettings
{
    [Area("LookupSettings")]
    public class CitiesController : ValidatedController<ICityValidator, ICityService>
    {
        public CitiesController(ICityValidator validator, ICityService service)
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
        public ActionResult Create([Bind(Exclude = "Id")] CityView city)
        {
            if (!Validator.CanCreate(city))
                return View(city);

            Service.Create(city);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<CityView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<CityView>(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityView city)
        {
            if (!Validator.CanEdit(city))
                return View(city);

            Service.Edit(city);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<CityView>(id));
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
