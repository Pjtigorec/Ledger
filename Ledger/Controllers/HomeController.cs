using BusinessLogicLayer.Interfaces;
using Common.Core;
using Common.Interfaces;
using Common.Models;
using Ledger.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    [User]
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
            Subject subject = _db.Subjects.GetSubjectById(id);
            SubjectModel model = SubjectModel.ConvertSubjectToModel(subject);
            model.StateName = _db.Subjects.GetSubjectState(subject.StateId).Name;
            model.RoomName = _db.Locations.GetRoom(subject.RoomId).Name;

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Subject subject = _db.Subjects.GetSubjectById(id);
            SubjectModel model = SubjectModel.ConvertSubjectToModel(subject);
            model.States = _db.Subjects.GetAllStates();

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                Subject subject = SubjectModel.ConvertModelToSubject(model);
                subject.Id = model.Id;

                _db.Subjects.Update(subject);

                return RedirectToAction("Index", "Home");
            }
            model.States = _db.Subjects.GetAllStates();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            SubjectModel model = new SubjectModel();

            model.States = _db.Subjects.GetAllStates();

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                Subject subject = SubjectModel.ConvertModelToSubject(model);

                _db.Subjects.Create(subject);

                return RedirectToAction("Index", "Home");
            }
            model.States = _db.Subjects.GetAllStates();
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
            _db.Subjects.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}