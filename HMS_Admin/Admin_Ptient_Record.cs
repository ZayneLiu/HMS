using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Partial
{
    public partial class Admin_Ptient_Record : Form
    {
        public Form parent;
        public Admin_Ptient_Record(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_Patient_Treatment_Detail frm = new Admin_Patient_Treatment_Detail(this);
            frm.Show();
            Hide();
        }

        private void Admin_Ptient_Record_Load(object sender, EventArgs e)
        {
            var deps = Server.Models.Doctor.Get_All_Department().ToArray();
            cbx_dep.Items.AddRange(deps);


            RefreshData();

        }

        private void RefreshData()
        {
            cbx_search_mode.SelectedItem = null;
            cbx_dep.Visible = false;
            tbx_search.Visible = false;


            try
            {
                Server.DB.dataSet.Tables["Treatment_Record"].Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var adapter = Server.DB.GetAdapter("select T_ID, T_Time, D_Name, P_Name, D_Department from Treatment_Record join Doctor on Treatment_Record.D_ID=Doctor.D_ID join Patient on Treatment_Record.P_ID=Patient.P_ID");
            adapter.Fill(Server.DB.dataSet, "Treatment_Record");
            Server.DB.dataSet.Tables["Treatment_Record"].DefaultView.RowFilter = "";
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Treatment_Record"].DefaultView;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tbx_search_TextChanged(object sender, EventArgs e)
        {
            if (cbx_search_mode.SelectedItem.ToString() == "按医生姓名查询")
            {
                Server.DB.dataSet.Tables["Treatment_Record"].DefaultView.RowFilter = string.Format("D_Name like '%{0}%'", tbx_search.Text);
            }
            else
            {
                Server.DB.dataSet.Tables["Treatment_Record"].DefaultView.RowFilter = string.Format("P_Name like '%{0}%'", tbx_search.Text);
            }
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Treatment_Record"].DefaultView;
        }

        private void cbx_search_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_search_mode.SelectedItem.ToString() == "按科室查询")
            {
                tbx_search.Visible = false;
                cbx_dep.Visible = true;
                return;
            }
            tbx_search.Visible = true;
            cbx_dep.Visible = false;
        }

        private void cbx_dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server.DB.dataSet.Tables["Treatment_Record"].DefaultView.RowFilter = string.Format("D_Department = '{0}'", cbx_dep.SelectedItem.ToString());
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Treatment_Record"].DefaultView;

        }
    }
}
