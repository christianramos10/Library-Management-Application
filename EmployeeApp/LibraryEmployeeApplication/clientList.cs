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
    public partial class clientList : Form
    {
        string empNum = "", empName = "", empRole="";
        MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mylibrary;UID=libraryAdmin;PASSWORD=#Admin123");

        public clientList(string empNum, string empName, string empRole)
        {
            InitializeComponent();
            this.empNum = empNum;
            this.empName = empName;
            this.empRole = empRole;
            con.Open();
            this.loadClients();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu = new menu(this.empNum, this.empName, this.empRole);
            menu.ShowDialog();
            con.Close();
            this.Close();
        }

        private void cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            this.clear();
            int index = e.RowIndex;
            DataGridViewRow row = dataGridView.Rows[index];
            if (row != null)
            {
                IdTextBox.Text = row.Cells[0].Value.ToString();
                firstNameTextBox.Text = row.Cells[1].Value.ToString();
                lastNameTextBox.Text = row.Cells[2].Value.ToString();
                ageTextBox.Text = row.Cells[3].Value.ToString();
                sexTextBox.Text = row.Cells[4].Value.ToString();
                emailTextBox.Text = row.Cells[5].Value.ToString();
                passwordTextBox.Text = row.Cells[6].Value.ToString();
                
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.clear();
        }
        private void clear() {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //Check if blanks are filled
            if (IdTextBox.Text != "" && firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && ageTextBox.Text != "" && sexTextBox.Text != ""
                && emailTextBox.Text != "" && passwordTextBox.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Are you sure that you want to edit the client's info?", "Edit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string query = "update users set Id = @id, FirstName = @firstName, LastName = @lastName, Age = @age, Sex = @sex, Email = @email, Password = @password where Id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", IdTextBox.Text);
                        cmd.Parameters.AddWithValue("@firstName", firstNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@lastName", lastNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@age", ageTextBox.Text);
                        cmd.Parameters.AddWithValue("@sex", sexTextBox.Text);
                        cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                        cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);
                        

                        cmd.ExecuteNonQuery();
                        loadClients();
                        MessageBox.Show("Client was successfully edited.");
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

        private void delBtn_Click(object sender, EventArgs e)
        {
            //Check if isbn text is filled
            if (IdTextBox.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Are you sure that you want to delete this client?", "Delete", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string query = "delete from users where Id = '" + IdTextBox.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        loadClients();
                        MessageBox.Show("Client was successfully deleted.");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select a book to delete.");
            }
        }

        private void loadClients() {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();

            string loadQry = "select * from users order by Id";
            MySqlDataAdapter adapter = new MySqlDataAdapter(loadQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.dataGridView.DataSource = dt;
        }
    }
}
