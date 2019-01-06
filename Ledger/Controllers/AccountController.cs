using BusinessLogicLayer.Interfaces;
using Common.AccountModels;
using Common.Core;
using System.Web.Mvc;
using System.Web.Security;

namespace Ledger.Controllers
{
    public class AccountController : Controller
    {
        IBusinessLogic _db;

        public AccountController(IBusinessLogic db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = _db.Accounts.Login.LoginUser(model);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}