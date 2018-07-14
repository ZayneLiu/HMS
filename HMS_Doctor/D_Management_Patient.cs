using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Doctor
{
    public partial class D_Management_Patient : Form
    {
       
     
        public D_Management_Patient()
        {
            InitializeComponent();

        }

        private void label_Name_Search_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var _Name_And_Gender_Search = Server.Models.Patient.Get_Patients_By_Gender_And_Name(comboBox1.Text ,textBox1 .Text );
            if (_Name_And_Gender_Search == null)
            {
                return;
            }
            foreach (var Patient in _Name_And_Gender_Search )
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                Patient .P_ID,
                Patient.P_Name ,
                Patient.P_Gender,
                Patient.P_Age.ToString (),
                Patient.P_Tel ,
                Patient.P_Med_History
                }));
            }
        }

        private void label_All_Search_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var Patients  = Server.Models.Patient .Get_All_Patient ();
            foreach (var  Patient in Patients )
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                Patient.P_ID,
                Patient.P_Name ,
                Patient.P_Gender ,
                Patient.P_Age.ToString (),
                Patient.P_Tel ,
                Patient.P_Med_History 
                }));
            }
        }


        private void label_Prescride_Click(object sender, EventArgs e)
        {
            
        }

        private void label_Prescride_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择病人开始坐诊");
            }
            T_ID = int.Parse(listView1.SelectedItems[0].Text);
            D_Treatment frm = new D_Treatment();
            Hide();
            frm.Show();
        }

        public static int T_ID;
         
        private void D_Management_Patient_Load(object sender, EventArgs e)
        {

            // 返回我的所有记录 集合
            
            listView1.Items.Clear();
            var records = Server.Models.Doctor.GeMyTreatmentRecords(D_Login.D_ID);

            if (records == null)
            {
                return;
            }
            foreach (var record in records)
            {
                var patient = Server.Models.Patient.Get_Patient_By_ID(record.P_ID);
                listView1.Items.Add(new ListViewItem(new string[]
                    {
                        record.T_ID.ToString(),
                        patient.P_ID,
                        patient.P_Name,
                        patient.P_Gender,
                        patient.P_Age.ToString(),
                        patient.P_Tel,
                        patient.P_Med_History
                    }));
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            D_Personal_Center frm = new D_Personal_Center();
            Hide();
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
