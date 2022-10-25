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
    public partial class rentedBooksList : Form
    {
        MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mylibrary;UID=libraryAdmin;PASSWORD=#Admin123");
        string orderID = "", empNum = "", empName = "";
        string[] books;

        public rentedBooksList(string empNum, string empName)
        {
            InitializeComponent();
            this.empNum = empNum;
            this.empName = empName;
            con.Open();
            this.loadOrders();
        }

        //Load orders from db
        private void loadOrders()
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();

            string loadQry = "select * from orders where orderStatus = 'completed' order by ID";
            MySqlDataAdapter adapter = new MySqlDataAdapter(loadQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.dataGridView.DataSource = dt;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu = new menu(this.empNum, this.empName);
            menu.ShowDialog();
            con.Close();
            this.Close();
        }

        private void handedInBtn_Click(object sender, EventArgs e)
        {
            if (orderID != "")
            {
                DialogResult dialog = MessageBox.Show("Are you sure that all the books have been handed in?", "Complete", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        //Update orders
                        string updateQuery = "update orders set orderStatus = 'handedIn' where id = '" + orderID + "'";
                        MySqlCommand command = new MySqlCommand(updateQuery, con);
                        command.ExecuteNonQuery();

                        //Update books availability and rented
                        foreach (var isbn in this.books)
                        {
                            if (isbn != " " || isbn != "")
                            {
                                try {
                                    string query = "update books set Available = Available+1, Rented = Rented-1 where isbn = '" + isbn + "'";
                                    command = new MySqlCommand(updateQuery, con);
                                    command.ExecuteNonQuery();
                                }

                                catch (Exception ex) {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                        MessageBox.Show("Order was handed in!");
                        this.loadOrders();
                        this.dataGridView2.DataSource = null;
                        this.dataGridView2.Rows.Clear();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to hand in.");
            }
        }

        //Load books from selected order
        private void loadBooks(string orderID)
        {
            string booksISBN = "";
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();
            DataTable booksTable = new DataTable();

            string loadQry = "select * from orders where ID = '" + orderID + "'";
            MySqlCommand cmd = new MySqlCommand(loadQry, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                booksISBN = dr["books"].ToString();
            }
            dr.Close();

            this.books = booksISBN.Split(' ');

            foreach (var isbn in books)
            {
                if (isbn != " " || isbn != "")
                {
                    string query = "select * from books where isbn = '" + isbn + "'";
                    MySqlDataAdapter booksAdapter = new MySqlDataAdapter(query, con);
                    booksAdapter.Fill(booksTable);
                }
            }

            this.dataGridView2.DataSource = booksTable;

        }

        private void cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = dataGridView.Rows[index];
            if (row != null)
            {
                orderID = row.Cells[0].Value.ToString();
                this.loadBooks(orderID);
            }
        }
    }
}
