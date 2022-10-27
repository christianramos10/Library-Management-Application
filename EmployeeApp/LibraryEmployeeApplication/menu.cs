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
    public partial class menu : Form
    {
        string empNum = "", empName = "", empRole = "";

        //Menu from main
        public menu(string empNum, string empName, string empRole)
        {
            InitializeComponent();
            this.empNum = empNum;
            this.empName = empName;
            this.empRole = empRole;
        }

        //Menu from others
        public menu(string empNum, string empName)
        {
            InitializeComponent();
            this.empNum = empNum;
            this.empName = empName;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            welcomeLabel.Text += " " + this.empName;
        }

        private void booksdbBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            booksList booksList = new booksList(this.empNum, this.empName);
            booksList.ShowDialog();
            this.Close();
        }

        private void clientRegistryBtn_Click(object sender, EventArgs e)
        {
            if (this.empRole == "administrator")
            {
                this.Hide();
                clientList clientList = new clientList(this.empNum, this.empName);
                clientList.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("You are not authorized for this section.");
            }
        }

        private void rentedBooksBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            rentedBooksList rentedBooksList = new rentedBooksList(this.empNum, this.empName);
            rentedBooksList.ShowDialog();
            this.Close();
        }

        private void bookOrdersBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookOrders orderList = new BookOrders(this.empNum, this.empName);
            orderList.ShowDialog();
            this.Close();
        }

        private void employeeDbBtn_Click(object sender, EventArgs e)
        {
            if (this.empRole == "administrator")
            {
                this.Hide();
                employeeList empList = new employeeList(this.empNum, this.empName);
                empList.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("You are not authorized for this section.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            mainForm mainForm = new mainForm(); 
            mainForm.ShowDialog();
            this.Close();
        } 
    }
}
