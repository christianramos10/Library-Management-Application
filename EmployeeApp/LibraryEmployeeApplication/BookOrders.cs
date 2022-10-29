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
using System.Xml.Linq;

namespace LibraryEmployeeApplication
{
    public partial class BookOrders : Form
    {

        MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=mylibrary;UID=libraryAdmin;PASSWORD=#Admin123");
        string orderID = "", empNum = "", empName = "", empRole = "";

        public BookOrders(string empNum, string empName, string empRole)
        {
            InitializeComponent();
            this.empNum = empNum;
            this.empName = empName;
            this.empRole = empRole;
            con.Open();
            this.loadOrders();
        }

        //Load orders from db
        private void loadOrders() {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();

            string loadQry = "select * from orders where orderStatus = 'pending' order by ID";
            MySqlDataAdapter adapter = new MySqlDataAdapter(loadQry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            this.dataGridView.DataSource = dt;
        }

        //Load books from selected order
        private void loadBooks(string orderID) {
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

            string[] books = booksISBN.Split(' ');

            foreach (var isbn in books) {
                if (isbn != " " || isbn != "") {
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

        private void completeBtn_Click(object sender, EventArgs e)
        {
            if (orderID != "")
            {
                DialogResult dialog = MessageBox.Show("Are you sure that you completed the order?", "Complete", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        string updateQuery = "update orders set orderStatus = 'completed' where id = '" + orderID + "'";
                        MySqlCommand command = new MySqlCommand(updateQuery, con);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Order was completed!");
                        this.loadOrders();
                        this.dataGridView2.DataSource = null;
                        this.dataGridView2.Rows.Clear();
                    }

                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to complete.");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menu = new menu(this.empNum, this.empName, this.empRole);
            menu.ShowDialog();
            con.Close();
            this.Close();
        }
    }
}
