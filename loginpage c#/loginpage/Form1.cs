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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void username_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username_text.Text.Trim() == "" && password_text.Text.Trim() == "")
            {
                MessageBox.Show("Please enter username and password");
            }
            else
            {
                
                    SqlConnection con = new SqlConnection(@"Data Source=MYPC\SQLEXPRESS;Initial Catalog=hospitalmanagement;Integrated Security=True");//For connection
                    SqlCommand cmd = new SqlCommand("select * from hospital_login where username=@username and log_password=@log_password", con);
                    cmd.Parameters.AddWithValue("@username", username_text.Text);
                    cmd.Parameters.AddWithValue("@log_password", password_text.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("login successfull");

                    Form6 f6 = new Form6();
                    this.Hide();                //To hide form 1
                    f6.ShowDialog();


                }



                else
                    {
                        MessageBox.Show("username or password is incorrect");
                    }
                

                
            }
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();                //To hide form 1
            f2.ShowDialog();

        }

        private void loginform_close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();                //To hide form 1
            f5.ShowDialog();
        }
    }
}
