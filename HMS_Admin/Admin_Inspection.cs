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
    public partial class Admin_Inspection : Form
    {
        public Form parent;
        public Admin_Inspection(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void Admin_Ins_Add_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Admin_Ins_Add frm = new Admin_Ins_Add(this);
            frm.Show();
            Hide();
        }
    }
}
