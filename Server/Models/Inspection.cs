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
        public string I_Name { get; set; }
        public double I_Price { get; set; }

        /// <summary>
        /// 获取所有检查项目
        /// </summary>
        /// <returns>The all inspections.</returns>
        public static List<Inspection> Get_All_Inspections(){
            var inspections = new List<Inspection>();
            var command = new SqlCommand("select * from Inspection");
            var rows = DB.Read(command);
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
