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
    public class roomdetailsrepository
    {
        string constr = ConfigurationManager.ConnectionStrings["hospitalmanagement"].ToString();
        public List<Roomdetailsmodel> Roomdetailsdispaly()    //function for listing from database

        {
            List<Roomdetailsmodel> roomlist = new List<Roomdetailsmodel>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RoomdetailsDisplay";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtroom = new DataTable();
                conn.Open();
                da.Fill(dtroom);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtroom.Rows)       //for returning data as list in patientlist obj

                {


                    roomlist.Add(new Roomdetailsmodel

                    {
                        roomid = Convert.ToInt32(dr["roomid"]),
                        roomtype = dr["roomtype"].ToString(),
                        roomno = Convert.ToInt32(dr["roomno"]),
                        numberofbed = Convert.ToInt32(dr["numberofbed"]),
                        price = Convert.ToInt32(dr["price"]),
                        roomstatus = dr["roomstatus"].ToString(),
                        blockname = dr["blockname"].ToString()

                    });
                }



            }
            return roomlist;



        }


        //For inserting room details
        public bool InsertRoom(Roomdetailsmodel room)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Roomdetailscrudoperation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("roomtype",room.roomtype);
                cmd.Parameters.AddWithValue("roomno", room.roomno);
                cmd.Parameters.AddWithValue("numberofbed", room.numberofbed);
                cmd.Parameters.AddWithValue("price", room.price);
                cmd.Parameters.AddWithValue("roomstatus", room.roomstatus);
                cmd.Parameters.AddWithValue("blockname", room.blockname);
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

        public List<Roomdetailsmodel> getroombyid(int id)

        {
            List<Roomdetailsmodel> roomlist = new List<Roomdetailsmodel>();
            using (SqlConnection conn = new SqlConnection(constr))    //for connection
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectByRoomId";

                cmd.Parameters.AddWithValue("@roomid", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtroom = new DataTable();
                conn.Open();
                da.Fill(dtroom);        //data adapter
                conn.Close();

                foreach (DataRow dr in dtroom.Rows)       //for returning data as list in patientlist obj

                {
                    
                    roomlist.Add(new Roomdetailsmodel

                    {


                        roomid = Convert.ToInt32(dr["roomid"]),
                        roomtype = dr["roomtype"].ToString(),
                        roomno = Convert.ToInt32(dr["roomno"]),
                        numberofbed = Convert.ToInt32(dr["numberofbed"]),
                        price = Convert.ToInt32(dr["price"]),
                        roomstatus = dr["roomstatus"].ToString(),
                        blockname = dr["blockname"].ToString()

                    });
                }


            }
            return roomlist;

        }

        //For updating room details
        public bool UpdateRooms(Roomdetailsmodel room)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Roomdetailscrudoperation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("roomid", room.roomid);
                cmd.Parameters.AddWithValue("roomtype", room.roomtype);
                cmd.Parameters.AddWithValue("roomno", room.roomno);
                cmd.Parameters.AddWithValue("numberofbed", room.numberofbed);
                cmd.Parameters.AddWithValue("price", room.price);
                cmd.Parameters.AddWithValue("roomstatus", room.roomstatus);
                cmd.Parameters.AddWithValue("blockname", room.blockname);
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


        //For deleting the room
        public string deleteroom(int id)
        {
            string result = "";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Roomdetailscrudoperation", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@roomid", id);
                cmd.Parameters.AddWithValue("type", "delete");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return result;
        }







    }
}