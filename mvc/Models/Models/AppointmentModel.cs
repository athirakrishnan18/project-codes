﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementNew.Models
{
    public class AppointmentModel
    {
        [DisplayName("Booking Id")]
        public int bookid { get; set; }
        [Required]
        [DisplayName("Name")]
        public string patientname { get; set; }
        [Required]
        [DisplayName("Address")]
        public string patientaddress { get; set; }
        [Required]
       
        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        [Required]
        [DisplayName("Age")]
        public int age { get; set; }
        [Required]
        [DisplayName("Phone No.")]
     
        public int phoneno { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string gender { get; set; }

        [Required]
        [DisplayName("Username")]
        public string emailid { get; set; }


        [Required]
        [DisplayName("Password")]
        public string password { get; set; }


        [Required]
        [DisplayName("Department")]
        public string dept { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of Booking")]
        public DateTime datebooked { get; set; }

        public string type { get; set; }
        [DisplayName("Doctors")]
        
        public string doctors { get; set; }
        [DisplayName("Booking Status")]
        public string userstatus    { get; set; }


    }
}