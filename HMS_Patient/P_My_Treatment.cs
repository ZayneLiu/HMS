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
    public partial class P_My_Treatment : Form
    {
        public Form parent;
        public P_My_Treatment(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Treatment_Detail frm = new P_Treatment_Detail(this);
            frm.T_ID = listView1.SelectedItems[0].SubItems[0].Text.ToString();
            frm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void P_My_Treatment_Load(object sender, EventArgs e)
        {
            var patient = Server.Models.Patient.Get_Patient_By_ID(P_Login.P_ID);
            var b= patient.Get_My_Treatment_Records();
            foreach (var a in b)
            {
                var doctor = Server.Models.Doctor.Get_Doctor_By_ID(a.D_ID);
                listView1.Items.Add(new ListViewItem(new string[]{
                      a.T_ID.ToString(),
                      doctor.D_Name.ToString(),
                      a.T_Time.ToString(),
                      a.Detail
                  }));
            }

        }
    }
}
