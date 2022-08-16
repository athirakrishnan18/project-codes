using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagementNew.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HospitalManagementNew.Repository
{
    public class LoginRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["hospitalmanagement"].ToString();
        public List<Login>  Logincheck(Login login)

        {
            List<Login> loginrole = new List<Login>();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "loginrole";
                cmd.CommandText = "RoleSelect";
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@log_password", login.Password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);        //data adapter
                conn.Close();

                foreach (DataRow dr in dt.Rows)       //for returning data as list in patientlist obj

                {
                    loginrole.Add(new Login

                    {
                        
                        role = dr["role"].ToString(),
                        login_id = Convert.ToInt32(dr["login_id"]),
                    }); 
                }
                
            }
            return loginrole;
        }

      /*  public List<Login> userlogin()
        {
            List<Login> userlist = new List<Login>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "selectdetails";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtuser = new DataTable();
                conn.Open();
                da.Fill(dtuser);        //data adapter
                conn.Close();
            }

            foreach (DataRow dr in dtuser.Rows)       //for returning data as list in patientlist obj

            {
               // DateTime dateofbirth = Convert.ToDateTime(dr["dob"]);
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


        */



















         /* public string  Logincheck(Login login,out string userrole)
        {
            //List<Login> userrole = new List<Login>();

            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "selectrole";
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@log_password", login.Password);
                //cmd.Parameters.AddWithValue("@role", "admin");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //conn.Open();
               // da.Fill(dt);
                //string userrole = cmd.ExecuteNonQuery().ToString();
                userrole = cmd.ExecuteNonQuery().ToString();
                conn.Close();
                return userrole;
                // return !string.IsNullOrEmpty(userrole);
              foreach(DataRow dr in dt.Rows)
                {
                    userrole.Add(new Login
                    {
                        role = dr["role"].ToString(),
                       
                    });

                        
                }

                
            }
            return userrole;*/

    }
}