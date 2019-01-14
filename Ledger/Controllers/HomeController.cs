using BusinessLogicLayer.Interfaces;
using Common.Core;
using Common.Models;
using Ledger.Attributes;
using Logs;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    [User]
    public class HomeController : Controller
    {
        IBusinessLogic db;

        public HomeController(IBusinessLogic db)
        {
            this.db = db;
            Logger.InitLogger();
        }

        public ActionResult Index()
        {
            Logger.Log.Info("Первый заход");
            return View(db.Subjects.GetSubjects());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Subject subject = db.Subjects.GetSubjectById(id);
            SubjectModel model = SubjectModel.ConvertSubjectToModel(subject);
            model.StateName = db.Subjects.GetSubjectState(subject.StateId).Name;
            model.RoomName = db.Locations.GetRoom(subject.RoomId).Name;

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Subject subject = db.Subjects.GetSubjectById(id);
            SubjectModel model = SubjectModel.ConvertSubjectToModel(subject);
            model.States = db.Subjects.GetAllStates();

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                Subject subject = SubjectModel.ConvertModelToSubject(model);
                subject.Id = model.Id;

                db.Subjects.Update(subject);

                return RedirectToAction("Index", "Home");
            }
            model.States = db.Subjects.GetAllStates();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            SubjectModel model = new SubjectModel();

            model.States = db.Subjects.GetAllStates();

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(SubjectModel model, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Subject subject = SubjectModel.ConvertModelToSubject(model);

                db.Subjects.Create(subject);

                return RedirectToAction("Index", "Home");
            }
            model.States = db.Subjects.GetAllStates();
            return View(model);
        }

        [Admin]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Delete(int id)
        {
            db.Subjects.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}