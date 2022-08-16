using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Repository;
using HospitalManagementNew.Models;

namespace HospitalManagementNew.Controllers
{
    public class BookedUserController : Controller
    {
        BookedRepository bookedRepository=new BookedRepository();
        // GET: BookedUser
        public ActionResult Index()
        {
            var booked=bookedRepository.getbookedpatients();
            return View(booked);
        }

        // GET: BookedUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookedUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookedUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookedUser/Edit/5
        public ActionResult Edit(int id)
       {
            var patientsbyid = bookedRepository.getbookpatientbyid(id).FirstOrDefault();
           
            if (patientsbyid != null)
            {
                //TempData["success"] = "patient details entered successfully";

                return View(patientsbyid);

            }
            else
            {
                //TempData["error"] = "Details not updated";
                return View();

            }
        }

        // POST: BookedUser/Edit/5
        [HttpPost]
        public ActionResult Edit(BookedPatientsMode bookedPatientsMode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = bookedRepository.ConfirmBooking(bookedPatientsMode);
                    if (IsUpdated)
                    {
                        TempData["success"] = "patient Booking confirmed";
                        return RedirectToAction("Index", "BookedUser");
                    }
                    else
                    {
                        TempData["error"] = "patient details rejected ";
                    }
                    
                }
               return View();
            }
            catch (Exception ex)
            {

                TempData["Infomessage"] = "patient details not entered ";
                return View();
            }
        }

        // GET: BookedUser/Delete/5
        public ActionResult Delete(int id)
        {
            /*var patientsbyid = bookedRepository.getbookpatientbyid(id).FirstOrDefault();

            if (patientsbyid != null)
            {
                //TempData["success"] = "patient details entered successfully";

                return View(patientsbyid);

            }
            else
            {
                //TempData["error"] = "Details not updated";
                

            }*/
return View();
        }

        // POST: BookedUser/Delete/5
        [HttpPost]
        public ActionResult Delete(BookedPatientsMode bookedPatientsMode)
        {
         /*   try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = bookedRepository.CancelBooking(bookedPatientsMode);
                    if (IsUpdated)
                    {
                        TempData["success"] = "patient Booking cancelled";
                        return RedirectToAction("Index", "BookedUser");
                    }
                    else
                    {
                        TempData["error"] = "patient details rejected ";
                    }

                }
                return View();
            }
            catch (Exception ex)
            {

                TempData["Infomessage"] = "patient details not entered ";
                
            }*/
return View();
        }
       

        public ActionResult Cancel(int id)
        {
            var patientsbyid = bookedRepository.getbookpatientbyid(id).FirstOrDefault();

            if (patientsbyid != null)
            {
                //TempData["success"] = "patient details entered successfully";

                return View(patientsbyid);

            }
            else
            {
                //TempData["error"] = "Details not updated";
               
            } 
return View();

        }
        [HttpPost]

        public ActionResult Cancel(BookedPatientsMode bookedPatientsMode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = bookedRepository.CancelBooking(bookedPatientsMode);
                    if (IsUpdated)
                    {
                        TempData["success"] = "patient Booking cancelled";
                        return RedirectToAction("Index", "BookedUser");
                    }
                    else
                    {
                        TempData["error"] = "patient details rejected ";
                    }

                }
                return View();
            }
            catch (Exception ex)
            {

                TempData["Infomessage"] = "patient details not entered ";
                return View();
            }
        }








    }
}
