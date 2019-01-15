using BusinessLogicLayer.Interfaces;
using Common.Core;
using Ledger.Attributes;
using Logs;
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
            return View();
        }
        [Admin]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}