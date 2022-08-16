using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HospitalManagementNew.Models;
using System.Configuration;
using System.Data;


namespace HospitalManagementNew.Repository
{
    public class staffrepository
     {
         string constr = ConfigurationManager.ConnectionStrings["hospitalmanagement"].ToString();

          

    public List<Staffdetails> Staffdispaly()    //function for listing from database

    {
        List<Staffdetails> stafflist = new List<Staffdetails>();
        using (SqlConnection conn = new SqlConnection(constr))    //for connection
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "selectstaff";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtstaff = new DataTable();
            conn.Open();
            da.Fill(dtstaff);        //data adapter
            conn.Close();

            foreach (DataRow dr in dtstaff.Rows)       //for returning data as list in patientlist obj

            {
                DateTime joiningdate = Convert.ToDateTime(dr["dateofjoining"]);

                    stafflist.Add(new Staffdetails

                {


                        staffid = dr["staffid"].ToString(),
                        staffname = dr["staffname"].ToString(),
                        staffaddress = dr["staffaddress"].ToString(),
                        //dob    = Convert.ToDateTime(dr["dob"]),
                        //dateofjoining = joiningdate.ToString(),
                        gender = dr["gender"].ToString(),
                        stafftype = dr["stafftype"].ToString(),
                        //salary = Convert.ToInt32(dr["salary"]),
                        position = dr["position"].ToString(),
                        salary = dr["salary"].ToString(),
                        dateofjoining = joiningdate.ToString(),


                    });
            }



        }
        return stafflist;



    }

        //For inserting staff details
        public bool InsertStaff(Staffdetails staff)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("StaffCrud", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("staffname",staff.staffname);
                cmd.Parameters.AddWithValue("staffaddress", staff.staffaddress);
                cmd.Parameters.AddWithValue("gender", staff.gender);
                cmd.Parameters.AddWithValue("stafftype", staff.stafftype);
                cmd.Parameters.AddWithValue("position", staff.position);
                cmd.Parameters.AddWithValue("salary", staff.salary);
                cmd.Parameters.AddWithValue("dateofjoining", staff.dateofjoining);
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


        //function for listing from databasebased based on id

        public List<Staffdetails> getstaffid(int id)

        {
            List<Staffdetails> stafflist = new List<Staffdetails>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectbyStaffId";

                cmd.Parameters.AddWithValue("@staffid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtstaffs = new DataTable();
                conn.Open();
                da.Fill(dtstaffs);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtstaffs.Rows)       //for returning data as list in patientlist obj

                {
                    DateTime joiningdate = Convert.ToDateTime(dr["dateofjoining"]);
                    stafflist.Add(new Staffdetails

                    {


                        staffid = dr["staffid"].ToString(),
                        staffname = dr["staffname"].ToString(),
                        staffaddress = dr["staffaddress"].ToString(),
                        //dob    = Convert.ToDateTime(dr["dob"]),
                        //dateofjoining = joiningdate.ToString(),
                        gender = dr["gender"].ToString(),
                        stafftype = dr["stafftype"].ToString(),
                        //salary = Convert.ToInt32(dr["salary"]),
                        position = dr["position"].ToString(),
                        salary = dr["salary"].ToString(),
                        dateofjoining = joiningdate.ToString(),



                    });
                }


            }
            return stafflist;



        }

        //For updating staff details
        public bool UpdateStaffs(Staffdetails staff)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("StaffCrud", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("staffid", staff.staffid);
                cmd.Parameters.AddWithValue("staffname", staff.staffname);
                cmd.Parameters.AddWithValue("staffaddress", staff.staffaddress);
                cmd.Parameters.AddWithValue("gender", staff.gender);
                cmd.Parameters.AddWithValue("stafftype", staff.stafftype);
                cmd.Parameters.AddWithValue("position", staff.position);
                cmd.Parameters.AddWithValue("salary", staff.salary);
                cmd.Parameters.AddWithValue("dateofjoining", staff.dateofjoining);
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

        //For deleting the staff
        public string deletestaff(int id)
        {
            string result = "";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("StaffCrud", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@staffid", id);
                cmd.Parameters.AddWithValue("type", "delete");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return result;
        }









    }
}