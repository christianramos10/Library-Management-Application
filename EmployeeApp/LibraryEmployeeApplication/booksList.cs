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
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LibraryEmployeeApplication
{
    public partial class booksList : Form
    {
        string empNum = "", empName = "", empPass = "";

        public booksList(string empNum, string empName)
        {
            this.empNum = empNum;
            this.empName = empName;
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mylibrary;UID=libraryAdmin;PASSWORD=#Admin123");
        private void booksList_Load(object sender, EventArgs e)
        {
            try { 
                con.Open();
                this.loadGrid();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        //Load table info
        private void loadGrid()
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();

            string loadQry = "select * from books order by Title";
            MySqlDataAdapter adapter = new MySqlDataAdapter(loadQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.dataGridView.DataSource = dt;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>()) {
                tb.Text = "";
                descriptionTextBox.Text = "";
            }
        }

        private void cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            clearBtn_Click(sender, e);
            int index = e.RowIndex;
            DataGridViewRow row = dataGridView.Rows[index];
            if (row != null)
            {
                titleTextBox.Text = row.Cells[0].Value.ToString();
                descriptionTextBox.Text = row.Cells[1].Value.ToString();
                editionTextBox.Text = row.Cells[2].Value.ToString();
                authorTextBox.Text = row.Cells[3].Value.ToString();
                publisherTextBox.Text = row.Cells[4].Value.ToString();
                yearTextBox.Text = row.Cells[5].Value.ToString();
                isbnTextBox.Text = row.Cells[6].Value.ToString();
                languageTextBox.Text = row.Cells[7].Value.ToString();
                genreTextBox.Text = row.Cells[8].Value.ToString();
                pagesTextBox.Text = row.Cells[9].Value.ToString();
                rentedTextBox.Text = row.Cells[10].Value.ToString();
                onHandTextBox.Text = row.Cells[11].Value.ToString();
                totalTextBox.Text = row.Cells[12].Value.ToString();
                urlTextBox.Text = row.Cells[13].Value.ToString();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();

            string srchQry = "select * from books where title like'%" + searchTextbox.Text + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(srchQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.dataGridView.DataSource = dt;
        }

        private void searchTextbox_Click(object sender, EventArgs e)
        {
            searchTextbox.Text = "";
            searchTextbox.ForeColor = Color.Black;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //Check if blanks are filled
            if (titleTextBox.Text != "" && authorTextBox.Text != ""  && isbnTextBox.Text != "" && languageTextBox.Text != "" && descriptionTextBox.Text != ""
                && genreTextBox.Text != "" && pagesTextBox.Text != "" && rentedTextBox.Text != "" && onHandTextBox.Text != "" && totalTextBox.Text != "")
            {
                //Search if book already exists in db
                string searchQuery = "select * from books where isbn = "+isbnTextBox.Text;
                MySqlCommand searchCmd= new MySqlCommand(searchQuery, con);
                MySqlDataReader dr = searchCmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Error! There's already a book with the same ISBN.");
                    dr.Close();
                }
                

                //Add book to db
                else {
                    dr.Close();
                    try
                    {
                        string query = "insert into books values(@title, @description, @edition, @author, @publisher, @publicationYear, @isbn, @language, @genre, @pages, @rented, @available, @total, @url)";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@title", titleTextBox.Text);
                        cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                        cmd.Parameters.AddWithValue("@edition", editionTextBox.Text);
                        cmd.Parameters.AddWithValue("@author", authorTextBox.Text);
                        cmd.Parameters.AddWithValue("@publisher", publisherTextBox.Text);
                        cmd.Parameters.AddWithValue("@publicationYear", yearTextBox.Text);
                        cmd.Parameters.AddWithValue("@isbn", isbnTextBox.Text);
                        cmd.Parameters.AddWithValue("@language", languageTextBox.Text);
                        cmd.Parameters.AddWithValue("@genre", genreTextBox.Text);
                        cmd.Parameters.AddWithValue("@pages", pagesTextBox.Text);
                        cmd.Parameters.AddWithValue("@rented", rentedTextBox.Text);
                        cmd.Parameters.AddWithValue("@available", onHandTextBox.Text);
                        cmd.Parameters.AddWithValue("@total", totalTextBox.Text);
                        cmd.Parameters.AddWithValue("@url", urlTextBox.Text);

                        cmd.ExecuteNonQuery();
                        loadGrid();
                        MessageBox.Show("Book was successfully added.");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }  
            }
            else {
                MessageBox.Show("Please fill all the blanks.");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //Check if blanks are filled
            if (titleTextBox.Text != "" && authorTextBox.Text != "" && isbnTextBox.Text != "" && languageTextBox.Text != "" && descriptionTextBox.Text != ""
                && genreTextBox.Text != "" && pagesTextBox.Text != "" && rentedTextBox.Text != "" && onHandTextBox.Text != "" && totalTextBox.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Are you sure that you want to edit the book's info?", "Edit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) { 
                    try
                {
                    string query = "update books set Title = @title, Description = @description, Edition = @edition, Author = @author, Publisher = @publisher, PublicationYear = @publicationYear, ISBN = @isbn, Language = @language, Genre = @genre, Pages = @pages, Rented = @rented, available = @available, Total = @total, CoverURL = @url where ISBN = @isbn";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@title", titleTextBox.Text);
                    cmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@edition", editionTextBox.Text);
                    cmd.Parameters.AddWithValue("@author", authorTextBox.Text);
                    cmd.Parameters.AddWithValue("@publisher", publisherTextBox.Text);
                    cmd.Parameters.AddWithValue("@publicationYear", yearTextBox.Text);
                    cmd.Parameters.AddWithValue("@isbn", isbnTextBox.Text);
                    cmd.Parameters.AddWithValue("@language", languageTextBox.Text);
                    cmd.Parameters.AddWithValue("@genre", genreTextBox.Text);
                    cmd.Parameters.AddWithValue("@pages", pagesTextBox.Text);
                    cmd.Parameters.AddWithValue("@rented", rentedTextBox.Text);
                    cmd.Parameters.AddWithValue("@available", onHandTextBox.Text);
                    cmd.Parameters.AddWithValue("@total", totalTextBox.Text);
                    cmd.Parameters.AddWithValue("@url", urlTextBox.Text);

                    cmd.ExecuteNonQuery();
                    loadGrid();
                    MessageBox.Show("Book was successfully edited.");
                }

                catch (Exception ex) {
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
            //Check if isbn text is filled
            if (isbnTextBox.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Are you sure that you want to delete this book?", "Delete", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string query = "delete from books where ISBN = " + isbnTextBox.Text;
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        loadGrid();
                        MessageBox.Show("Book was successfully deleted.");
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
