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
        public List<Login> Logincheck(Login login)
        {
           
            List<Login > login_list = new List<Login>();
            using(SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "selectlogin";
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@log_password", login.Password);
                SqlDataAdapter da=new SqlDataAdapter();
                DataTable dt=new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                foreach(DataRow dr in dt.Rows)
                {
                    login_list.Add(new Login
                    {
                        Username = dr["username"].ToString(),
                        Password = dr["log_password"].ToString(),
                    }

                        );
                }
                

            }
            return login_list;
        }
    }
}