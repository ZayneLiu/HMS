using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UI
{

    public partial class doctorLogin : Form
    {

        public doctorLogin()
        {
            InitializeComponent();
        }
        public Doctor myPartent;
        private void button1_Click(object sender, EventArgs e)
        {

            Doctor frm = new Doctor();
            frm.MdiParent = this.myPartent;
            frm.Show();
            this.Visible = false;
        }
    }
}
    
