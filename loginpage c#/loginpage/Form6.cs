using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace loginpage
{
    public partial class Form6 : Form
    {
        //string connection = "@Data Source=MYPC\SQLEXPRESS;Initial Catalog=hospitalmanagement;Integrated Security=True;";
        //SqlDataAdapter sda;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      //For displaying values in datagrid 
        {
            SqlConnection con = new SqlConnection(@"Data Source=MYPC\SQLEXPRESS;Initial Catalog=hospitalmanagement;Integrated Security=True");//For connection
            SqlCommand cmd = new SqlCommand("select * from registration", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataSet ds=new DataSet();
            con.Open();
            da.Fill(ds, "registration");
            con.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "registration";


        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();     //Link given to next Home page if logout
            this.Hide();
            f5.ShowDialog();
        }
    }
}
