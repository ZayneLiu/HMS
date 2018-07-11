using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server.Models
{
    /// <summary>
    /// 检查记录
    /// </summary>
    public class Inspection_Record
    {
        /// <summary>
        /// 坐诊ID
        /// </summary>
        public int T_ID { get; set; }
        /// <summary>
        /// 检查项目ID
        /// </summary>
        public int I_ID { get; set; }


        /// <summary>
        /// 获取所有坐诊记录
        /// </summary>
        /// <returns>The all inspection records.</returns>
        public static List<Inspection_Record> Get_All_Inspection_Records(){
            var inspection_records = new List<Inspection_Record>();
            var command = new SqlCommand("select * from Inspection_Record");
            var rows = DB.Read(command);
            foreach (var row in rows)
            {
                inspection_records.Add(new Inspection_Record()
                {
                    T_ID = (int)row["T_ID"].Value,
                    I_ID = (int)row["I_ID"].Value,
                });
            }
            return inspection_records;
        }
    }
}
