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
        public Admin_Doc_Management parent;
        public Admin_Doc_Add(Admin_Doc_Management form)
        {
            InitializeComponent();
            parent = form;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            bool success = false;
            string id = "";
            string name = "";
            int age = 0;
            string gender = "";
            string title = "";
            string specialty =  "";
            string department = "";
            string tel = "";
            try
            {
                id = textBox1.Text;
                name = textBox3.Text;
                age = int.Parse(textBox4.Text);
                gender = comboBox1.Text;
                title = textBox5.Text;
                specialty = textBox6.Text;
                department = textBox7.Text;
                tel = textBox8.Text;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                success = false;
            }
            success = Server.Logics.Doctor_Logics.Add_If_Info_Valid(id, name, gender, age, tel, title, specialty, department);

            if (success)
            {
                Close();
                var success_form = new Success();
                success_form.Show();
                //实现延迟
                var timer = new Timer();
                timer.Interval = 800;
                timer.Start();
                timer.Tick += (object timer_sender, EventArgs timer_e) =>
                {
                    success_form.Close();
                    parent.RefreshData();
                    //确保 Timer 只 Tick 一次
                    timer.Stop();
                    timer.Dispose();
                };
                return;
            }
            else
            {
                MessageBox.Show("失败，请重试");
            }
        }


    }
}
