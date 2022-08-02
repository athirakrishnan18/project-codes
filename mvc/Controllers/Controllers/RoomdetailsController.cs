using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Repository;
using HospitalManagementNew.Models;

namespace HospitalManagementNew.Controllers
{
    public class RoomdetailsController : Controller
    {
        roomdetailsrepository Roomdetailsrepository=new roomdetailsrepository();
        // GET: Roomdetails
        public ActionResult Roomdetailsdispaly()
        {
            var room=Roomdetailsrepository.Roomdetailsdispaly();
            return View(room);
        }

        // GET: Roomdetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roomdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roomdetails/Create
        [HttpPost]
        public ActionResult Create(Roomdetailsmodel room)
        {
            try
            {
                bool isinserted = false;
                {
                    if (ModelState.IsValid)
                    {
                        isinserted = Roomdetailsrepository.InsertRoom(room);
                        if (isinserted)
                        {
                            TempData["success"] = "Room details inserted successfully";
                        }
                        else
                        {
                            TempData["error"] = "Room details not inserted";
                        }

                        return RedirectToAction("Roomdetailsdispaly");
                    }
                    return View();
                    
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: Roomdetails/Edit/5
        public ActionResult Edit(int id)
        {
            var roombyid=Roomdetailsrepository.getroombyid(id).FirstOrDefault();
            if (roombyid != null)
            {
                TempData["success"] = "Room details entered successfully";

                return View(roombyid);
            }
            else
            {
                return View();
            }
           
        }

        // POST: Roomdetails/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult UpdateRooms(Roomdetailsmodel room)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isupdated = Roomdetailsrepository.UpdateRooms(room);
                    if (isupdated)
                    {
                        TempData["success"] = "Room details updated successfully";

                    }
                    else
                    {
                        TempData["error"] = "Room details not entered ";
                    }
                    return RedirectToAction("Roomdetailsdispaly");
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Roomdetails/Delete/5
        public ActionResult Delete(int id)
        {
            var room = Roomdetailsrepository.deleteroom(id);
            if (room != null)
            {
                TempData["success"] = "Staff details deleted successfully";
            }
            return RedirectToAction("Staffdetails");
        }

        // POST: Roomdetails/Delete/5
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
