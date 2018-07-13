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
    public partial class P_Sign : Form
    {
        public P_Login login = null;
        public P_Sign(P_Login p_Login)
        {
            p_Login.Hide();
            InitializeComponent();
            login = p_Login;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            //P_Login frm = new P_Login();
            //frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //对病人表添加数据
            //P_Tip_1 frm = new P_Tip_1();
            //frm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(Server.Logics.Patient_Logics.Register_If_Info_Valid(Tbx_Username.Text, Tbx_Password.Text, Tbx_Turename.Text, int.Parse(Tbx_Age.Text), Cbx_Gender.Text, Tbx_Tell.Text, Tbx_Sickness_History.Text))
            {
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("注册失败！");
            }

                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }
    }
}
