using VumbaSoft.Masterdetails.Components.Mvc;
using VumbaSoft.Masterdetails.Objects;
using VumbaSoft.Masterdetails.Services;
using VumbaSoft.Masterdetails.Validators;
using System;
using System.Web.Mvc;

namespace VumbaSoft.Masterdetails.Controllers.Administration
{
    [Area("Administration")]
    public class AccountsController : ValidatedController<IAccountValidator, IAccountService>
    {
        public AccountsController(IAccountValidator validator, IAccountService service)
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
        public ActionResult Create([Bind(Exclude = "Id")] AccountCreateView account)
        {
            if (!Validator.CanCreate(account))
                return View(account);

            Service.Create(account);

            AuthorizationProvider?.Refresh();

            return RedirectIfAuthorized("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<AccountView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<AccountEditView>(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountEditView account)
        {
            if (!Validator.CanEdit(account))
                return View(account);

            Service.Edit(account);

            AuthorizationProvider?.Refresh();

            return RedirectIfAuthorized("Index");
        }
    }
}
