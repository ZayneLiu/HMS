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
        public int T_ID { get; set; }
        public DateTime T_Time { get; set; }
        public string D_ID { get; set; }
        public string P_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="D_ID"></param>
        /// <param name="P_ID"></param>
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
    }
}
