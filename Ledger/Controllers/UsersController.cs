using BusinessLogicLayer.Interfaces;
using Common.Core;
using Common.Models;
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
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _db.Users.Delete(id);
            return RedirectToAction("Index", "Users");
        }
    }
}