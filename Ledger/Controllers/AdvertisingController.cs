using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class AdvertisingController : Controller
    {
        // GET: Advertising
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}