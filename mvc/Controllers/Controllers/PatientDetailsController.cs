using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Repository;


namespace HospitalManagementNew.Controllers
{
    public class PatientDetailsController : Controller
    {
        // GET: PatientDetails
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getallpatient()
        {
            patientrepository pr = new patientrepository();     //call to view page
            ModelState.Clear();
            return View(pr.getallpatient());
        }
    }

}