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
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
            // ph = Int32.Parse(textBox_contact.Text);
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();     //For closing entire window
        }

        private void Gender_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
           comboBox_dept.MaxDropDownItems = 3; //For Setting dropdown values
        }

        string gender;  //Variable initilalized for checking gender field

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }



        private void button_submit_Click(object sender, EventArgs e)
        {
            bool blank = true;          //For Checking if textbox is empty
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    if (((TextBox)C).Text != "")
                    {
                       
                        blank = false;
                        break;
                    }
                }
            }
            if(blank==true)
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else
            {
                string ph = textBox_contact.Text;       //For checking if number else convert to phone number
                long phone = Int32.Parse(ph);            
                 SqlConnection con = new SqlConnection(@"Data Source = MYPC\SQLEXPRESS; Initial Catalog = hospitalmanagement; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("RegInsert", con);/*For inserting using stored procedure*/
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_name", textBox_name.Text);
                cmd.Parameters.AddWithValue("@gender", gender);//radiobutton
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@p_address", textBox_address.Text);
                cmd.Parameters.AddWithValue("@city", textBox_city.Text);
                cmd.Parameters.AddWithValue("@contact_no", phone);
                //cmd.Parameters.AddWithValue("contact_no",textBox_contact.Text);
                cmd.Parameters.AddWithValue("@email_id", textBox_email.Text);
                cmd.Parameters.AddWithValue("@dept", comboBox_dept.Text);
                cmd.Parameters.AddWithValue("@type", "insert");

                con.Open();
                int i =cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Registered Successfully");

                    Form1 f1 = new Form1();
                    this.Hide();                //To hide form 1
                    f1.ShowDialog();




                }
            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();                //To hide form 1
            f5.ShowDialog();
        }
    }
}
