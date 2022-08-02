﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementNew.Models;
using System.Data;
using HospitalManagementNew.Repository;
using System.Web.Security;



namespace HospitalManagementNew.Controllers
{
   
    public class LoginController : Controller
    {

        LoginRepository loginrepository = new LoginRepository();
        // GET: Login
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        
        public ActionResult Login(Login login)  //role based login check
        {
            try
            {
                var roles = loginrepository.Logincheck(login);
                if (roles[0].role.ToString() != "user")
                {
                    TempData["success"] = "Login successfully";
                    return RedirectToAction("Index","patient");     //redirecting to patiemt view page
                }
                else
                {
                    if (roles[0].role.ToString() != "admin") {
                        TempData["error"] = "welcome user";
                       // Session["login_id"]=roles[0].login_id.ToString();
                    return RedirectToAction("userlogin", "Login");
                }
                }
                //return RedirectToAction("Index", patientmodel);
                return View(login);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult userlogin(Login login)
        {
            return View();
        }


    }



}
