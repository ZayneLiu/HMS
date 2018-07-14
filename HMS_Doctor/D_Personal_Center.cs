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
    public partial class D_Personal_Center : Form
    {
        public D_Personal_Center()
        {
            InitializeComponent();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_Management_Patient frm = new D_Management_Patient();
            Hide();
            frm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            D_Treatment_Record frm = new D_Treatment_Record();
            Hide();
            frm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            D_Treatment_Detail frm = new D_Treatment_Detail();
            Hide();
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            D_Personal_Information frm = new D_Personal_Information();
            Hide();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出登录！", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


    }
}
