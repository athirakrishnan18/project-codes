using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using HospitalManagementNew.Models;
using System.Data;


namespace HospitalManagementNew.Repository
{
    public class BookedRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["hospitalmanagement"].ToString();

        public List<BookedPatientsMode> getbookedpatients()    //function for listing from database

        {
            List<BookedPatientsMode> bookedpatientlist = new List<BookedPatientsMode>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ConfirmBookedDetails";
                //cmd.CommandText = "UserSelect";
                //cmd.Parameters.AddWithValue("@userrole", "admin");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtpatient = new DataTable();
                conn.Open();
                da.Fill(dtpatient);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtpatient.Rows)       //for returning data as list in patientlist obj

                {
                    //DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);
                    bookedpatientlist.Add(new BookedPatientsMode

                    {


                        bookid = Convert.ToInt32(dr["bookid"]),
                        patientname = dr["patientname"].ToString(),
                        patientaddress = dr["patientaddress"].ToString(),
                        dob    = Convert.ToDateTime(dr["dob"]),
                        //dob = dateofbirth.ToString(),
                        age = Convert.ToInt32(dr["age"]),
                        gender = dr["gender"].ToString(),
                        phone_no = Convert.ToInt32(dr["phone_no"]),
                        emailid = dr["emailid"].ToString(),
                        datebooked = Convert.ToDateTime(dr["datebooked"]),
                        // contact_no = Convert.ToInt32(dr["contact_no"]),
                        dept = dr["dept"].ToString(),
                        doctor = dr["doctor"].ToString(),
                        userstatus = dr["userstatus"].ToString()


                    });
                }



            }
            return bookedpatientlist;



        }

        //For approving appointment request
        public bool ConfirmBooking(BookedPatientsMode booked)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("AdminStatusUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("bookid", booked.bookid);
                cmd.Parameters.AddWithValue("patientname",booked.patientname);
                cmd.Parameters.AddWithValue("patientaddress", booked.patientaddress);
                cmd.Parameters.AddWithValue("dob", booked.dob);
                cmd.Parameters.AddWithValue("age", booked.age);
                cmd.Parameters.AddWithValue("gender",booked.gender);
                cmd.Parameters.AddWithValue("phone_no", booked.phone_no);
                cmd.Parameters.AddWithValue("emailid", booked.emailid);
                cmd.Parameters.AddWithValue("datebooked",booked.datebooked);
                cmd.Parameters.AddWithValue("dept", booked.dept);
                cmd.Parameters.AddWithValue("doctor", booked.doctor);
                cmd.Parameters.AddWithValue("userstatus", "Confirmed");
                cmd.Parameters.AddWithValue("type", "update");
                conn.Open();
                i = cmd.ExecuteNonQuery();       //if insert it will return id as 1
                conn.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //function for listing from databasebased on id

        public List<BookedPatientsMode> getbookpatientbyid(int id)

        {
            List<BookedPatientsMode> booked = new List<BookedPatientsMode>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AdminStatusSelectByID";

                cmd.Parameters.AddWithValue("@bookid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtbooked = new DataTable();
                conn.Open();
                da.Fill(dtbooked);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtbooked.Rows)       //for returning data as list in patientlist obj

                {
                   // DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);
                    booked.Add(new BookedPatientsMode

                    {


                        bookid = Convert.ToInt32(dr["bookid"]),
                        patientname = dr["patientname"].ToString(),
                        patientaddress = dr["patientaddress"].ToString(),
                        dob = Convert.ToDateTime(dr["dob"]),
                        //dob = dateofbirth.ToString(),
                        age = Convert.ToInt32(dr["age"]),
                        gender = dr["gender"].ToString(),
                        phone_no = Convert.ToInt32(dr["phone_no"]),
                        emailid = dr["emailid"].ToString(),
                        datebooked = Convert.ToDateTime(dr["datebooked"]),
                        // contact_no = Convert.ToInt32(dr["contact_no"]),
                        dept = dr["dept"].ToString(),
                        doctor = dr["doctor"].ToString(),
                        userstatus = dr["userstatus"].ToString()

                    });
                }


            }
            return booked;



        }



        public bool CancelBooking(BookedPatientsMode booking)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("AdminStatusUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("bookid", booking.bookid);
                cmd.Parameters.AddWithValue("patientname", booking.patientname);
                cmd.Parameters.AddWithValue("patientaddress", booking.patientaddress);
                cmd.Parameters.AddWithValue("dob", booking.dob);
                cmd.Parameters.AddWithValue("age", booking.age);
                cmd.Parameters.AddWithValue("gender", booking.gender);
                cmd.Parameters.AddWithValue("phone_no", booking.phone_no);
                cmd.Parameters.AddWithValue("emailid", booking.emailid);
                cmd.Parameters.AddWithValue("datebooked", booking.datebooked);
                cmd.Parameters.AddWithValue("dept", booking.dept);
                cmd.Parameters.AddWithValue("doctor", booking.doctor);
                cmd.Parameters.AddWithValue("userstatus", "Cancelled");
                cmd.Parameters.AddWithValue("type", "update");
                conn.Open();
                i = cmd.ExecuteNonQuery();       //if insert it will return id as 1
                conn.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }













    }
}