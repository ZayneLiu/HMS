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
    public partial class P_Pay_Leave : Form
    {
        public P_Pay_Leave()
        {
            InitializeComponent();
        }

        private void P_Pay_Leave_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Center frm = new P_Center();
            frm.Show();
            Close();
        }
    }
}
