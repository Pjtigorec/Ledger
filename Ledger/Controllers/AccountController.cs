using BusinessLogicLayer.Interfaces;
using Common.AccountModels;
using Common.Core;
using System;
using System.Security.Principal;
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

        public ActionResult ViewAccount()
        {
            User user = new User();
            user.Login = HttpContext.Request.Cookies["Login"].Value;
            user.Email = HttpContext.Request.Cookies["Email"].Value;
            user.Role = HttpContext.Request.Cookies["Role"].Value;
            return PartialView(user);
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
                    HttpContext.Response.Clear();
                    
                    FormsAuthentication.SetAuthCookie(user.Login, true);
                    AddCookie(user);

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
            ClearnCookie();
            return RedirectToAction("Index", "Home");
        }

        private void ClearnCookie()
        {
            int time = -10;
            HttpContext.Response.Cookies["Id"].Expires = DateTime.Now.AddHours(time);
            HttpContext.Response.Cookies["Login"].Expires = DateTime.Now.AddHours(time);
            HttpContext.Response.Cookies["Email"].Expires = DateTime.Now.AddHours(time);
            HttpContext.Response.Cookies["Role"].Expires = DateTime.Now.AddHours(time);
            HttpContext.Response.Clear();
        }

        private void AddCookie(User user)
        {
            HttpContext.Response.Clear();
            int time = 10;

            HttpContext.Response.Cookies["Id"].Value = user.Id.ToString();
            HttpContext.Response.Cookies["Id"].Expires = DateTime.Now.AddHours(time);

            HttpContext.Response.Cookies["Login"].Value = user.Login;
            HttpContext.Response.Cookies["Login"].Expires = DateTime.Now.AddHours(time);

            HttpContext.Response.Cookies["Email"].Value = user.Email;
            HttpContext.Response.Cookies["Email"].Expires = DateTime.Now.AddHours(time);

            HttpContext.Response.Cookies["Role"].Value = user.Role;
            HttpContext.Response.Cookies["Role"].Expires = DateTime.Now.AddHours(time);
        }
    }
}