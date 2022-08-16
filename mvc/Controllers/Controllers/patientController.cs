using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Repository;
using HospitalManagementNew.Models;
using System.Data;


namespace HospitalManagementNew.Controllers
{
    public class patientController : Controller
    {
        patientrepository Patientrepository=new patientrepository();        //to access all repository contents




        // GET: patient
        public ActionResult Index()
        {
            var patientlist = Patientrepository.getallpatient();
            return View(patientlist);
        }

        // GET: patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patient/Create
        [HttpPost]
        public ActionResult Create(patientmodel patient)
        {

            try
            {
                bool IsInserted = false;

                if (ModelState.IsValid)
                {
                    IsInserted = Patientrepository.InsertPatient(patient);
                    if (IsInserted)
                    {
                        TempData["success"] = "Patient details inserted successfully";
                    }
                    else
                    {
                        TempData["error"] = "Details not inserted";
                    }
                    
                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {

                TempData["error"] =ex.Message;
                return View();
            }

            

        }





        // GET: patient/Edit/5

        public ActionResult Edit(int id)
        {
   

           var patientsbyid=Patientrepository.getpatientbyid(id).FirstOrDefault();
            // var patient = Patientrepository.getpatientbyid(id).FirstOrDefault();
            if (patientsbyid != null)
            {
                //TempData["success"] = "patient details entered successfully";

                return View(patientsbyid);
               
            }
            else {
                //TempData["error"] = "Details not updated";
                return View();
           
            }
 
        }

        // POST: patient/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult UpdatePatient(patientmodel patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = Patientrepository.UpdatePatient(patient);
                    if (IsUpdated)
                    {
                        TempData["success"] = "patient details updated successfully";
                    }
                    else
                    {
                        TempData["error"] = "patient details not entered ";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["Infomessage"] = "patient details not entered ";
                return View();
            }

        }

        // GET: patient/Delete/5
        public ActionResult Delete(int id)
        {
          
            try
         {
             var patientdetails = Patientrepository.deletepatient(id);
             if (patientdetails == null)
             {
                 TempData["Infomessage"] = "patient details not found.Please check" + id.ToString();
                 return RedirectToAction("Index");
             }

                return RedirectToAction("Index");
            }
         catch (Exception ex)
         {

             TempData["Infomessage"] = "patient details not entered ";
             return View();
         }

    }

        // POST: patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
              // TODO: Add delete logic here

                return RedirectToAction("Index");
           
            
        }
    }
}
