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
        /// 创建坐诊记录
        /// </summary>
        /// <param name="D_ID">坐诊医生ID</param>
        /// <param name="P_ID">被诊病人ID</param>
        public static bool Create_If_Info_Valid(string D_ID, string P_ID, string Detail)
        {
            if (Doctor.Get_Doctor_By_ID(D_ID) != null && Patient.Get_Patient_By_ID(P_ID) != null)
            {
                Treatment_Record.Create_Record(new Treatment_Record()
                {
                    D_ID = D_ID,
                    P_ID = P_ID,
                    T_Time = DateTime.Now,
                    Detail = Detail
                });
                return true;
            }
            return false;
        }
    }
}
