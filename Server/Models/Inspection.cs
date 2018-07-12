using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Server;

namespace Server.Models
{
    /// <summary>
    /// 检查项目表
    /// </summary>
    public class Inspection
    {
        /// <summary>
        /// 检查项目ID
        /// </summary>
        public int I_ID { get; set; }
        /// <summary>
        /// 检查项目名称
        /// </summary>
        /// <value>Name of the Inspection.</value>
        public string I_Name { get; set; }
        /// <summary>
        /// 检查项目费用
        /// </summary>
        /// <value>The price of Inspection.</value>
        public double I_Price { get; set; }

        /// <summary>
        /// 获取对应ID的检查项目
        /// </summary>
        /// <returns>The inspection by identifier.</returns>
        /// <param name="I_ID">检查ID</param>
        public static Inspection Get_Inspection_By_ID(string I_ID){
            var command = new SqlCommand("select * from Inspection where I_ID=@I_ID");
            command.Parameters.AddWithValue("@I_ID", I_ID);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            var row = rows.First();
            return new Inspection()
            {
                I_ID = (int)row["I_ID"].Value,
                I_Name = row["I_Name"].Value.ToString(),
                I_Price = (double)row["I_Price"].Value
            };
        }

        /// <summary>
        /// 获取所有检查项目
        /// </summary>
        /// <returns>The all inspections.</returns>
        public static List<Inspection> Get_All_Inspections(){
            var inspections = new List<Inspection>();
            var command = new SqlCommand("select * from Inspection");
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (var row in rows)
            {
                inspections.Add(new Inspection()
                {
                    I_ID = (int)row["I_ID"].Value,
                    I_Name = row["I_Name"].Value.ToString(),
                    I_Price = (double)row["I_Price"].Value
                });
            }
            return inspections;
        }

        /// <summary>
        /// 添加检查项目
        /// </summary>
        public static void Add_Inspection()
        {

        }
    }
}
