using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class patientSign : Form
    {
        public patientSign()
        {
            InitializeComponent();
        }

        private void patientSign_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("注册成功，前往登陆");
            patientLogin frm = new patientLogin();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
