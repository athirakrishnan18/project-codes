using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementNew.Models
{
    public class Staffdetails
    {
        [DisplayName(" Staff Id")]
        public string staffid { get; set; }
        [Required]
        [DisplayName(" Name")]
        public string staffname { get; set; }
        [Required]
        [DisplayName("Address")]
        public string staffaddress { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Staff Type")]
        public string stafftype { get; set; }
        [Required]
        [DisplayName("Position")]
        public string position { get; set; }
        [Required]
        [DisplayName("Salary")]
        public string salary { get; set; }
        [Required]
        [DisplayName("Date of Joining")]
        public string dateofjoining { get; set; }
       // public string type { get; set; }


    }
}