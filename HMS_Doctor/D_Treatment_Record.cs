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
    public partial class D_Treatment_Record : Form
    {
        public D_Treatment_Record()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_Management_Patient frm = new D_Management_Patient();
            frm.Show();
            Hide();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            D_Personal_Center frm = new D_Personal_Center();
            Hide();
            frm.Show();
        }


        private void D_Inspect_Record_Load(object sender, EventArgs e)
        {
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
                        record.T_ID .ToString (),
                        patient.P_Name ,
                        record.T_Time .ToString(),
                        record.Detail
                    }));
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            var records = Server.Models.Doctor.GeMyTreatmentRecords(D_Login.D_ID);
            foreach (var record in records)
            {
                var patient = Server.Models.Patient.Get_Patient_By_ID(record.P_ID);
                listView1.Items.Add(new ListViewItem(new string[]
                    {
                        record.T_ID .ToString (),
                        patient.P_Name ,
                        record.T_Time .ToString(),
                        record.Detail
                    }));
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            D_Treatment_Record frm = new D_Treatment_Record();
            Hide();
            frm.Show();
        }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    listView1.Items.Clear();
        //    var Suc = Server.Models.Doctor.GeMyTreatmentRecords();
        //}
    }
}
