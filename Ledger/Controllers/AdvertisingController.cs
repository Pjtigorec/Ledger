using Ledger.Models;
using Ledger.SpamServices;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class AdvertisingController : Controller
    {
        // GET: Advertising
        public ActionResult Index()
        {
            SpamClient spam = new SpamClient();
            Spam model = new Spam { Text = spam.GetSpam(), Href = "#" };
            return PartialView(model);
        }
    }
}