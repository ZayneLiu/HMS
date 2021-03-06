﻿using System;
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
            var name_search = Server.Models.Doctor.GeMyTreatmentRecords(D_Login.D_ID, textBox1.Text);
            if (name_search == null)
            {
                return;
            }
            foreach (var record in name_search )
            {
                var patient = Server.Models.Patient.Get_Patient_By_ID(record.P_ID);
                listView1.Items.Add(new ListViewItem(new string[] {
                    record.T_ID.ToString(),
                    record.T_Time.ToString(),
                    patient.P_Name ,
                    patient.P_Gender,
                    patient.P_Age.ToString (),
                    patient.P_Tel ,
                    patient.P_Med_History
                }));
            }
        }

        private void label_All_Search_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var records  = Server.Models.Doctor.GeMyTreatmentRecords(D_Login.D_ID);
            if (records == null)
            {
                MessageBox.Show("没有挂号的病人。");
            }
            else
            {
                foreach (var record in records)
                {
                    var patient = Server.Models.Patient.Get_Patient_By_ID(record.P_ID);
                    listView1.Items.Add(new ListViewItem(new string[] {
                    record.T_ID.ToString(),
                    record.T_Time.ToString(),
                    patient.P_Name ,
                    patient.P_Gender ,
                    patient.P_Age.ToString (),
                    patient.P_Tel ,
                    patient.P_Med_History
                }));
                }
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
                        record.T_Time.ToString(),
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
