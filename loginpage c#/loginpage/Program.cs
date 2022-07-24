using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginpage
{
    internal static class Program
    {

        public class Register
        {
            public int regid { get; set; }              //For getting the fields
            public string p_name { get; set; }
            public string gender { get; set; }
            public DateTime date { get; set; }
            public string p_address { get; set; }
            public string city { get; set; }
            public int contatact_no { get; set; }
            public string email_id { get; set; }
            public string dept { get; set; }

            public string type { get; set; }

        }



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form5());   //For loading the main page
        }

      
    }
    
}
