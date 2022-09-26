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
    public partial class booksList : Form
    {
        public booksList()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-ETTN470;Initial Catalog=Librarydb;User ID=admin;Password=12345");
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

            string loadQry = "select * from book_Table order by title";
            SqlDataAdapter adapter = new SqlDataAdapter(loadQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.dataGridView.DataSource = dt;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>()) {
                tb.Text = "";
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
                editionTextBox.Text = row.Cells[1].Value.ToString();
                authorTextBox.Text = row.Cells[2].Value.ToString();
                editorTextBox.Text = row.Cells[3].Value.ToString();
                publisherTextBox.Text = row.Cells[4].Value.ToString();
                yearTextBox.Text = row.Cells[5].Value.ToString();
                isbnTextBox.Text = row.Cells[6].Value.ToString();
                languageTextBox.Text = row.Cells[7].Value.ToString();
                genreTextBox.Text = row.Cells[8].Value.ToString();
                pagesTextBox.Text = row.Cells[8].Value.ToString();
                rentedTextBox.Text = row.Cells[8].Value.ToString();
                onHandTextBox.Text = row.Cells[8].Value.ToString();
                totalTextBox.Text = row.Cells[8].Value.ToString();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();

            string srchQry = "select * from book_Table where title like'%" + searchTextbox.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(srchQry, con);
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
            int pages = 0, rented = 0, onHand = 0;
            if (titleTextBox.Text != "" && authorTextBox.Text != "" && publisherTextBox.Text != "" && yearTextBox.Text != "" && isbnTextBox.Text != "" && languageTextBox.Text != ""
                && genreTextBox.Text != "" && totalTextBox.Text != "") {
                
            
            
            }
        }
    }
}
