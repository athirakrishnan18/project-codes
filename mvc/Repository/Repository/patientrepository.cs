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
    public class patientrepository
    {
      

            string constr = ConfigurationManager.ConnectionStrings["hospitalmanagement"].ToString();
            
        public List<patientmodel>getallpatient()    //function for listing from database
             
        {
            List<patientmodel> patientlist = new List<patientmodel>();
            using(SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "selectdetails";
                //cmd.CommandText = "UserSelect";
                //cmd.Parameters.AddWithValue("@userrole", "admin");
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dtpatient = new DataTable();
                conn.Open();
                da.Fill(dtpatient);        //data adapter
                conn.Close();

                foreach(DataRow dr in dtpatient.Rows)       //for returning data as list in patientlist obj

                {
                    DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);   
                    patientlist.Add(new patientmodel

                    {
                        

                        regid = Convert.ToInt32(dr["regid"]),
                        p_name = dr["p_name"].ToString(),
                        gender = dr["gender"].ToString(),
                        //dob    = Convert.ToDateTime(dr["dob"]),
                        dob= dateofbirth.ToString(),
                        p_address = dr["p_address"].ToString(),
                        city = dr["city"].ToString(),
                        contact_no = Convert.ToInt32(dr["contact_no"]),
                        email_id = dr["email_id"].ToString(),
                        dept = dr["dept"].ToString()
                    

                        });
                }



            }
            return patientlist;



        }

        //For inserting patient details
        public bool InsertPatient(patientmodel patient)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd=new SqlCommand("RegInsert",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_name",patient.p_name);
                cmd.Parameters.AddWithValue("gender",patient.gender);
                cmd.Parameters.AddWithValue("dob", patient.dob);
                cmd.Parameters.AddWithValue("p_address", patient.p_address);
                cmd.Parameters.AddWithValue("city", patient.city);
                cmd.Parameters.AddWithValue("contact_no", patient.contact_no);
                cmd.Parameters.AddWithValue("email_id", patient.email_id);
                cmd.Parameters.AddWithValue("dept", patient.dept);
                cmd.Parameters.AddWithValue("type", "insert");
                conn.Open();
                id=cmd.ExecuteNonQuery();       //if insert it will return id as 1
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
//function for listing from databasebased on id

        public List<patientmodel> getpatientbyid(int id)    

        {
            List<patientmodel> patientlist = new List<patientmodel>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "selectbyid";

                cmd.Parameters.AddWithValue("@regid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtpatients = new DataTable();
                conn.Open();
                da.Fill(dtpatients);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtpatients.Rows)       //for returning data as list in patientlist obj

                {
                    DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);
                    patientlist.Add(new patientmodel

                    {


                        regid = Convert.ToInt32(dr["regid"]),
                        p_name = dr["p_name"].ToString(),
                        gender = dr["gender"].ToString(),
                        //dob    = Convert.ToDateTime(dr["dob"]),
                        dob = dateofbirth.ToString(),
                        p_address = dr["p_address"].ToString(),
                        city = dr["city"].ToString(),
                        contact_no = Convert.ToInt32(dr["contact_no"]),
                        email_id = dr["email_id"].ToString(),
                        dept = dr["dept"].ToString()


                    });
                }


            }
            return patientlist;



        }
        //For updating
        public bool UpdatePatient(patientmodel patient)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("RegInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("regid", patient.regid);
                cmd.Parameters.AddWithValue("p_name", patient.p_name);
                cmd.Parameters.AddWithValue("gender", patient.gender);
                cmd.Parameters.AddWithValue("dob", patient.dob);
                cmd.Parameters.AddWithValue("p_address", patient.p_address);
                cmd.Parameters.AddWithValue("city", patient.city);
                cmd.Parameters.AddWithValue("contact_no", patient.contact_no);
                cmd.Parameters.AddWithValue("email_id", patient.email_id);
                cmd.Parameters.AddWithValue("dept", patient.dept);
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

        //For deleting the patient
        public string deletepatient(int id)
        {
            string result = "";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("RegInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@regid", id);
                cmd.Parameters.AddWithValue("type", "delete");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return result;
        }

    }
    
}