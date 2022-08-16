using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementNew.Models
{
    public class BookedPatientsMode
    {
        [DisplayName("Booking Id")]
        [Required]
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

        public int phone_no { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Doctor")]
        [Required]
        public string doctor { get; set; }
        [Required]
        [DisplayName("Email Id")]
        public string emailid { get; set; }
        [DisplayName("Date Of Booking")]
        public DateTime datebooked { get; set; }
        [DisplayName("Department")]
        [Required]
        public string dept { get; set; }
        [DisplayName("Status")]
        public string userstatus { get; set; }
        

        



    }
}