using BusinessLogicLayer.Interfaces;
using Common.Core;
using Common.Models;
using Ledger.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class SubjectController : Controller
    {
        IBusinessLogic db;

        public SubjectController(IBusinessLogic db)
        {
            this.db = db;
        }

        public ActionResult GetSubjects()
        {
            return PartialView(db.Subjects.GetSubjects());
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

        public ActionResult Delete(int id)
        {
            db.Subjects.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}