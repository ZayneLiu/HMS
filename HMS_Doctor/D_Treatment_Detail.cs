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
    public partial class D_Treatment_Detail : Form
    {
        public D_Treatment_Detail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            D_Treatment_Record frm = new D_Treatment_Record();
            Hide();
            frm.Show(); 
        }
    }
}
