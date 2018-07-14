using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Partial
{
    
    public partial class Admin_Doc_Management : Form
    {
        public Form parent;
        public Admin_Doc_Management(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        SqlDataAdapter adapter = Server.DB.GetAdapter("select * from Doctor");

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void Admin_Doc_Management_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            cbx_Department.Items.Clear();
            var departments = Server.Models.Doctor.Get_All_Department();
            cbx_Department.Items.AddRange(departments.ToArray());

            try
            {
                Server.DB.dataSet.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            adapter.Fill(Server.DB.dataSet, "Doctor");
            Server.DB.dataSet.Tables["Doctor"].DefaultView.RowFilter = "";
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Doctor"].DefaultView;
            cbx_gender.Visible = false;
            Tbx_Seach_By_Name.Visible = false;
            cbx_Department.Visible = false;
        }

        private void cbx_searchMode_Selected_Index_Changed(object sender, EventArgs e)
        {
            string searchMode = Combobox_Search_By_Kind.SelectedItem.ToString();
            switch (searchMode)
            {
                case "按姓名查询":
                    cbx_Department.Visible = false;
                    cbx_gender.Visible = false;
                    Tbx_Seach_By_Name.Visible = true;
                    break;
                case "按性别查询":
                    cbx_Department.Visible = false;
                    Tbx_Seach_By_Name.Visible = false;
                    cbx_gender.Visible = true;
                    break;
                case "按科室查询":
                    Tbx_Seach_By_Name.Visible = false;
                    cbx_gender.Visible = false;
                    cbx_Department.Visible = true;
                    break;
            }
        }

        private void Tbx_Seach_By_Name_TextChanged(object sender, EventArgs e)
        {
            string searchMode = Combobox_Search_By_Kind.SelectedItem.ToString();
            string filter = string.Format("D_Name like '%{0}%'", Tbx_Seach_By_Name.Text);
            Server.DB.dataSet.Tables["Doctor"].DefaultView.RowFilter = filter;
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Doctor"].DefaultView;
        }

        private void cbx_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            string department = cbx_Department.SelectedItem.ToString();
            string filter = string.Format("D_Department = '{0}'", department);
            Server.DB.dataSet.Tables["Doctor"].DefaultView.RowFilter = filter;
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Doctor"].DefaultView;
        }

        private void cbx_gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gender = cbx_gender.SelectedItem.ToString();
            string filter = string.Format("D_Gender = '{0}'", gender);
            Server.DB.dataSet.Tables["Doctor"].DefaultView.RowFilter = filter;
            dataGridView1.DataSource = Server.DB.dataSet.Tables["Doctor"].DefaultView;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void Edit_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            foreach (DataGridViewRow item in rows)
            {
                string id = item.Cells[0].Value.ToString();
                Server.DB.Execute(string.Format("Delete from Doctor where D_ID='{0}'", id));
            }
            RefreshData();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admin_Doc_Add frm = new  Admin_Doc_Add(this);
            frm.Show();
            Hide();
        }
    }
}
