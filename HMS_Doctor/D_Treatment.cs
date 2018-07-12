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

        private void label_Prescride_Click(object sender, EventArgs e)
        {
            D_Prescribe frm = new D_Prescribe();
            Hide();
            frm.Show();
        }

        private void label_D_Inspect_Click(object sender, EventArgs e)
        {
            D_Inspect frm = new D_Inspect();
            Hide();
            frm.Show();
        }

        private void label_Return_Center_Click(object sender, EventArgs e)
        {
            D_Personal_Center frm = new D_Personal_Center();
            Hide();
            frm.Show();
        }
    }
}
