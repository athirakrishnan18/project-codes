using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Repository;
using HospitalManagementNew.Models;


namespace HospitalManagementNew.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }
      
    }
}