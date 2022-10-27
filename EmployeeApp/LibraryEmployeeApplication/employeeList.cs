using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryEmployeeApplication
{
    public partial class employeeList : Form
    {
        string empNum, empName, role = "general";
        MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mylibrary;UID=libraryAdmin;PASSWORD=#Admin123");
        public employeeList(string empNum, string empName)
        {
            InitializeComponent();
            this.empNum = empNum;
            this.empName = empName;
            con.Open();
        }
        private void employeeList_Load(object sender, EventArgs e)
        {
            this.loadGrid();
        }
        private void loadGrid()
        {
            this.employeeGridView.DataSource = null;
            this.employeeGridView.Rows.Clear();

            string loadQry = "select * from employee order by employeeNum";
            MySqlDataAdapter adapter = new MySqlDataAdapter(loadQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.employeeGridView.DataSource = dt;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            //Check if blanks are filled
            if (firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && ageTextBox.Text != "" && sexTextBox.Text != "" && phoneTextBox.Text != ""
                && emailTextBox.Text != "" && passwordTextBox.Text != "" && addressTextBox.Text != "")
            {
                //Search if employee already exists in db
                string searchQuery = "select * from employee where email = '" +emailTextBox.Text+ "'";
                MySqlCommand searchCmd = new MySqlCommand(searchQuery, con);
                MySqlDataReader dr = searchCmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Error! There's already an employee with the same e-mail.");
                    dr.Close();
                }

                if (adminCheckBox.Checked) this.role = "administrator";

                //Add employee to db
                else
                {
                    dr.Close();
                    try
                    {
                        string query = "insert into employee(password, firstName, lastName, age, sex, email, phone, address, role) values(@password, @firstName, @lastName, @age, @sex, @email, @phone, @address, @role)";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);
                        cmd.Parameters.AddWithValue("@firstName", firstNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@lastName", lastNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@age", ageTextBox.Text);
                        cmd.Parameters.AddWithValue("@sex", sexTextBox.Text);
                        cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                        cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                        cmd.Parameters.AddWithValue("@role", this.role);

                   //     cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailTextBox.Text;

                        cmd.ExecuteNonQuery();
                        loadGrid();
                        MessageBox.Show("Employee was successfully added.");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill all the blanks.");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //Check if blanks are filled
            if (firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && ageTextBox.Text != "" && sexTextBox.Text != "" && phoneTextBox.Text != ""
                && emailTextBox.Text != "" && passwordTextBox.Text != "" && addressTextBox.Text != "")
            {

                if (adminCheckBox.Checked) this.role = "administrator";

                DialogResult dialog = MessageBox.Show("Are you sure that you want to edit the employee's info?", "Edit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string query = "update employee set password = @password, firstName = @firstName, lastName = @lastName, age = @age, sex = @sex, email = @email, phone = @phone, address = @address, role = @role where email = @email";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);
                        cmd.Parameters.AddWithValue("@firstName", firstNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@lastName", lastNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@age", ageTextBox.Text);
                        cmd.Parameters.AddWithValue("@sex", sexTextBox.Text);
                        cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                        cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                        cmd.Parameters.AddWithValue("@role", this.role);

                        cmd.ExecuteNonQuery();
                        loadGrid();
                        MessageBox.Show("Employee was successfully edited.");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill all the blanks.");
            }


        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //Check if email text is filled
            if (emailTextBox.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Are you sure that you want to remove this employee?", "Delete", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string query = "delete from emplopyee where email = " + emailTextBox.Text;
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        loadGrid();
                        MessageBox.Show("Employee was successfully removed.");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select an employee to remove.");
            }
        }
        private void searchTextbox_Click(object sender, EventArgs e)
        {
            searchTextbox.Text = "";
            searchTextbox.ForeColor = Color.Black;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.employeeGridView.DataSource = null;
            this.employeeGridView.Rows.Clear();

            string srchQry = "select * from employee where firstName like'%" + searchTextbox.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(srchQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.employeeGridView.DataSource = dt;
        }

        private void cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            clearBtn_Click(sender, e);
            int index = e.RowIndex;
            DataGridViewRow row = employeeGridView.Rows[index];
            if (row != null)
            {
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

        private void clearBtn_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
            }
            addressTextBox.Text = "";
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu = new menu(this.empNum, this.empName);
            menu.ShowDialog();
            con.Close();
            this.Close();
        }
    }
}
