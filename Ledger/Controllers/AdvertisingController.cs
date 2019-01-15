using Ledger.Models;
using Ledger.SpamServices;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class AdvertisingController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult GetSpam()
        {
            SpamServiceClient spam = new SpamServiceClient();

            var image = spam.GetSpam();

            return File(image.Image, image.Type);
        }
    }
}