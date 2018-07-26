using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stromatolite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }
    }
}