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
    public partial class D_Treatment : Form
    {
        public D_Treatment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            D_Inspect frm = new D_Inspect();
            Hide();
            frm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            D_Prescribe frm = new D_Prescribe();
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            D_Personal_Center frm = new D_Personal_Center();
            Hide();
            frm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_Management_Patient frm = new D_Management_Patient();
            Hide();
            frm.Show();
        }
    }
}
