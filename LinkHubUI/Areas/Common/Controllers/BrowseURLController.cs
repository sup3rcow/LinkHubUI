using BLL;
using System.Linq;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLController : Controller
    {
        private UrlBs objBs;
        public BrowseURLController()
        {
            objBs = new UrlBs();
        }
        // GET: Common/BrowseURL
        public ActionResult Index()
        {
            var urls = objBs.GetAll().Where(x => x.IsApproved == "A").ToList();
            return View(urls);
        }
    }
}