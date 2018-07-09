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
    public partial class P_Tip_2 : Form
    {
        public P_Tip_2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            P_Center frm = new P_Center();
            frm.Show();
            this.Close();
        }
    }
}
