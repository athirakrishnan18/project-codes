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

        // GET: Appointment/Edit/Select patients based on id
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

        // POST: Appointment/Booking for appointment/5
        [HttpPost]
        public ActionResult Booked(AppointmentModel appointmentModel)
        {
            //var list = new List<string>() { " Dr.Hari Ortology", "Dr.Maya Cardiology", "Dr.Sruthi Neurology", "Dr.Biji Gastrology" };
            // ViewBag.list=list;

            try
            {
                bool IsInserted = false;
                if (ModelState.IsValid)
                {
                    IsInserted = appointmentrepository.BookAppointmentStatus(appointmentModel);
                    if (IsInserted)
                    {
                        TempData["success"] = "Appoinment done successfully";
                        return RedirectToAction("Index", "Appointment");
                    }
                    else
                    {
                        TempData["success"] = "Appoinment not done successfully";
                    }

                }

                return View();

            }
            catch (Exception)
            {

                throw;
            }


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

        //For displaying user status
        public ActionResult CheckStatus(int id)
        {


            var bookid = appointmentrepository.getstatusbyid(id).FirstOrDefault();
          
            if (bookid != null)
            {
                //TempData["success"] = "patient details entered successfully";

                return View(bookid);

            }
            else
            {
                //TempData["error"] = "Details not updated";
                return View();

            }
        }


    }
}
