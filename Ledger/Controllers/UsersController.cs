using BusinessLogicLayer.Interfaces;
using Common.AccountModels;
using Common.Core;
using Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class UsersController : Controller
    {
        IBusinessLogic _db;

        public UsersController(IBusinessLogic db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Users.GetUsers());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = _db.Users.GetUserById(id);
            UserModel model = new UserModel
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Role = user.Role
            };
            model.Roles = new List<string> { "User", "Moderator", "Admin" };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid && _db.Accounts.Register.CheckLoginForRegister(model.Login))
            {
                User user = UserModel.ConvertModelToUser(model);
                _db.Users.Update(user);
                return RedirectToAction("Index", "Users");
            }
            model.Roles = new List<string> { "User", "Moderator", "Admin" };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            UserModel model = new UserModel();
            model.Roles = new List<string> { "User", "Moderator", "Admin" };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            if (ModelState.IsValid && _db.Accounts.Register.CheckLoginForRegister(model.Login))
            {
                User user = UserModel.ConvertModelToUser(model);
                _db.Users.Create(user);
                return RedirectToAction("Index", "Users");
            }
            model.Roles = new List<string> { "User", "Moderator", "Admin" };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _db.Users.Delete(id);
            return RedirectToAction("Index", "Users");
        }
    }
}