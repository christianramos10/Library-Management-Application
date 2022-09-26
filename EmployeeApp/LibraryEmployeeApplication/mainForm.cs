using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryEmployeeApplication
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        //Connect to the database
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-ETTN470;Initial Catalog=Librarydb;User ID=admin;Password=12345");
        private void mainForm_Load(object sender, EventArgs e)
        {
            try {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            string name = "", employeeNum = "";

            if (employeeNumTextBox.Text.Length == 0 || passwordTextBox.Text.Length == 0) {
                MessageBox.Show("Both fields are required.");
            }

            else{
                string qry = "select * from employee_Table where employeeNum='" + employeeNumTextBox.Text + "' and passw='" + passwordTextBox.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) { 
                    name = dr["firstName"].ToString();
                    employeeNum = dr["employeeNum"].ToString();
                }
                dr.Close();

                //If user exists
                if (name != "")
                {
                    this.Hide();
                    menu menu = new menu();
                    menu.ShowDialog();
                    con.Close();
                    this.Close();
                }

                else {
                    MessageBox.Show("Employee Not Found!");
                }
            }
        }

        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            validateAdmin validateAdmin = new validateAdmin();
            validateAdmin.ShowDialog();
            con.Close();
            this.Close();
        }
    }
}
