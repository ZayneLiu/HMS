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
            listView1.Clear();
            var _Name_And_Gender_Search = Server.Models.Patient.Get_Patients_By_Gender_And_Name(comboBox1.Text ,textBox1 .Text );
            foreach (var Patient in _Name_And_Gender_Search )
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                Patient.P_Name ,
                Patient.P_Gender ,
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
            D_Treatment frm = new D_Treatment();
            Hide();
            frm.Show();
        }

        public static string P_ID;
        private void D_Management_Patient_Load(object sender, EventArgs e)
        {
            P_ID = listView1.SelectedItems[0].SubItems[0].Text;
            // 返回我的所有记录 集合

            listView1.Clear();
            var Patients = Server.Models.Patient.Get_All_Patient();
            foreach (var Patient in Patients)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                Patient .P_ID ,
                Patient.P_Name ,
                Patient.P_Gender ,
                Patient.P_Age.ToString (),
                Patient.P_Tel ,
                Patient.P_Med_History
                }));
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            D_Personal_Center frm = new D_Personal_Center();
            Hide();
            frm.Show();
        }
    }
}
