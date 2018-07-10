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

    public partial class P_Center : Form
    {
        public P_Login p_Login; 
        public P_Center(P_Login login)
        {
            InitializeComponent();
            p_Login = login;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Register frm = new P_Register(this);
            frm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_Message frm = new P_Message();
            frm.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            P_Med frm = new P_Med();
            frm.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            P_Med_Project frm = new P_Med_Project();
            frm.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            P_Pay_Leave frm = new P_Pay_Leave();
            frm.Show();
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            p_Login.Show();
        }
    }
}
