using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HospitalManagementNew.Models
{
    public class Login
    {
        public int login_id { get; set; }
        [Required]
        [DisplayName("Username")]
        public String Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public String Password { get; set; }
        public String role { get; set; }

    }
}