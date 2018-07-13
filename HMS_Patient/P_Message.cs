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
    public partial class P_Message : Form
    {
        public Form parent;
        public P_Message(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void P_Message_Load(object sender, EventArgs e)
        {
            Refresh_Info();
        }

        public void Refresh_Info()
        {
            var p = Server.Models.Patient.Get_Patient_By_ID(P_Login.P_ID);
            label_name.Text = p.P_Name;
            label_Age.Text = p.P_Age.ToString();
            label_Gender.Text = p.P_Gender;
            label_Med_History.Text = p.P_Med_History;
            label_Tel.Text = p.P_Tel;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_Message_Edit frm = new P_Message_Edit(this);
            frm.Show();
            Hide();
        }
    }
}
