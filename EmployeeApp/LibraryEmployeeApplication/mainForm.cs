using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace LibraryEmployeeApplication
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        //Connect to the database
        MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mylibrary;UID=libraryAdmin;PASSWORD=#Admin123");
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
            string name = "", employeeNum = "", employeeRole = "";

            if (employeeNumTextBox.Text.Length == 0 || passwordTextBox.Text.Length == 0) {
                MessageBox.Show("Both fields are required.");
            }

            else{
                string qry = "select * from employee where employeeNum='" + employeeNumTextBox.Text + "' and password='" + passwordTextBox.Text + "'";
                MySqlCommand cmd = new MySqlCommand(qry, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) { 
                    name = dr["firstName"].ToString();
                    employeeNum = dr["employeeNum"].ToString();
                    employeeRole = dr["role"].ToString();
                }
                dr.Close();

                //If user exists
                if (name != "")
                {
                    this.Hide();
                    menu menu = new menu(employeeNum, name, employeeRole);
                    menu.ShowDialog();
                    con.Close();
                    this.Close();
                }

                else {
                    MessageBox.Show("Employee Not Found!");
                }
            }
        }
    }
}
