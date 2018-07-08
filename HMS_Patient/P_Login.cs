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
        public P_Login()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            //P_Center frm = new P_Center();
            //frm.Show();
        }

        private void Btn_Sign_Click(object sender, EventArgs e)
        {
            P_Register frm = new P_Register();
            frm.Show(); 
        }
    }
}
