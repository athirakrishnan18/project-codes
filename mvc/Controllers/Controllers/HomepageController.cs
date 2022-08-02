using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementNew.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult HomeIndex()
        {
            return View();
        }
    }
}