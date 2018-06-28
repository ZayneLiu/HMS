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
    public partial class patient : Form
    {
        public patient()
        {
            InitializeComponent();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;  //此处传入患者的个人信息
            this.listView2.Visible = false;
        }

        private void patient_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.listView2.Visible = false;
        }

        private void 药品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.listView2 .Visible = true;
        }
    }
}
