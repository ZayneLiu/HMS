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
    public partial class D_Personal_Information : Form
    {
        public Form parent;
        public D_Personal_Information( Form form )
        {
            InitializeComponent();
            parent = form;
        }

        private void D_Personal_Information_Load(object sender, EventArgs e)
        {
            var D = Server.Models.Doctor.Get_Doctor_By_ID(D_Login .D_ID );
            D_ID.Text = D.D_ID;
            D_Gender.Text = D.D_Gender;
            D_Department.Text = D.D_Department;
            D_Age.Text = D.D_Age.ToString ();
            D_Name.Text = D.D_Name;
            D_Pwd.Text = D.D_Pwd;
            D_Specialty.Text = D.D_Specialty;
            D_Tel.Text = D.D_Tel.ToString();
            D_Title.Text = D.D_Title;
        }

        private void label18_Click(object sender, EventArgs e)
        {
            D_Modify_Personal_Information frm = new D_Modify_Personal_Information(this );
            frm.Show();
            Hide();
        }
    }
}
