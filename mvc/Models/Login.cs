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
        [DisplayName("Username")]
        public String Username { get; set; }
        [DisplayName("Password")]
        public String Password { get; set; }
        public String role { get; set; }

    }
}