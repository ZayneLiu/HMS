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
            // 插入药品记录
            var command = new SqlCommand("insert into Med_Record values (@T_ID, @M_ID, @Count)");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@T_ID",T_ID),
                new SqlParameter("@M_ID",M_ID),
                new SqlParameter("@Count",Count)
            });
            bool med_log_result = DB.Execute(command);
            if (!med_log_result)
            {
                Console.WriteLine("插入药品记录失败");
            }

            // 减少库存
            var stock = Med.Get_Med_By_Id(M_ID).M_Stock;
            var decrease_stock = new SqlCommand("update Med set M_Stock = @M_Stock where M_ID = @M_ID");
            decrease_stock.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@M_ID",M_ID),
                new SqlParameter("@M_Stock",stock - Count)
            });
            bool decrease_stock_result = DB.Execute(decrease_stock);
            if (!decrease_stock_result)
            {
                Console.WriteLine("减少库存失败");
            }

            return (med_log_result && decrease_stock_result);
        }
    }
}
