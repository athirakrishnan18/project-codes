using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementNew.Models
{
    public class patientmodel       //creating model class for grtting details
    {
        [Key]
        [DisplayName("Id")]
        public int regid { get; set; }
        [Required]
        [DisplayName("Name")]
        public string p_name { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string gender { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public string dob { get; set; }
        [Required]
        [DisplayName("Address")]
        public string p_address { get; set; }
        [Required]
        [DisplayName("City")]
        public string city { get; set; }
        [Required]
        [DisplayName("Contact No.")]
        public int contact_no { get; set; }
        [Required]
        [DisplayName("Email Id")]
        public string email_id { get; set; }
        [Required]
        [DisplayName("Department")]
        public string dept { get; set; }
        
        public string type { get; set; }



    }
}