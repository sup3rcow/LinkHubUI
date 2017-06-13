using BOL;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : Controller
    {
        // GET: User/URL
        public ActionResult Index()
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");

            return View();
        }

        // POST: User/Create
        public ActionResult Create(tbl_Url objUrl)
        {

            return View();
        }
    }
}