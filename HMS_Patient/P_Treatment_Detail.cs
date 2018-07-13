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
            label4.Text = p.Detail;


            var Treatment = Server.Models.Treatment_Record.Get_Treatment_Record_By_ID(T_ID);
            // 总价
            double total = 0;
            var meds = Treatment.Meds;
            if (meds != null)
            {
                foreach (var med in meds)
                {
                    total += med.Key.M_Price * med.Value;
                    listView1.Items.Add(new ListViewItem(new string[] {
                    //name
                    med.Key.M_Name,
                    //count
                    med.Value.ToString(),
                    //price
                    med.Key.M_Price.ToString(),
                    //effect
                    med.Key.M_Effect
                }));
                }

            }
            var inspections = Treatment.Inspections;
            if (inspections != null)
            {
                foreach (var inspection in inspections)
                {
                    total += inspection.I_Price;
                    listView2.Items.Add(new ListViewItem(new string[] {
                    inspection.I_Name,
                    inspection.I_Price.ToString()
                }));
                }

            }
            label11.Text = total.ToString();
        }
    }
}
