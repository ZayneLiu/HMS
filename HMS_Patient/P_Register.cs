using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Patient
{
    public partial class P_Register : Form
    {
        public Form parent;
        public P_Register(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
            parent.Show();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0 && tbx_Detail.Text != "")
            {
                if (Server.Logics.Treatment_Record_Logics.Start_Treatment(listView1.SelectedItems[0].Text, P_Login.P_ID, tbx_Detail.Text))
                {
                    MessageBox.Show("挂号成功", "信息提示");
                }
                Close();
                parent.Show();
            }
            else
            {
                MessageBox.Show("尚未选择医生 或 尚未描述病情");
                return;
            }
        }

        private void P_Register_Load(object sender, EventArgs e)
        {
            foreach (string Department in Server.Models.Doctor.Get_All_Department())
            {
                cbx_Department.Items.Add(Department);
            }
            
            foreach (string Specialty in Server.Models.Doctor.Get_All_Specialty())
            {
                cbx_Specialty.Items.Add(Specialty);
            }

            var doctors = Server.Models.Doctor.Get_All_Doctors();
            if (doctors != null)
            {
                foreach (var doc in doctors)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {
                    doc.D_ID,
                    doc.D_Name,
                    doc.D_Gender,
                    doc.D_Title,
                    doc.D_Department,
                    doc.D_Specialty
                }));
                }
            }
        }

        private void Cbx_selected_item_Change(object sender, EventArgs e)
        {
            List<Server.Models.Doctor> doctors = new List<Server.Models.Doctor>();
            listView1.Items.Clear();
            if (cbx_Department.SelectedItem == null && cbx_Specialty.SelectedItem == null)
            {
                doctors = Server.Models.Doctor.Get_All_Doctors();
            }
            if (cbx_Department.SelectedItem == null && cbx_Specialty.SelectedItem != null)
            {
                doctors = Server.Models.Doctor.Get_Doctors_By_Specialty(cbx_Specialty.SelectedItem.ToString());
            }
            if (cbx_Department.SelectedItem != null && cbx_Specialty.SelectedItem == null)
            {
                doctors = Server.Models.Doctor.Get_Doctor_By_Department(cbx_Department.SelectedItem.ToString());
            }
            if (cbx_Department.SelectedItem != null && cbx_Specialty.SelectedItem != null)
            {
                doctors = Server.Models.Doctor.Get_Doctors_By_Department_And_Specialty(cbx_Department.SelectedItem.ToString(), cbx_Specialty.SelectedItem.ToString());
            }

            if (doctors != null)
            {
                foreach (var doc in doctors)
                {
                    listView1.Items.Add(new ListViewItem(new string[] {
                    doc.D_ID,
                    doc.D_Name,
                    doc.D_Gender,
                    doc.D_Title,
                    doc.D_Department,
                    doc.D_Specialty
                }));
                }
            }
            else
            {
                MessageBox.Show(string.Format("没有擅长 '{1}' 的 '{0}' 医生", cbx_Department.SelectedItem.ToString() ,cbx_Specialty.SelectedItem.ToString()), "信息提示");
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            cbx_Department.SelectedItem = null;
            cbx_Specialty.SelectedItem = null;
        }
    }
}
