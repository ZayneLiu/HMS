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
        /// Prescribe
        /// </summary>
        /// <param name="T_ID">坐诊ID</param>
        /// <param name="M_ID">药品ID</param>
        /// <param name="Count">药品数量</param>
        public static bool Prescribe(int T_ID, int M_ID, int Count)
        {
            var command = new SqlCommand("insert into Med_Record values (@T_ID, @M_ID, @Count)");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@T_ID",T_ID),
                new SqlParameter("@M_ID",M_ID),
                new SqlParameter("@Count",Count)
            });
            return DB.Execute(command);
        }
    }
}
