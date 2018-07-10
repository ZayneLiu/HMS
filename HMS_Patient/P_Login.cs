using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Patient
{
    public partial class P_Login : Form
    {
        public static string P_ID = "";
        public P_Login()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Server.Logics.Patient_Logics.Is_Login_Info_Valid(Tbx_Username.Text, Tbx_Password.Text))
            {
                P_ID = Tbx_Username.Text;
                P_Center frm = new P_Center(this);
                frm.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");

            }
        }

        private void Btn_Sign_Click(object sender, EventArgs e)
        {
            P_Sign frm = new P_Sign(this);
            frm.Show();
            Hide();
        }
    }
}
