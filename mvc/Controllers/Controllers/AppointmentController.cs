using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Repository;
using HospitalManagementNew.Models;

namespace HospitalManagementNew.Controllers
{
   
    public class AppointmentController : Controller
    {
        Appointmentrepository appointmentrepository=new Appointmentrepository();

       
        // GET: Appointment
        public ActionResult Index()
        {
           // var log = Session["login_id"] as List<Login>;

            string log =(string) Session["login_id"];
            
            //Session["login_id"] = new List<Login>();
           var book = appointmentrepository.getpatientbookind(log);

            return View(book);


        }
      

        [HttpPost]
      
        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(AppointmentModel collection)
        {
            bool isinserted = false;
            if (ModelState.IsValid)
            {
                isinserted = appointmentrepository.InsertAppointment(collection);
                if (isinserted)
                {
                    TempData["success"] = "Booked  successfully";
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    TempData["error"] = "Booked  successfully";
                }
            }
            return View();
        }

        // GET: Appointment/Edit/5
        public ActionResult Booked(int id)
        {


            var appointmentid = appointmentrepository.getbookbyid(id).FirstOrDefault();
            // var patient = Patientrepository.getpatientbyid(id).FirstOrDefault();
            if (appointmentid != null)
            {
                //TempData["success"] = "patient details entered successfully";

                return View(appointmentid);

            }
            else
            {
                //TempData["error"] = "Details not updated";
                return View();

            }
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Booked(int id, FormCollection collection)
        {
            


            return View();
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
