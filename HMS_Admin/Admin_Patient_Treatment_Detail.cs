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
    public partial class Admin_Patient_Treatment_Detail : Form
    {
        public Form parent;
        public Admin_Patient_Treatment_Detail(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void Admin_Patient_Treatment_Detail_Load(object sender, EventArgs e)
        {
            double total = 0;
            var records = Server.Models.Treatment_Record.Get_All_Treatment_Records();
            foreach (var record in records)
            {
                var patient = Server.Models.Patient.Get_Patient_By_ID(record.P_ID);
                label_P_Name.Text = patient.P_Name;
                var doctor = Server.Models.Doctor.Get_Doctor_By_ID(record.D_ID);
                label_D_Department.Text = doctor.D_Department;
                label_D_Name.Text = doctor.D_Name;
                label_T_ID.Text = record.T_ID.ToString();
                label_Detail.Text = record.Detail.ToString();
                label_T_Time.Text = record.T_Time.ToString();

                int T_ID = record.T_ID;
                // 填充药品列表
                var dict_meds_count = Server.Models.Treatment_Record.Get_Treatment_Record_By_ID(T_ID).Meds;
                foreach (var pair in dict_meds_count)
                {
                    total += pair.Key.M_Price * double.Parse(pair.Value.ToString());

                    listView_Meds.Items.Add(new ListViewItem(new string[] {
                        pair.Key.M_Name,
                        pair.Value.ToString(),
                        pair.Key.M_Price.ToString(),
                        pair.Key.M_Effect.ToString()
                    }));
                }

                // 填充检查列表
                var inspections = Server.Models.Treatment_Record.Get_Treatment_Record_By_ID(T_ID).Inspections;
                foreach (var inspection in inspections)
                {
                    total += inspection.I_Price;

                    listView_Inspections.Items.Add(new ListViewItem(new string[] {
                        inspection.I_Name,
                        inspection.I_Price.ToString()
                    }));
                }
            }
            label_Total.Text = total.ToString();
        }
    }
}
