using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logics
{
    public static class Patient_Logics
    {
        /// <summary>
        /// 登陆判断
        /// </summary>
        /// <param name="P_ID">病人ID</param>
        /// <param name="pwd">病人密码</param>
        /// <returns>登陆成功 或 失败</returns>
        public static bool Is_Login_Info_Valid(string P_ID, string pwd)
        {
            var patient = Models.Patient.Get_Patient_By_ID(P_ID);
            if (patient == null)
            {
                return false;
            }
            if (patient.P_Pwd == pwd)
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
        public static bool Register_If_Info_Valid(string id, string pwd, string realname, int age, string gender, string tel, string med_history)
        {
            #region 数据有效性判定
            // ID 为病人身份证号 故18位
            if (id.Length != 18)
            {
                Console.WriteLine("P_ID 输入非法 <- Input_ERR:");
                return false;
            }
            // Tel 为病人电话 故11位
            if (tel.Length != 11)
            {
                Console.WriteLine("P_Tel 输入非法 <- Input_ERR:");
                return false;
            }
            // 
            #endregion

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
