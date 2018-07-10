using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Partial
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //Server.Logics.();
            Hide();
            new Admin_Landing_Page().Show();
        }
    }
}
