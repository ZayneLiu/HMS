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
        public static string ID;
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Server.Logics.Admin.Is_Login_Info_Valid(Tbx_Username.Text, Tbx_Password.Text))
            {
                ID = Tbx_Username.Text;
                //Server.Logics.();
                Admin_Landing_Page frm = new Admin_Landing_Page(this);
                frm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");

            }
            
        }
    }
}
