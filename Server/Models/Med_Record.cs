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

        /// <summary>
        /// Prescribe the specified D_ID, P_ID and M_ID.
        /// </summary>
        /// <param name="D_ID">医生ID</param>
        /// <param name="P_ID">病人ID</param>
        /// <param name="M_ID">药品ID</param>
        public static void Prescribe(string D_ID, string P_ID, int M_ID)
        {
            
        }
    }
}
