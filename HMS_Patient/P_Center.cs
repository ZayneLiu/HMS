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
        public Form parent; 
        public P_Center(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void GH_Click(object sender, EventArgs e)
        {
            P_Register frm = new P_Register(this);
            frm.Show();
            Hide();
        }

        private void Info_Click(object sender, EventArgs e)
        {
            P_Message frm = new P_Message(this);
            frm.Show();
            Hide();
        }

        private void Med_Click(object sender, EventArgs e)
        {
            P_Med frm = new P_Med(this);
            frm.Show();
            Hide();
        }

        private void Inspection_Click(object sender, EventArgs e)
        {
            P_Med_Project frm = new P_Med_Project();
            frm.Show();
            Hide();
        }

        private void Check_And_Exit_Click(object sender, EventArgs e)
        {
            P_Pay_Leave frm = new P_Pay_Leave();
            frm.Show();
            Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            P_My_Treatment frm = new P_My_Treatment(this);
            frm.Show();
            Hide();
        }
    }
}
