using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    /// <summary>
    /// 开药记录
    /// </summary>
    public class Med_Record
    {
        /// <summary>
        /// 坐诊记录ID
        /// </summary>
        public int T_ID { get; set; }
        /// <summary>
        /// 药品ID Med表
        /// </summary>
        public int M_ID { get; set; }
        /// <summary>
        /// 药品数量
        /// </summary>
        public int Count { get; set; }

        public static void Give_Meds()
        {
            
        }

        /// <summary>
        /// 获取开药记录中的药品对象
        /// </summary>
        /// <param name="TR_ID">开药记录编号</param>
        /// <returns></returns>
        public static Dictionary<Med, int> Get_Med_List_By_T_ID(int T_ID)
        {
            var meds = new Dictionary<Med, int>();
            var command = new SqlCommand("select M_ID, COUNT(M_ID) as Count from Med_Record where T_ID = @T_ID group by M_ID");
            command.Parameters.AddWithValue("@T_ID", T_ID);
            var rows = DB.Read(command);
            foreach (DB.Row row in rows)
            {
                meds.Add(Med.Get_Med_By_Id((int)row["M_ID"].Value), (int)row["Count"].Value);
            }
            return meds;
        }
    }
}
