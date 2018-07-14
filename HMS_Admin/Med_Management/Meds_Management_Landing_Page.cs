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
            RefreshData();
        }

        public void RefreshData()
        {
            tbx_search.Visible = false;
            try
            {
                Server.DB.dataSet.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Server.DB.GetAdapter("select * from Med").Fill(Server.DB.dataSet, "Med");
            Server.DB.dataSet.Tables["Med"].DefaultView.RowFilter = "";
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Med"].DefaultView;
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
                    new Server.Models.Med((int)dataGridView1.SelectedRows[i].Cells["M_ID"].Value).Delete();
                }
                //更新
                RefreshData();
                //DAL.Models.Med.adapter.Update(DAL.DB.dataset.Tables["Med"]);
            };
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 )
            {
                MessageBox.Show("请选中一个药品");
                return;
            }
            var cells = dataGridView1.SelectedRows[0].Cells;
            new Meds_Management_Edit_Med_Page(this, new Server.Models.Med((int)cells["M_ID"].Value)
            {
                M_Name = cells["M_Name"].Value.ToString(),
                M_Category = cells["M_Category"].Value.ToString(),
                M_Effect = cells["M_Effect"].Value.ToString(),
                M_Price = (double)cells["M_Price"].Value,
                M_Stock = (int)cells["M_Stock"].Value,
                M_Unit = cells["M_Unit"].Value.ToString()
            }).ShowDialog();
            //======TBC======

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
            Landing_Page.Show();
        }

        //private void RadioBtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    var btn = (RadioButton)sender;
        //    btn.Checked = true;
        //}

        private void cbx_search_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_search_mode.SelectedItem.ToString() != "按名称搜索")
            {
                Server.DB.dataSet.Tables["Med"].DefaultView.RowFilter = string.Format("M_Category = '{0}'", cbx_search_mode.SelectedItem.ToString());
                dataGridView1.DataSource = Server.DB.dataSet.Tables["Med"].DefaultView;
                return;
            }
            tbx_search.Visible = true;
            Server.DB.dataSet.Tables["Med"].DefaultView.RowFilter = "";
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Med"].DefaultView;

        }

        private void tbx_search_TextChanged(object sender, EventArgs e)
        {
            if (cbx_search_mode.SelectedItem.ToString() != "按名称搜索")
            {
                Server.DB.dataSet.Tables["Med"].DefaultView.RowFilter = string.Format("M_Category = '{0}' and M_Name like '%{1}%'", cbx_search_mode.SelectedItem.ToString(), tbx_search.Text);
                dataGridView1.DataSource = Server.DB.dataSet.Tables["Med"].DefaultView;
                return;
            }
            Server.DB.dataSet.Tables["Med"].DefaultView.RowFilter = string.Format("M_Name like '%{0}%'", tbx_search.Text);
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Med"].DefaultView;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
