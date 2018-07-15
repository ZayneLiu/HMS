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
    public partial class Admin_Patient_Management : Form
    {
        public Form parent;
        public Admin_Patient_Management(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void Admin_Patient_Management_Load(object sender, EventArgs e)
        {
            Tbx_Seach_By_Name.Visible = false;
            var adapter = Server.DB.GetAdapter("select * from patient");
            adapter.Fill(Server.DB.dataSet, "Patient");

            dataGridView1.DataSource = Server.DB.dataSet.Tables["Patient"].DefaultView;
        }

        private void Combobox_Search_By_Kind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combobox_Search_By_Kind.SelectedItem.ToString() == "按姓名查询")
            {
                Tbx_Seach_By_Name.Visible = true;
                return;
            }
            
            Server.DB.dataSet.Tables["Patient"].DefaultView.RowFilter = string.Format("P_Gender = '{0}'", )
        }

        private void cbx_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
