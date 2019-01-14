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

        [HttpGet]
        public ActionResult Index()
        {
            Filters filter = new Filters();
            filter.States = db.Subjects.GetAllStates();
            filter.Buildings = db.Locations.GetBuildings();
            return PartialView(filter);
        }
        [HttpPost]
        public ActionResult Index(string state, string buildings)
        {
            return RedirectToAction("Index", "Home", new List<Subject>());
        }
    }
}