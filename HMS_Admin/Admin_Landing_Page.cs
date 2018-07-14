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
    public partial class Admin_Landing_Page : Form
    {
        public Form parent;
        public Admin_Landing_Page(Form form)
        {
            InitializeComponent();
            parent = form;
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Hide();
            new Dialog_On_Exit(this).Show();
        }

        private void Meds_Management_Click(object sender, EventArgs e)
        {
            Hide();
            new Med_Management.Meds_Management_Landing_Page(this).Show();
        }

        private void Doc_Management_Click(object sender, EventArgs e)
        {
            Admin_Doc_Management frm = new Admin_Doc_Management(this);
            frm.Show();
            Hide();
        }

        private void Patient_Click(object sender, EventArgs e)
        {
            Admin_Patient_Management frm =new Admin_Patient_Management(this);
            frm.Show();
            Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_Inspection frm = new Admin_Inspection(this);
            frm.Show();
            Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Admin_Ptient_Record frm = new Admin_Ptient_Record(this);
            frm.Show();
            Hide();
        }
    }
}