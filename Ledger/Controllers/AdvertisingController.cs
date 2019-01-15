using Ledger.ServiceReference1;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class AdvertisingController : Controller
    {
        public ActionResult Index()
        {
            var spam = this.GetSpam();

            return PartialView();
        }

        public ActionResult GetSpam()
        {
            SpamServicesClient spam = new SpamServicesClient();

            var image = spam.GetSpam();

            return File(image.Image, image.Type);
        }
    }
}