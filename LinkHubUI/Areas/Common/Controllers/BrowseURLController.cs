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
        public ActionResult Index(string sortOrder, string sortBy)
        {
            ViewBag.sortOrder = sortOrder;
            ViewBag.sortBy = sortBy;
            var urls = objBs.GetAll().Where(x => x.IsApproved == "A");
            switch (sortBy)
            {
                case "Title":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlTitle).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Url":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "UrlDesc":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryName":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }


            return View(urls);
        }
    }
}