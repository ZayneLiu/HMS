using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Partial.DAL.Models
{
    public class Med
    {
        public Med() { }
        public Med(int Med_Id) => this.Med_Id = Med_Id;
        /// <summary>
        /// 药品编号 某个药品的唯一标识
        /// </summary>
        public int Med_Id { get; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string Med_Name { get; set; }
        /// <summary>
        /// 药品类别 OTC Rx
        /// </summary>
        public string Med_Catgory { get; set; }
        /// <summary>
        /// 药品单位 (盒，瓶，袋)
        /// </summary>
        public string Med_Unit { get; set; }
        /// <summary>
        /// 药品售价
        /// </summary>
        public double Med_Price { get; set; }
        /// <summary>
        /// 药品库存
        /// </summary>
        public int Med_Stock { get; set; }
        /// <summary>
        /// 药品功效
        /// </summary>
        public string Med_Effect { get; set; }

        public static SqlDataAdapter adapter = DB.GetAdapter(new SqlCommand("Select * From Med"));

        public void Create()
        {
            //药品若 存在 则取消添加
            if (Med_Id != 0)
            {
                Console.WriteLine("药品已存在");
                return;
            }
            //初始化SQL命令
            var cmd = new SqlCommand();
            cmd.CommandText = @"insert into Med(Med_Name, Med_Catgory, Med_Unit, Med_Price, Med_Stock, Med_Effect)"
                + "values(@Med_Name, @Med_Catgory, @Med_Unit, @Med_Price, @Med_Stock, @Med_Effect)";
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@Med_Name",Med_Name),
                new SqlParameter("@Med_Catgory",Med_Catgory),
                new SqlParameter("@Med_Unit",Med_Unit),
                new SqlParameter("@Med_Price",Med_Price),
                new SqlParameter("@Med_Stock",Med_Stock),
                new SqlParameter("@Med_Effect",Med_Effect),
            });
            //调用执行指令
            DB.Execute(cmd);
        }
        public void Update()
        {
            //药品若 不存在 则取消修改
            if (Med_Id == 0)
            {
                Console.WriteLine("药品不存在，请先添加药品");
                return;
            }
            //初始化SQL命令
            var cmd = new SqlCommand();
            cmd.CommandText = @"update Med set Med_Name=@Med_Name, Med_Catgory=@Med_Catgory, Med_Unit=@Med_Unit, Med_Price=@Med_Price, Med_Stock=@Med_Stock, Med_Effect=@Med_Effect)"
                + " where Med_Id = @Med_Id";
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@Med_Id",Med_Id),
                new SqlParameter("@Med_Name",Med_Name),
                new SqlParameter("@Med_Catgory",Med_Catgory),
                new SqlParameter("@Med_Unit",Med_Unit),
                new SqlParameter("@Med_Price",Med_Price),
                new SqlParameter("@Med_Stock",Med_Stock),
                new SqlParameter("@Med_Effect",Med_Effect),
            });
            //调用执行指令
            DB.Execute(cmd);
        }
        public void Delete()
        {
            //药品若 不存在 则取消删除
            if (Med_Id == 0)
            {
                Console.WriteLine("药品不存在，请先添加药品");
                return;
            }
            //初始化SQL命令
            var cmd = new SqlCommand("delete from Med where Med_Id = @Med_Id");
            cmd.Parameters.AddWithValue("@Med_Id", Med_Id);
            //调用执行指令
            DB.Execute(cmd);
        }

        public static List<Med> Get_Med_By_Id(string Id) => Get_Med("Med_Id", Id);
        public static List<Med> Get_Med_By_Name(string Name) => Get_Med("Med_Name", Name);
        public static List<Med> Get_Meds_By_Catgory(string Catgory) => Get_Med("Med_Catgory", Catgory);
        public static List<Med> Get_Meds_By_Effect(string Effect) => Get_Med("Med_Effect", Effect);

        static List<Med> Get_Med(string condition, object value)
        {
            var cmd = new SqlCommand(String.Format("select * from Med where {0}=@{0}", condition));
            cmd.Parameters.AddWithValue("@"+condition, value);
            var result = DB.Read(cmd);
            Console.WriteLine(String.Format("|| 本次查询到 => {0} 条记录", result.Count));

            List<Med> meds = new List<Med>();
            foreach (var row in result)
            {
                meds.Add(new Med((int)row["Med_Id"].Value)
                {
                    Med_Name = row["Med_Name"].Value.ToString(),
                    Med_Catgory = row["Med_Catgory"].Value.ToString(),
                    Med_Unit = row["Med_Unit"].Value.ToString(),
                    Med_Price = (double)row["Med_Price"].Value,
                    Med_Stock = (int)row["Med_Stock"].Value,
                    Med_Effect = row["Med_Effect"].Value.ToString(),
                });
            }
            return meds;
        }
    }
}
