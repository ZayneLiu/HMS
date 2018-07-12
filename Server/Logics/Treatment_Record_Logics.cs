using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

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
    }
}
