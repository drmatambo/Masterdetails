using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Services;
using VumbaSoft.Masterdetails.Validators;
using System;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Controllers.LookupSettings
{
    [Area("LookupSettings")]
    public class CountriesController : ValidatedController<ICountryValidator, ICountryService>
    {
        public CountriesController(ICountryValidator validator, ICountryService service)
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
        public ActionResult Create([Bind(Exclude = "Id")] CountryView country)
        {
            if (!Validator.CanCreate(country))
                return View(country);

            Service.Create(country);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryView>(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryView country)
        {
            if (!Validator.CanEdit(country))
                return View(country);

            Service.Edit(country);

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryView>(id));
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
