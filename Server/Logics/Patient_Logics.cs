using System;
using System.Collections.Generic;
using System.Linq;x
using System.Text;
using System.Threading.Tasks;

namespace Server.Logics
{
    public static class Patient_Logics
    {
        public static bool Is_Login_Info_Valid(string P_ID, string pwd)
        {
            if (Models.Patient.Get_Patient_By_ID(P_ID).P_Pwd == pwd)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 如果信息合法,则注册病人,并返回 true;
        /// 若信息非法,则返回 false;
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <param name="pwd">密码</param>
        /// <param name="realname">真实姓名</param>
        /// <param name="age">年龄</param>
        /// <param name="gender">性别</param>
        /// <param name="tel">电话</param>
        /// <param name="med_history">病史</param>
        /// <returns>true / false</returns>
        public static bool Register_Patient_If_Info_Valid(string id, string pwd, string realname, int age, string gender, string tel, string med_history)
        {
            if (id.Length != 18)
            {
                Console.WriteLine("P_ID 输入非法 <- ERR:");
                return false;
            }
            if (tel.Length != 11)
            {
                Console.WriteLine("P_Tel 输入非法 <- ERR:");
                return false;
            }


            return Models.Patient.Register_Patient(new Models.Patient()
            {
                P_ID = id,
                P_Age = age,
                P_Gender = gender,
                P_Med_History = med_history,
                P_Name = realname,
                P_Pwd = pwd,
                P_Tel = tel
            });
        }
    }
}
