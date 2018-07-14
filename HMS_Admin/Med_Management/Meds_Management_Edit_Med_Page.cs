using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Partial.Med_Management
{
    public partial class Meds_Management_Edit_Med_Page : Form
    {
        Meds_Management_Landing_Page Landing_Page;
        public Meds_Management_Edit_Med_Page(Meds_Management_Landing_Page meds_Management_Landing_Page)
        {
            InitializeComponent();
            Label_Title.Text = "添加药品";
            label9.Text = "添加成功";
            Label_Save.Text = "添加";
            pictureBox1.Image = Properties.Resources.Add;
            Landing_Page = meds_Management_Landing_Page;
        }
        public Meds_Management_Edit_Med_Page(Meds_Management_Landing_Page landing_Page, Server.Models.Med med_edit)
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Edit;

        }


        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string Name = Tbx_Name.Text;
            string Catgory = ComboBox_Catgory.SelectedItem.ToString();
            string Unit = Tbx_Unit.Text;
            double Price = double.Parse(Tbx_Price.Text);
            int Stock = int.Parse(Tbx_Stock.Text);
            string Effect = Tbx_Effect.Text;
            bool succeed = false;
            try
            {
                if (Label_Title.Text == "药品添加")
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
                    //succeed = Server.Logics.Med_Logics.Update_If_Med_Info_Valid(new DAL.Models.Med(Med_Id: 123)
                    //{
                    //    Med_Name = Name,
                    //    Med_Catgory = Catgory,
                    //    Med_Stock = Stock,
                    //    Med_Price = Price,
                    //    Med_Unit = Unit,
                    //    Med_Effect = Effect
                    //});
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
            }
        }
    }
}
