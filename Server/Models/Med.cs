using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    /// <summary>
    /// 药品类
    /// </summary>
    public class Med
    {
        public Med()
        {

        }
        public Med(int id)
        {
            M_ID = id;
        }
        /// <summary>
        /// 药品编号 某个药品的唯一标识
        /// </summary>
        public int M_ID { get; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string M_Name { get; set; }
        /// <summary>
        /// 药品类别 OTC Rx
        /// </summary>
        public string M_Category { get; set; }
        /// <summary>
        /// 药品单位 (盒，瓶，袋)
        /// </summary>
        public string M_Unit { get; set; }
        /// <summary>
        /// 药品售价
        /// </summary>
        public double M_Price { get; set; }
        /// <summary>
        /// 药品库存
        /// </summary>
        public int M_Stock { get; set; }
        /// <summary>
        /// 药品功效
        /// </summary>
        public string M_Effect { get; set; }

        /// <summary>
        /// 将对 对象做出的更改 更新至数据库
        /// </summary>
        public bool SaveChanges()
        {
            //初始化SQL命令
            var cmd = new SqlCommand(@"update Med set M_Name=@M_Name, M_Category=@M_Category, M_Unit=@M_Unit, M_Price=@M_Price, M_Stock=@M_Stock, M_Effect=@M_Effect" 
                                     + " where M_Id = @M_Id");
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@M_Id",M_ID),
                new SqlParameter("@M_Name",M_Name),
                new SqlParameter("@M_Category",M_Category),
                new SqlParameter("@M_Unit",M_Unit),
                new SqlParameter("@M_Price",M_Price),
                new SqlParameter("@M_Stock",M_Stock),
                new SqlParameter("@M_Effect",M_Effect),
            });
            //调用执行指令
            return DB.Execute(cmd);
        }

        /// <summary>
        /// 获取所有药品
        /// </summary>
        /// <returns>All meds.</returns>
        public static List<Med> Get_All_Meds(){
            var meds = new List<Med>();
            var command = new SqlCommand("select * from Med ");
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (var row in rows)
            {
                meds.Add(new Med((int)row["M_Id"].Value)
                {
                    M_Name = row["M_Name"].Value.ToString(),
                    M_Category = row["M_Category"].Value.ToString(),
                    M_Unit = row["M_Unit"].Value.ToString(),
                    M_Price = (double)row["M_Price"].Value,
                    M_Stock = (int)row["M_Stock"].Value,
                    M_Effect = row["M_Effect"].Value.ToString(),
                });
            }
            return meds;
        }

        /// <summary>
        /// 创建药品
        /// </summary>
        /// <param name="med">Med 类对象</param>
        public static bool Add(Med med)
        {
            //初始化SQL命令
            var cmd = new SqlCommand(@"insert into Med(M_Name, M_Category, M_Unit, M_Price, M_Stock, M_Effect)"
                + " values(@M_Name, @M_Category, @M_Unit, @M_Price, @M_Stock, @M_Effect)");
            cmd.Parameters.AddRange(new SqlParameter[] {
            new SqlParameter("@M_Name",med.M_Name),
            new SqlParameter("@M_Category",med.M_Category),
            new SqlParameter("@M_Unit",med.M_Unit),
            new SqlParameter("@M_Price",med.M_Price),
            new SqlParameter("@M_Stock",med.M_Stock),
            new SqlParameter("@M_Effect",med.M_Effect),
            });
            //调用执行指令
            return DB.Execute(cmd);
        }

        /// <summary>
        /// 根据 ID 查询药品
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        public static Med Get_Med_By_Id(int mId)
        {
            var command = new SqlCommand("select * from Med where M_ID=@M_ID");
            command.Parameters.AddWithValue("@M_ID", mId);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            var row = rows.First();
            return new Med((int)row["M_Id"].Value)
            {
                M_Name = row["M_Name"].Value.ToString(),
                M_Category = row["M_Category"].Value.ToString(),
                M_Unit = row["M_Unit"].Value.ToString(),
                M_Price = (double)row["M_Price"].Value,
                M_Stock = (int)row["M_Stock"].Value,
                M_Effect = row["M_Effect"].Value.ToString(),
            };
        }

        public void Delete()
        {
            //药品若 不存在 则取消删除
            if (M_ID == 0)
            {
                Console.WriteLine("药品不存在，请先添加药品");
                return;
            }
            //初始化SQL命令
            var cmd = new SqlCommand("delete from Med where M_ID = @M_ID");
            cmd.Parameters.AddWithValue("@M_ID", M_ID);
            //调用执行指令
            DB.Execute(cmd);
        }


        //public static List<Med> Get_Meds_By_Catgory(string Catgory) => Get_Med("M_Catgory", Catgory);
        //public static List<Med> Get_Meds_By_Effect(string Effect) => Get_Med("M_Effect", Effect);

        //static List<Med> Get_Med(string condition, object value)
        //{
        //    var cmd = new SqlCommand(String.Format("select * from Med where {0}=@{0}", condition));
        //    cmd.Parameters.AddWithValue("@" + condition, value);
        //}
    }
}
