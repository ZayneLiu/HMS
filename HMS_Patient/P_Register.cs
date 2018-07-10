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
    public partial class P_Register : Form
    {
        public P_Center p_Center;
        public P_Register(P_Center Center)
        {
            InitializeComponent();
            p_Center = Center;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Center frm = new P_Center();
            frm.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_Tip_2 frm = new P_Tip_2();
            frm.Show();
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
