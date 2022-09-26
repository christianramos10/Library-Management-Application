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
    public partial class signUp : Form
    {
        string name="", employeeNum="";
        public signUp(string name, string employeeNum)
        {
            InitializeComponent();
            this.name = name;
            this.employeeNum = employeeNum;
        }

        //Connect to the database
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-ETTN470;Initial Catalog=Librarydb;User ID=admin;Password=12345");
        private void signUp_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                loadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Load table info
        private void loadGrid()
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();

            string loadQry = "select * from employee_Table order by employeeNum";
            SqlDataAdapter adapter = new SqlDataAdapter(loadQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.dataGridView.DataSource = dt;
        }

        //Add user to database
        private void createBtn_Click(object sender, EventArgs e)
        {
            if (employeeNumTextBox.Text.Length == 0 || passwordTextBox.Text.Length == 0 || firstNameTextBox.Text.Length == 0 || lastNameTextBox.Text.Length == 0 || ageTextBox.Text.Length == 0 || sexTextBox.Text.Length == 0 || emailTextBox.Text.Length == 0 || phoneTextBox.Text.Length == 0) {
                MessageBox.Show("All fields required!");
            }

            else{

                try
                {
                    string title = "general";
                    if (adminCheckBox.Checked == true) {
                        title = "administrator";
                    }
                    string addQry = "insert into employee_Table values('" + employeeNumTextBox.Text + "','" + passwordTextBox.Text + "','" + firstNameTextBox.Text + "','" + lastNameTextBox.Text +
                        "','" + ageTextBox.Text + "','" + sexTextBox.Text + "','" + emailTextBox.Text + "','" + phoneTextBox.Text + "','" + addressTextBox.Text + "','" + title + "' );";
                    SqlCommand cmd = new SqlCommand(addQry, con);
                    cmd.ExecuteNonQuery();

                    this.loadGrid();
                }

                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Delete user from database
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (employeeNumTextBox.Text == ""){
                MessageBox.Show("Employee Number Required for Deletion!");
            }
            else {
                string empNameToDel = "";
                string searchQry = "select * from employee_Table where employeeNum='" + employeeNumTextBox.Text + "'";
                SqlCommand cmd = new SqlCommand(searchQry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    empNameToDel = dr["firstName"].ToString();
                }
                dr.Close();

                if (empNameToDel != ""){
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this user: " + empNameToDel, "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string delQry = "delete from employee_Table where employeeNum='" + employeeNumTextBox.Text + "'";
                        cmd = new SqlCommand(delQry, con);
                        cmd.ExecuteNonQuery();
                        loadGrid();

                    }
                }

                else {
                    MessageBox.Show("User not found!");
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (employeeNumTextBox.Text.Length == 0 || passwordTextBox.Text.Length == 0 || firstNameTextBox.Text.Length == 0 || lastNameTextBox.Text.Length == 0 || ageTextBox.Text.Length == 0 || sexTextBox.Text.Length == 0 || emailTextBox.Text.Length == 0 || phoneTextBox.Text.Length == 0)
            {
                MessageBox.Show("All fields required!");
            }

            else {

                try
                {
                    string title = "general";
                    if (adminCheckBox.Checked == true)
                    {
                        title = "administrator";
                    }

                    string updateQry = "update employee_Table set passw='" + passwordTextBox.Text + "',firstName='" + firstNameTextBox.Text + "',lastName='" + lastNameTextBox.Text +
                        "',age='" + ageTextBox.Text + "',sex='" + sexTextBox.Text + "',email='" + emailTextBox.Text + "',phone='" + phoneTextBox.Text + "',adress='" + addressTextBox.Text + "',title='" + title + "" +
                        "where employeeNum='" + employeeNumTextBox.Text + "'";
                    SqlCommand cmd = new SqlCommand(updateQry, con);
                    cmd.ExecuteNonQuery();
                    this.loadGrid();
                    MessageBox.Show("User Updated");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            employeeNumTextBox.Text = "";
            passwordTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            ageTextBox.Text = "";
            sexTextBox.Text = "";
            emailTextBox.Text = "";
            phoneTextBox.Text = "";
            addressTextBox.Text = "";
        }

        private void refreshList_Click(object sender, EventArgs e)
        {
            clearBtn_Click(sender, e);
            loadGrid();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //Search is the same as filter. Hence a lot of if cases.

            if (employeeNumTextBox.Text != "")
            {
                string searchQry = "select * from employee_Table where employeeNum='" + employeeNumTextBox.Text + "'";
                this.dataGridView.DataSource = null;
                this.dataGridView.Rows.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter(searchQry, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.dataGridView.DataSource = dt;
            }
            else {
                MessageBox.Show("Employee Number Not Found!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            mainForm main = new mainForm();
            main.ShowDialog();
            con.Close();
            this.Close();
        }

        private void cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            clearBtn_Click(sender, e);
           int index = e.RowIndex;
            DataGridViewRow row = dataGridView.Rows[index];
            if (row != null) {
                employeeNumTextBox.Text = row.Cells[0].Value.ToString();
                passwordTextBox.Text = row.Cells[1].Value.ToString();
                firstNameTextBox.Text = row.Cells[2].Value.ToString();
                lastNameTextBox.Text = row.Cells[3].Value.ToString();
                ageTextBox.Text = row.Cells[4].Value.ToString();
                sexTextBox.Text = row.Cells[5].Value.ToString();
                emailTextBox.Text = row.Cells[6].Value.ToString();
                phoneTextBox.Text = row.Cells[7].Value.ToString();
                addressTextBox.Text = row.Cells[8].Value.ToString();
            }
        }
    }
}
