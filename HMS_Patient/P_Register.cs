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
            this.Close();
            parent.Show();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if(Server.Logics.Treatment_Record_Logics.Start_Treatment(listView1.SelectedItems[0].Text, P_Login.P_ID,Detail.Text))
            {
                MessageBox.Show("挂号成功", "信息提示");
            }
            this.Close();
            parent.Show();
        }

        private void P_Register_Load(object sender, EventArgs e)
        {
            foreach (string Department in Server.Models.Doctor.Get_All_Department())
            {
                comboBox1.Items.Add(Department);
            }
            
            foreach (string Specialty in Server.Models.Doctor.Get_All_Specialty())
            {
                comboBox2.Items.Add(Specialty);
            }
        }

        private void Depart_Change(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var a = Server.Models.Doctor.Get_Doctor_By_Department(comboBox1.SelectedItem.ToString());
            foreach (var doc in a)
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

        private void Specialty_Change(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var a = Server.Models.Doctor.Get_Doctor_By_Department_And_Specialty(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            if(a.Count!=0)
            {
                foreach (var doc in a)
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
                MessageBox.Show("没有擅长"+comboBox2.SelectedItem.ToString()+"的医生", "信息提示");
            }
            
        }
    }
}
