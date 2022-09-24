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

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
