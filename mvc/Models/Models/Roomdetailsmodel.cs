using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementNew.Models
{
    public class Roomdetailsmodel {
        [DisplayName("Room Id")]
        public int roomid { get; set; }
        [Required]
        [DisplayName("Room Type")]
        public string roomtype { get; set; }
        [Required]
        [DisplayName("Room No.")]
        public int roomno { get; set; }
        [Required]
        [DisplayName("No.of Bed")]
        public int numberofbed { get; set; }
        [Required]
        [DisplayName("Price")]
        public int price { get; set; }
        [Required]
        [DisplayName("Status")]
        public string roomstatus { get; set; }
        [Required]
        [DisplayName("Block Name")]
        public string blockname { get; set; }
        public string type { get; set; }


    }
    
       
    
}