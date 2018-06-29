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

using BLL.Public;


namespace UI
{
    public partial class patientLogin : Form
    {
        public patientLogin()
        {
            InitializeComponent();
        }
        public Doctor myPartent;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Login.is_login_valid(textBox1.Text, textBox2.Text))
            {
                patient frm = new patient();
                frm.MdiParent = this.myPartent;
                frm.Show();
                this.Visible = false;
            }
           
        }
    }
}