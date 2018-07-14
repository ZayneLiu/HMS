using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logics
{
    public static class Doctor_Logics
    {
        /// <summary>
        /// 登陆判断
        /// </summary>
        /// <param name="Doctor_ID">医生ID</param>
        /// <param name="pwd">医生密码</param>
        /// <returns>添加成功 true; 添加失败 false</returns>
        public static bool Is_Login_Info_Valid(string Doctor_ID, string pwd)
        {
            var doc = Models.Doctor.Get_Doctor_By_ID(Doctor_ID);
            
            if (doc == null)
            {
                return false;
            }
            if ( doc.D_Pwd == pwd)
            {
                return true;
            } 
            return false;
        }

        /// <summary>
        /// 添加医生
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <param name="name">医生姓名</param>
        /// <param name="gender">医生性别</param>
        /// <param name="age">医生年龄</param>
        /// <param name="tel">医生电话</param>
        /// <param name="title">医生职称</param>
        /// <param name="specialty">医生擅长病类</param>
        /// <param name="department">医生负责科室</param>
        /// <returns>添加成功 true; 添加失败 false</returns>
        public static bool Add_If_Info_Valid(string id, string name, string gender, int age, string tel, string title, string specialty, string department)
        {
            #region 数据有效性判定
            // 医生身份证号
            if (id.Length != 18)
            {
                Console.WriteLine("D_ID 输入非法 <- ERR:");
                return false;
            }
            //医生电话
            if (tel.Length != 11)
            {
                Console.WriteLine("D_Tel 输入非法 <- ERR:");
                return false;
            }
            #endregion

            return Models.Doctor.Add(new Models.Doctor()
            {
                D_ID = id,
                //初始密码为身份证后六位
                D_Pwd = id.Substring(id.Length - 6, 6),
                D_Name = name,
                D_Gender = gender,
                D_Age = age,
                D_Tel = tel,
                D_Title = title,
                D_Specialty = specialty,
                D_Department = department,
            });
        }
    }
}
