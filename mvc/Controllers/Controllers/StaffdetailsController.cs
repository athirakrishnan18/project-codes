using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Models;
using HospitalManagementNew.Repository;
using System.Data;

namespace HospitalManagementNew.Controllers
{
    public class StaffdetailsController : Controller
    {
        staffrepository Staffrepository=new staffrepository();
        // GET: Staffdetails
        public ActionResult Staffdetails()
        {
            var staff = Staffrepository.Staffdispaly();
            return View(staff);
        }

        // GET: Staffdetails/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Staffdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffdetails/Create new member
        [HttpPost]
        public ActionResult Create(Staffdetails staffdetails)
        {
            try
            {
                bool isinserted = false;
                if (ModelState.IsValid)
                {
                    isinserted = Staffrepository.InsertStaff(staffdetails);
                    if (isinserted)
                    {
                        TempData["success"] = "Patient details inserted successfully";
                    }
                    else
                    {
                        TempData["error"] = "Details not inserted";
                    }
                    return RedirectToAction("Staffdetails");
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: Staffdetails/Edit/5
        public ActionResult Edit(int id)
        {
            var staffsbyid = Staffrepository.getstaffid(id).FirstOrDefault();
            // var patient = Patientrepository.getpatientbyid(id).FirstOrDefault();
            if (staffsbyid != null)
            {
                TempData["success"] = "patient details entered successfully";

                return View(staffsbyid);

            }
            else
            {

                return View();

            }

        }

        // POST: Staffdetails/Edit/5
        [HttpPost,ActionName("Edit")]
        
       public ActionResult UpdateStaffs(Staffdetails staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = Staffrepository.UpdateStaffs(staff);
                    if (IsUpdated)
                    {
                        TempData["success"] = "Staff details updated successfully";
                    }
                    else
                    {
                        TempData["error"] = "Staff details not entered ";
                    }
                }
                return RedirectToAction("Staffdetails");
            }
            catch (Exception ex)
            {

                TempData["Infomessage"] = "Staff details not entered ";
                return View();
            }
        }

        // GET: Staffdetails/Delete/5
        public ActionResult Delete(int id)
        {
            var staff=Staffrepository.deletestaff(id);
            if(staff == null)
            {
                TempData["success"] = "Staff details deleted successfully";
            }
            return RedirectToAction("Staffdetails");
        }

        // POST: Staffdetails/Delete/5
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
