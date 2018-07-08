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
        /// 
        /// </summary>
        /// <param name="D_ID"></param>
        /// <param name="P_ID"></param>
        public static void Create_Record_If_Info_Valid(string D_ID, string P_ID)
        {
            if (Doctor.Get_Doctor_By_ID(D_ID) != null && Patient.Get_Patient_By_ID(P_ID) != null)
            {
                Treatment_Record.Create_Record(new Treatment_Record()
                {
                    D_ID = D_ID,
                    P_ID = P_ID,
                    T_Time = DateTime.Now
                });
            }
            
        }
    }
}
