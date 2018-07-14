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
    public partial class Admin_Doc_Add : Form
    {
        public Form parent;
        public Admin_Doc_Add(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox3.Text;
            int age = int.Parse(textBox4.Text);
            string gender = comboBox1.Text;
            string title = textBox5.Text;
            string specialty = textBox6.Text;
            string department = textBox7.Text;
            string tel = textBox8.Text;
            var p = Server.Logics.Doctor_Logics.Add_If_Info_Valid(id,name,gender,age,tel,title,specialty,department);
        }
    }
}
