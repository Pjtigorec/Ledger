using BusinessLogicLayer.Interfaces;
using Common.Core;
using Common.Models;
using System.Collections.Generic;
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
            ViewBag.Name = User.Identity.Name;
            return View(_db.Subjects.GetSubjects());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Subject subject = _db.Subjects.GetSubjectById(id);
            SubjectModel subjectModel = new SubjectModel
            {
                Id = subject.Id,
                Name = subject.Name,
                InventoryNumber = subject.InventoryNumber,
                Description = subject.Description,
                StateId = _db.Subjects.GetSubjectState(subject.StateId).Id,
                Room = _db.Locations.GetRoom(subject.RoomId)
            };
            return PartialView(subjectModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Subject subject = _db.Subjects.GetSubjectById(id);
            SubjectModel model = new SubjectModel
            {
                Id = subject.Id,
                Name = subject.Name,
                InventoryNumber = subject.InventoryNumber,
                Description = subject.Description,
                StateId = _db.Subjects.GetSubjectState(subject.StateId).Id,
                States = _db.Subjects.GetAllStates(),
                Room = _db.Locations.GetRoom(subject.RoomId)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                Subject subject = new Subject();

                subject.Name = model.Name;
                subject.InventoryNumber = model.InventoryNumber;
                subject.Description = model.Description;
                subject.StateId = model.StateId;
                subject.RoomId = model.Room.Id;

                _db.Subjects.Create(subject);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            SubjectModel model = new SubjectModel();

            List<State> states = _db.Subjects.GetAllStates();
            model.States = states;

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                Subject subject = new Subject();

                subject.Name = model.Name;
                subject.InventoryNumber = model.InventoryNumber;
                subject.Description = model.Description;
                subject.StateId = model.StateId;
                subject.RoomId = model.Room.Id;

                _db.Subjects.Create(subject);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

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