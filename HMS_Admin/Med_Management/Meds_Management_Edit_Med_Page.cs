using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Models;

namespace HMS_Partial.Med_Management
{
    public partial class Meds_Management_Edit_Med_Page : Form
    {
        Med med = new Med();
        Meds_Management_Landing_Page Landing_Page;
        public Meds_Management_Edit_Med_Page(Meds_Management_Landing_Page meds_Management_Landing_Page)
        {
            InitializeComponent();
            Label_Title.Text = "添加药品";
            label9.Text = "添加成功";
            Label_Save.Text = "添加";
            Landing_Page = meds_Management_Landing_Page;
            pictureBox1.Image = Properties.Resources.Add;
        }
        public Meds_Management_Edit_Med_Page(Meds_Management_Landing_Page landing_Page, Server.Models.Med med_to_edit)
        {
            InitializeComponent();
            Label_Title.Text = "修改药品";
            label9.Text = "修改成功";
            Label_Save.Text = "修改";
            Landing_Page = landing_Page;

            pictureBox1.Image = Properties.Resources.Edit;
            Load_Med_Info(med_to_edit);
            med = med_to_edit;
        }

        private void Load_Med_Info(Med med_to_edit)
        {
            Tbx_Unit.Text = med_to_edit.M_Unit.ToString();
            Tbx_Name.Text = med_to_edit.M_Name;
            Tbx_Effect.Text = med_to_edit.M_Effect;
            Tbx_Price.Text = med_to_edit.M_Price.ToString();
            Tbx_Stock.Text = med_to_edit.M_Stock.ToString();
            Cbx_Catgory.SelectedItem = med_to_edit.M_Category;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string Name = Tbx_Name.Text;
            string Catgory = Cbx_Catgory.SelectedItem.ToString();
            string Unit = Tbx_Unit.Text;
            double Price = double.Parse(Tbx_Price.Text);
            int Stock = int.Parse(Tbx_Stock.Text);
            string Effect = Tbx_Effect.Text;
            bool succeed = false;
            try
            {
                if (Label_Title.Text == "添加药品")
                {
                    //添加药品
                    succeed = Server.Logics.Med_Logics.Add_Med_If_Info_Valid(Name, Catgory, Unit, Price, Stock, Effect);
                    //待添加药品信息 存入元组  可以考虑直接在此处实例化一个Med对象
                    //var Med_To_Add = Tuple.Create();
                    //将数据传入逻辑层进行处理
                    //succeed = Server.Logics.Med_Logics.Add_Med_If_Info_Valid(Name, Catgory, Unit, Price, Stock, Effect);
                }
                else
                {
                    //修改药品
                    med.M_Name = Name;
                    med.M_Category = Catgory;
                    med.M_Stock = Stock;
                    med.M_Price = Price;
                    med.M_Unit = Unit;
                    med.M_Effect = Effect;
                    succeed = med.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            if (succeed)
            {
                //隐藏现有控件
                Panel_Btn_Add.Visible = false;
                Panel_Input_Group.Visible = false;
                Panel_Btn_Back.Visible = false;
                //显示成功信息
                Panel_Success.Visible = true;
                //实现延迟
                var timer = new Timer();
                timer.Interval = 800;
                timer.Start();
                timer.Tick += (object timer_sender, EventArgs timer_e) =>
                {
                    Close();
                    Landing_Page.RefreshData();
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
