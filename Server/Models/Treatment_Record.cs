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
        /// 坐诊记录药品列表 属性-只读
        /// </summary>
        /// <value>The meds.</value>
        public Dictionary<Med, int> Meds
        {
            get
            {
                var meds = new Dictionary<Med, int>();
                var command = new SqlCommand("select M_ID, COUNT(M_ID) as Count from Med_Record where T_ID=@T_ID group by M_ID");
                command.Parameters.AddWithValue("@T_ID", T_ID);
                var rows = DB.Read(command);
                if (rows == null)
                {
                    return null;
                }
                foreach (DB.Row row in rows)
                {
                    var M_ID = (int)row["M_ID"].Value;
                    meds.Add(Med.Get_Med_By_Id(M_ID), (int)row["Count"].Value);
                }
                return meds;
            }
        }

        /// <summary>
        /// 获取所有我的检查项目 属性-只读
        /// </summary>
        /// <value>The inspections.</value>
        public List<Inspection> Inspections{
            get{
                var inspections = new List<Inspection>();
                var command = new SqlCommand("select I_ID, COUNT(I_ID) as Count from Inspection_Record where T_ID=@T_ID group by I_ID");
                command.Parameters.AddWithValue("@T_ID", T_ID);
                var rows = DB.Read(command);
                if (rows == null)
                {
                    return null;
                }
                foreach (var row in rows){
                    var I_ID = row["I_ID"].Value.ToString();
                    inspections.Add(Inspection.Get_Inspection_By_ID(I_ID));
                }
                return inspections;
            }
        }

        /// <summary>
        /// 获取对应坐诊记录的基本信息 动态成员方法
        /// </summary>
        /// <returns>The basic info.</returns>
        public Dictionary<string, string> Get_Basic_Info(){
            // 初始化返回参数
            var key_value_pair = new Dictionary<string, string>();

            var command = new SqlCommand("select * from Treatment_Record TR join Patient P on TR.P_ID=P.P_ID join Doctor D on TR.D_ID=D.D_ID where T_ID = @T_ID");
            command.Parameters.AddWithValue("@T_ID", T_ID);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            var row = rows.First();
            string my_treatment_ID = row["T_ID"].Value.ToString();
            string my_treatment_doctor = row["D_Name"].Value.ToString();
            string my_treatment_patient = row["P_Name"].Value.ToString();
            // 可能出错
            string my_treatment_time = ((DateTime)row["T_Time"].Value).ToString();
            // ======
            // 获取所有就诊记录的基本信息 医生病人姓名，时间等
            return new Dictionary<string, string>
            {
                {"ID", my_treatment_ID},
                {"Doctor", my_treatment_doctor},
                {"Patient", my_treatment_patient},
                {"Time", my_treatment_time}
            };
        }

        /// <summary>
        /// 创建就诊记录 静态成员方法
        /// </summary>
        /// <returns><c>true</c>, if record was created, <c>false</c> otherwise.</returns>
        /// <param name="record">Record.</param>
        public static bool Create_Record(Treatment_Record record)
        {
            var command = new SqlCommand("insert into Treatment_Record(T_Time, D_ID, P_ID, Detail) " +
                                         "values(@T_Time, @D_ID, @P_ID, @Detail)");
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
        public static Treatment_Record Get_Treatment_Record_By_ID(int T_ID)
        {
            var command = new SqlCommand("select * from Treatment_Record where T_ID = @T_ID");
            command.Parameters.AddWithValue("@T_ID", T_ID);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            var row = rows.First();
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
