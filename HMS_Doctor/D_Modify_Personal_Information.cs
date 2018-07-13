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
    public partial class D_Modify_Personal_Information : Form
    {
        public Form parent;
        public D_Modify_Personal_Information(Form form  )
        {
            InitializeComponent();
            parent = form;
        }

        private void D_Modify_Click(object sender, EventArgs e)
        {
            try
            {
                var D = Server.Models.Doctor.Get_Doctor_By_ID(D_Login.D_ID);
                D.D_Department = comboBox_Department.Text;
                D.D_Age = int.Parse(textBox_Age.Text);
                D.D_Name = textBox_Name.Text;
                D.D_Pwd = textBox_Pwd.Text;
                D.D_Specialty = textBox_Specialty.Text;
                D.D_Tel = textBox_Tel.Text;
                D.D_Title = comboBox_Title.Text;
                MessageBox.Show("修改成功！");
            }
            catch
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void D_Modify_Personal_Information_Load(object sender, EventArgs e)
        {

            var D = Server.Models.Doctor.Get_Doctor_By_ID(D_Login.D_ID);
            comboBox_Department.Text = D.D_Department;
            textBox_Age.Text = D.D_Age.ToString();
            textBox_Name .Text = D.D_Name;
            textBox_Pwd .Text = D.D_Pwd;
            textBox_Specialty .Text = D.D_Specialty;
            textBox_Tel .Text = D.D_Tel.ToString();
            comboBox_Title.Text = D.D_Title;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            D_Personal_Information frm = new D_Personal_Information();
            Hide();
            frm.Show();
        }
    }
}
