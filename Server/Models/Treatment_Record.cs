using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Treatment_Record
    {
        /// <summary>
        /// 坐诊ID
        /// </summary>
        public int T_ID { get; set; }
        /// <summary>
        /// 坐诊时间
        /// </summary>
        public DateTime T_Time { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public string D_ID { get; set; }
        /// <summary>
        /// 病人ID
        /// </summary>
        public string P_ID { get; set; }
        /// <summary>
        /// 检查项目列表ID
        /// </summary>
        public int IR_ID { get; set; }
        /// <summary>
        /// 开药记录列表ID
        /// </summary>
        public int MR_ID { get; set; }

        /// <summary>
        /// 创建就诊记录
        /// </summary>
        /// <param name="D_ID">医生ID</param>
        /// <param name="P_ID">病人ID</param>
        public static void Create_Record(Treatment_Record record)
        {
            var command = new SqlCommand("insert into Treatment_Record(T_Time, D_ID, P_ID) values(@T_Time, @D_ID, @P_ID)");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@T_Time", DateTime.Now),
                new SqlParameter("@D_ID", record.D_ID),
                new SqlParameter("@P_ID", record.P_ID)
            });
            DB.Execute(command);
        }

        /// <summary>
        /// 获取对应ID的坐诊记录
        /// </summary>
        /// <param name="ID">坐诊记录ID</param>
        /// <returns></returns>
        public static Treatment_Record Get_Treatment_Record_By_ID(string ID)
        {
            var command = new SqlCommand("select * from Treatment_Record where T_ID = @T_ID");
            command.Parameters.AddWithValue("@T_ID", ID);
            var row = DB.Read(command).First();
            return new Treatment_Record()
            {

                T_ID = (int)row["T_ID"].Value,
                T_Time = (DateTime)row["T_Time"].Value,
                D_ID = row["D_ID"].Value.ToString(),
                P_ID = row["P_ID"].Value.ToString()
            };
        }
    }
}
