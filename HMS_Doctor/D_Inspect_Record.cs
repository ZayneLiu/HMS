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
    public partial class D_Inspect_Record : Form
    {
        public D_Inspect_Record()
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
            var patient = Server.Models.Patient.Get_Patient_By_ID(D_Management_Patient.P_ID);
            var records = patient.Get_My_Treatment_Records();
            foreach (var record in records )
            {
                listView1.Items.Add(new ListViewItem(new string[]
                    {
                        
                    }));
            }
        }
    }
}
