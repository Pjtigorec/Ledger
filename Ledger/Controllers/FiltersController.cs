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
            return PartialView(filter);
        }

        [HttpGet]
        public ActionResult FilerState(int stateId)
        {
            var state = db.Subjects.GetAllStates().Find(s => s.Id == stateId);

            if (state != null)
            {
                return PartialView(db.Subjects.GetSubjects().FindAll(s => s.StateId == state.Id));
            }

            return PartialView(db.Subjects.GetSubjects());
        }
    }
}