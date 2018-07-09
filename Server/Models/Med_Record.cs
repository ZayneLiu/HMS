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
        /// 开药列表ID
        /// </summary>
        public int MR_ID { get; set; }
        /// <summary>
        /// 药品ID Med表
        /// </summary>
        public int M_ID { get; set; }

        public static void Give_Meds()
        {
            
        }

        /// <summary>
        /// 获取开药记录中的药品对象
        /// </summary>
        /// <param name="MR_ID">开药记录编号</param>
        /// <returns></returns>
        public static Dictionary<Med, int> Get_Med_List_By_MR_ID(string MR_ID)
        {
            var meds = new Dictionary<Med, int>();
            var command = new SqlCommand("select M_ID, COUNT(M_ID) as Count from Med_Record where MR_ID = @MR_ID group by M_ID");
            command.Parameters.AddWithValue("@MR_ID", MR_ID);
            var rows = DB.Read(command);
            foreach (DB.Row row in rows)
            {
                meds.Add(Med.Get_Med_By_Id((int)row["M_ID"].Value), (int)row["Count"].Value);
            }
            return meds;
        }
    }
}
