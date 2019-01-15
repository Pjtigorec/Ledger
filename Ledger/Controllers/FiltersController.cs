using BusinessLogicLayer.Interfaces;
using Common.Core;
using Common.Models;
using Ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class FiltersController : Controller
    {
        IBusinessLogic db;

        public FiltersController(IBusinessLogic db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            Filters filter = new Filters();
            filter.States = db.Subjects.GetAllStates();
            filter.States.Add(new State { Id = 0, Name = "Нет" });
            return PartialView(filter);
        }

        public ActionResult GetSubjects(int id)
        {
            if(id != 0)
            {
                IEnumerable<Subject> subjects = db.Subjects.GetSubjects().Where(s => s.StateId == id);
                if(subjects.Count() == 0)
                {
                    return PartialView(db.Subjects.GetSubjects());
                }
                return PartialView(subjects);
            }

            return PartialView(db.Subjects.GetSubjects());
        }
    }
}