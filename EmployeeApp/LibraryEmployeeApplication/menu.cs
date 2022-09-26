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
        string name, employeeNum;
        public menu(string name, string employeeNum)
        {
            InitializeComponent();
            this.name = name;   
            this.employeeNum = employeeNum; 
        }

        private void booksdbBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            booksList booksList = new booksList();
            booksList.ShowDialog();
            this.Close();
        }

        private void clientRegistryBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            clientList clientList = new clientList();
            clientList.ShowDialog();
            this.Close();
        }

        private void rentedBooksBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            rentedBooksList rentedBooksList = new rentedBooksList();
            rentedBooksList.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            mainForm mainForm = new mainForm(); 
            mainForm.ShowDialog();
            this.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
