using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Partial.Med_Management
{
    public partial class Meds_Management_Landing_Page : Form
    {
        Admin_Landing_Page Landing_Page;
        public Meds_Management_Landing_Page(Admin_Landing_Page admin_Landing_Page)
        {
            InitializeComponent();
            Landing_Page = admin_Landing_Page;
        }

        private void Meds_Management_Page_Load(object sender, EventArgs e)
        {
            //默认选中一个RadioBtn
            RadioBtn_Search_By_Name.Checked = true;
            DGV_Refresh();
            
        }

        public void DGV_Refresh()
        {
            //dataGridView1.DataSource = DAL.DB.dataset.Tables["Med"];
        }

        private void Med_Add_Click(object sender, EventArgs e)
        {
            //Hide();
            new Meds_Management_Edit_Med_Page(this).ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除所选药品？", "警告", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                //删除所有选中行
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    //new DAL.Models.Med((int)dataGridView1.SelectedRows[i].Cells["Med_Id"].Value).Delete();
                }
                //更新
                DGV_Refresh();
                //DAL.Models.Med.adapter.Update(DAL.DB.dataset.Tables["Med"]);
            };
        }

        private void Update_Click(object sender, EventArgs e)
        {
            //new Meds_Management_Edit_Med_Page(this, new DAL.Models.Med()
            //{
            //}).Show();
            //======TBC======

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
            Landing_Page.Show();
        }

        private void RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioBtn_Search_By_Kind.Checked = false;
            RadioBtn_Search_By_Name.Checked = false;
            var btn = (RadioButton)sender;
            btn.Checked = true;
        }
    }
}
