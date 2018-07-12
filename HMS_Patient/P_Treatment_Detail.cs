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
    public partial class P_Treatment_Detail : Form
    {
        public Form parent;
        public string T_ID;
        public P_Treatment_Detail(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void P_Treatment_Detail_Load(object sender, EventArgs e)
        {
            var p = Server.Models.Treatment_Record.Get_Treatment_Record_By_ID(T_ID);
            var doctor = Server.Models.Doctor.Get_Doctor_By_ID(p.D_ID);
            label7.Text = p.T_ID.ToString();
            label10.Text = p.T_Time.ToString();
            label8.Text = doctor.D_Name;


            var Treatment = Server.Models.Treatment_Record.Get_Treatment_Record_By_ID(T_ID);
            var meds = Treatment.Meds;
            foreach (var item in meds)
            {
                //item.Key.M_Name;
                //item.Key.M_Price;
                //item.Value
            }

            var inspections = Treatment.Inspections;

        }

    }
}
