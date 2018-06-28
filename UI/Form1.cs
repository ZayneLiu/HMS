using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//需要数据的地方要添加这个命名空间
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //假设在此处调用数据
            string s = Login.GetData();
            //改变窗体标题
            this.Text = s;
        }

        private void 医生登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doctorLogin frm = new doctorLogin();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 患者登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientLogin frm = new patientLogin();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 患者注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientSign frm = new patientSign();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
