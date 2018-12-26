using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using Common.Models;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class HomeController : Controller
    {
        IBusinessLogic _db;

        public HomeController(IBusinessLogic db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Subjects.GetSubjects());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return PartialView(_db.Subjects.GetSubjectById(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new SubjectModel());
        }
        [HttpPost]
        public ActionResult Edit(SubjectModel subject)
        {
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(SubjectModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}