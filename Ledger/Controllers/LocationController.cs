using BusinessLogicLayer.Interfaces;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class LocationController : Controller
    {
        IBusinessLogic _db;

        public LocationController(IBusinessLogic db)
        {
            _db = db;
        }

        public ActionResult Location()
        {
            SelectList buildings = new SelectList(_db.Locations.GetBuildings(), "Id", "Name");
            SelectList floots = new SelectList(_db.Locations.GetFloots(1), "Id", "Name", "BuildingId");
            SelectList rooms = new SelectList(_db.Locations.GetRooms(1), "Id", "Name", "FlootId");

            ViewBag.Buildings = buildings;
            ViewBag.Floots = floots;
            ViewBag.Rooms = rooms;

            return PartialView();
        }

        public ActionResult Floots(int id)
        {
            return PartialView(_db.Locations.GetFloots(id));
        }

        public ActionResult Rooms(int id)
        {
            return PartialView(_db.Locations.GetRooms(id));
        }
    }
}