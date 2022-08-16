using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using HospitalManagementNew.Models;
using System.Data.SqlClient;
using System.Data;

namespace HospitalManagementNew.Repository
{
    public class Appointmentrepository
    {
        string constr = ConfigurationManager.ConnectionStrings["hospitalmanagement"].ToString();



        public List<AppointmentModel> getpatientbookind(string log)    //function for listing from database

        {
            List<AppointmentModel> patientbooked = new List<AppointmentModel>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BookedUserSelect";
                //cmd.CommandText = "UserSelect";
               cmd.Parameters.AddWithValue("@bookid", log);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtbooked = new DataTable();
                conn.Open();
                da.Fill(dtbooked);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtbooked.Rows)       //for returning data as list in patientlist obj

                {
                    DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);
                    DateTime dateofbooked = Convert.ToDateTime(dr["datebooked"]);

                    patientbooked.Add(new AppointmentModel

                    {


                        bookid = Convert.ToInt32(dr["bookid"]),
                        patientname = dr["patientname"].ToString(),
                        patientaddress = dr["patientaddress"].ToString(),
                       dob    = Convert.ToDateTime(dr["dob"]),
                        //dob = dateofbirth.ToString(),
                        age = Convert.ToInt32(dr["age"]),
                        gender = dr["gender"].ToString(),

                        phoneno = Convert.ToInt32(dr["phone_no"]),
                        dept = dr["dept"].ToString(),
                        emailid = dr["emailid"].ToString(),
                        password = dr["userpassword"].ToString(),
                       // datebooked= dateofbooked.ToString()


                    });
                }



            }
            return patientbooked;



        }





        //For inserting booking details details
        public bool InsertAppointment(AppointmentModel appointment)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("BookedUserDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("patientname", appointment.patientname);
                cmd.Parameters.AddWithValue("patientaddress", appointment.patientaddress);
                cmd.Parameters.AddWithValue("dob", appointment.dob);
                cmd.Parameters.AddWithValue("age", appointment.age);
                cmd.Parameters.AddWithValue("gender", appointment.gender);
                cmd.Parameters.AddWithValue("phone_no", appointment.phoneno);
                cmd.Parameters.AddWithValue("dept", appointment.dept);
                
                cmd.Parameters.AddWithValue("emailid", appointment.emailid);
                cmd.Parameters.AddWithValue("userpassword", appointment.password);
                cmd.Parameters.AddWithValue("datebooked", appointment.datebooked);
                cmd.Parameters.AddWithValue("userrole", "user");

                
                cmd.Parameters.AddWithValue("type", "insert");
                conn.Open();
                id = cmd.ExecuteNonQuery();       //if insert it will return id as 1
                conn.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        

       
        public List<AppointmentModel> getbookbyid(int id)

        {
            
            List<AppointmentModel> appointmentlist = new List<AppointmentModel>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BookedUserSelect";

                cmd.Parameters.AddWithValue("@bookid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtbooked = new DataTable();
                conn.Open();
                da.Fill(dtbooked);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtbooked.Rows)       //for returning data as list in patientlist obj

                {
                    DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);
                   
                    appointmentlist.Add(new AppointmentModel

                    {

                        bookid = Convert.ToInt32(dr["bookid"]),
                        patientname = dr["patientname"].ToString(),
                        patientaddress = dr["patientaddress"].ToString(),
                       
                        dob    = Convert.ToDateTime(dr["dob"]),
                        //dob = dateofbirth.ToString(),
                      
                        age = Convert.ToInt32(dr["age"]),
                        gender = dr["gender"].ToString(),

                        phoneno = Convert.ToInt32(dr["phone_no"]),
                        dept = dr["dept"].ToString(),
                        emailid = dr["emailid"].ToString(),
                        password = dr["userpassword"].ToString(),
                        datebooked = Convert.ToDateTime(dr["datebooked"])


                    });
                }


            }
            return appointmentlist;



        }


        //For inserting booking details with status booked  for admin side
        /* public bool BookAppointmentStatus(AppointmentModel appointment)
         {
             int id = 0;
             using (SqlConnection conn = new SqlConnection(constr))
             {
                 SqlCommand cmd = new SqlCommand("StatusOfBooked", conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("patientname", appointment.patientname);
                 cmd.Parameters.AddWithValue("patientaddress", appointment.patientaddress);
                 cmd.Parameters.AddWithValue("dob", appointment.dob);
                 cmd.Parameters.AddWithValue("age", appointment.age);
                 cmd.Parameters.AddWithValue("gender", appointment.gender);
                 cmd.Parameters.AddWithValue("phone_no", appointment.phoneno);
                 cmd.Parameters.AddWithValue("emailid", appointment.emailid);

                 cmd.Parameters.AddWithValue("datebooked", appointment.datebooked);
                 cmd.Parameters.AddWithValue("dept", appointment.dept);
                 cmd.Parameters.AddWithValue("doctor", appointment.doctors);
                 cmd.Parameters.AddWithValue("bookstatus", "booked");


                 cmd.Parameters.AddWithValue("type", "insert");
                 conn.Open();
                 id = cmd.ExecuteNonQuery();       //if insert it will return id as 1
                 conn.Close();

             }
             if (id > 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }*/

        public bool BookAppointmentStatus(AppointmentModel appointment)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Status", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("patientname",appointment.patientname);
                cmd.Parameters.AddWithValue("patientaddress", appointment.patientaddress);
                cmd.Parameters.AddWithValue("dob", appointment.dob);
                cmd.Parameters.AddWithValue("age", appointment.age);
                cmd.Parameters.AddWithValue("gender",appointment.gender);
                cmd.Parameters.AddWithValue("phone_no", appointment.phoneno);
                cmd.Parameters.AddWithValue("emailid", appointment.emailid);
                cmd.Parameters.AddWithValue("userpassword", appointment.password);
                cmd.Parameters.AddWithValue("datebooked", appointment.datebooked);
                cmd.Parameters.AddWithValue("dept", appointment.dept);
                cmd.Parameters.AddWithValue("doctor", appointment.doctors);
                cmd.Parameters.AddWithValue("userstatus", "booked");
                cmd.Parameters.AddWithValue("type", "insert");
                conn.Open();
                id = cmd.ExecuteNonQuery();       //if insert it will return id as 1
                conn.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //For displaying booked status in user side
        public List<AppointmentModel> getstatusbyid(int id)

        {
            List<AppointmentModel> bookedstatus = new List<AppointmentModel>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AdminStatusSelectByID";

                cmd.Parameters.AddWithValue("@bookid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtstatus = new DataTable();
                conn.Open();
                da.Fill(dtstatus);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtstatus.Rows)       //for returning data as list in patientlist obj

                {
                    // DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);
                    bookedstatus.Add(new AppointmentModel

                    {


                        bookid = Convert.ToInt32(dr["bookid"]),
                        patientname = dr["patientname"].ToString(),
                        patientaddress = dr["patientaddress"].ToString(),
                        dob = Convert.ToDateTime(dr["dob"]),
                        //dob = dateofbirth.ToString(),
                        age = Convert.ToInt32(dr["age"]),
                        gender = dr["gender"].ToString(),
                        phoneno = Convert.ToInt32(dr["phone_no"]),
                        emailid = dr["emailid"].ToString(),
                        datebooked = Convert.ToDateTime(dr["datebooked"]),
                        // contact_no = Convert.ToInt32(dr["contact_no"]),
                        dept = dr["dept"].ToString(),
                        doctors = dr["doctor"].ToString(),
                        userstatus = dr["userstatus"].ToString()

                    });
                }


            }
            return bookedstatus;



        }


    }
}