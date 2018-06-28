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
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = false;
        }

        private void 我的信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;  //此处传入医生的个人信息
            this.panel2.Visible = false;
        }

        private void 我的病区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;  //此处listview显示病人录入的信息
            this.panel1.Visible = false;
        }
        private void 开药ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            KaiyaoRecord frm = new KaiyaoRecord();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            choiceYAO frm = new choiceYAO();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
