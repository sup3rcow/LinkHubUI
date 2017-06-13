using BLL;
using System;
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
        public ActionResult Index(string sortOrder, string sortBy, string page)
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
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();//ovo ce se dogoditi kad se stranica prvi put ucita
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.GetAll().Where(x => x.IsApproved == "A").Count() / 10.0);//imat ces 10 rekorda po stranici

            int pageNumber = int.Parse(page == null ? "1" : page);
            ViewBag.Page = pageNumber;//ovo ti treba da znas ako mijenjas sortiranje dok si na npr 2. stranici

            urls = urls.Skip((pageNumber - 1)*10).Take(10);

            return View(urls);
        }
    }
}