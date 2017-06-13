using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    public class LoginController : Controller
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }
    }
}