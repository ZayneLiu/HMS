using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using System.Data.SqlClient;

namespace Server.Logics
{
    public static class Treatment_Record_Logics
    {
        /// <summary>
        /// 开始坐诊
        /// </summary>
        /// <returns>成功或失败</returns>
        /// <param name="D_ID">医生ID</param>
        /// <param name="P_ID">病人ID</param>
        /// <param name="Detail">坐诊内容</param>
        public static bool Start_Treatment(string D_ID, string P_ID, string Detail)
        {
            if (Doctor.Get_Doctor_By_ID(D_ID) != null && Patient.Get_Patient_By_ID(P_ID) != null)
            {
                return Treatment_Record.Create_Record(new Treatment_Record()
                {
                    D_ID = D_ID,
                    P_ID = P_ID,
                    T_Time = DateTime.Now,
                    Detail = Detail
                });
            }
            return false;
        }


        /// <summary>
        /// 获取对应ID的坐诊记录基本信息
        /// </summary>
        /// <returns>The my treatment record basic info by identifier.</returns>
        /// <param name="treatment_ID">Treatment identifier.</param>
        public static Dictionary<string,string> Get_My_Treatment_Record_Basic_Info_By_ID(string treatment_ID){
            // 初始化返回参数
            var key_value_pair = new Dictionary<string, string>();
            var command = new SqlCommand("select * from Treatment_Record TR join Patient P on TR.P_ID=P.P_ID join Doctor D on TR.D_ID=D.D_ID where T_ID = @T_ID");
            command.Parameters.AddWithValue("@T_ID", treatment_ID);
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
            var basic_info = new Dictionary<string, string>
            {
                {"ID", my_treatment_ID},
                {"Doctor", my_treatment_doctor},
                {"Patient", my_treatment_patient},
                {"Time", my_treatment_time}
            };

            return basic_info;
        }

        public static bool Prescribe(string D_ID){
            return true;
        }
    }
}
                   