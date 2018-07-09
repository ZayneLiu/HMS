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
        public P_Center()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Register frm = new P_Register();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_Message frm = new P_Message();
            frm.Show();
        }
    }
}
