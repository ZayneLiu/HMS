using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Doctor
{
    public partial class D_Login : Form
    {
        public D_Login()
        {
            InitializeComponent();
        }
        public static string D_ID;
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Server.Logics.Doctor_Logics.Is_Login_Info_Valid(Tbx_Username.Text, Tbx_Password.Text))
            {
                D_ID = Tbx_Username.Text;
                D_Personal_Center frm = new D_Personal_Center();
                frm.Show();
                Hide();
            }
            else 
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
