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
    
    public partial class P_Message_Edit : Form
    {
        public P_Message parent;
        public P_Message_Edit(P_Message form)
        {
            InitializeComponent();
            parent = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = Server.Models.Patient.Get_Patient_By_ID(P_Login.P_ID);
            a.P_Name = textBox1.Text;
            a.P_Gender = comboBox1.Text;
            a.P_Age =int.Parse( textBox3.Text);
            a.P_Med_History = textBox4.Text;
            a.P_Tel = textBox5.Text;
            a.SaveChanges();
            if(a.SaveChanges())
            {
                MessageBox.Show("修改成功");
                this.Close();
                parent.Refresh_Info();
                parent.Show();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void P_Message_Edit_Load(object sender, EventArgs e)
        {
            var a = Server.Models.Patient.Get_Patient_By_ID(P_Login.P_ID);
            textBox1.Text = a.P_Name;
            comboBox1.Text = a.P_Gender;
            textBox3.Text = a.P_Age.ToString();
            textBox4.Text = a.P_Med_History;
            textBox5.Text = a.P_Tel;
        }
    }
}
