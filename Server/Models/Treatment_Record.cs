using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    /// <summary>
    /// 坐诊记录表
    /// </summary>
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
        /// 坐诊详情
        /// </summary>
        public string Detail { get; set; }


        /// <summary>
        /// 检查项目列表
        /// </summary>
        public Dictionary<Med, int> M_Record
        {
            get
            {
                return Med_Record.Get_Med_List_By_T_ID(T_ID);
            }
            set
            {
                foreach (var med_count_pair in value)
                {
                    var command = new SqlCommand("insert into Med_Record values (@T_ID, @M_ID, @Count)");
                    command.Parameters.AddRange(new SqlParameter[] {
                        new SqlParameter("@T_ID", T_ID),
                        new SqlParameter("@M_ID", med_count_pair.Key),
                        new SqlParameter("@Count", med_count_pair.Value)
                    });
                    DB.Execute(command);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Method()
        {
            
        }

        /// <summary>
        /// 创建就诊记录
        /// </summary>
        /// <returns><c>true</c>, if record was created, <c>false</c> otherwise.</returns>
        /// <param name="record">Record.</param>
        public static bool Create_Record(Treatment_Record record)
        {
            var command = new SqlCommand("insert into Treatment_Record(T_Time, D_ID, P_ID, Detail) " +
                "values(@T_Time, @D_ID, @P_ID, @Detail");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@T_Time", DateTime.Now),
                new SqlParameter("@D_ID", record.D_ID),
                new SqlParameter("@P_ID", record.P_ID),
                new SqlParameter("@Detail", record.Detail)
            });
            return DB.Execute(command);
        }

        /// <summary>
        /// 获取对应ID的坐诊记录
        /// </summary>
        /// <returns>对应ID的坐诊记录</returns>
        /// <param name="T_ID">坐诊ID</param>
        public static Treatment_Record Get_Treatment_Record_By_ID(string T_ID)
        {
            var command = new SqlCommand("select * from Treatment_Record where T_ID = @T_ID");
            command.Parameters.AddWithValue("@T_ID", T_ID);
            var row = DB.Read(command).First();
            return new Treatment_Record()
            {
                T_ID = (int)row["T_ID"].Value,
                T_Time = (DateTime)row["T_Time"].Value,
                D_ID = row["D_ID"].Value.ToString(),
                P_ID = row["P_ID"].Value.ToString(),
                Detail = row["Detail"].Value.ToString()
            };
        }
    }
}
