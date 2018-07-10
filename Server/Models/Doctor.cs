using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    /// <summary>
    /// 医生类
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// 医生身份证号
        /// </summary>
        public string D_ID { get; set; }
        /// <summary>
        /// 医生密码
        /// </summary>
        public string D_Pwd { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string D_Name { get; set; }
        /// <summary>
        /// 医生年龄
        /// </summary>
        public int D_Age { get; set; }
        /// <summary>
        /// 医生性别
        /// </summary>
        public string D_Gender { get; set; }
        /// <summary>
        /// 医生电话
        /// </summary>
        public string D_Tel { get; set; }
        /// <summary>
        /// 医生职称
        /// </summary>
        public string D_Title { get; set; }
        /// <summary>
        /// 医生专长病类
        /// </summary>
        public string D_Specialty { get; set; }
        /// <summary>
        /// 医生所属科室
        /// </summary>
        public string D_Department { get; set; }


        /// <summary>
        /// 添加医生
        /// </summary>
        /// <param name="doctor">要添加的医生对象</param>
        /// <returns>成功 true; 失败 false</returns>
        public static bool Add(Doctor doctor)
        {
            var command = new SqlCommand("insert into Doctor values " +
                "(@D_ID, @D_Pwd, @D_Name, @D_Age, @D_Gender, @D_Tel, @D_Title, @D_Specialty, @D_Section)");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@D_ID", doctor.D_ID),
                new SqlParameter("@D_Name", doctor.D_Name),
                new SqlParameter("@D_Pwd", doctor.D_Pwd),
                new SqlParameter("@D_Gender", doctor.D_Gender),
                new SqlParameter("@D_Tel", doctor.D_Tel),
                new SqlParameter("@D_Age", doctor.D_Age),
                new SqlParameter("@D_Title", doctor.D_Title),
                new SqlParameter("@D_Specialty", doctor.D_Specialty),
                new SqlParameter("@D_Department", doctor.D_Department),
            });
            return DB.Execute(command);
        }

        /// <summary>
        /// 获取所有科室
        /// </summary>
        /// <returns></returns>
        public static List<string> Get_All_Department()
        {
            return new List<string>();
        }

        public static void Method()
        {

        }

        /// <summary>
        /// 获取所有医生对象
        /// </summary>
        /// <returns>医生对象的集合</returns>
        public static List<Doctor> Get_All_Doctors()
        {
            // 初始化返回参数
            var doctors = new List<Doctor>();
            var command = new SqlCommand("select * from Doctor");
            var result = DB.Read(command);
            foreach (DB.Row row in result)
            {
                var doctor = new Doctor()
                {
                    D_ID = row["D_ID"].Value.ToString(),
                    D_Pwd = row["D_Pwd"].Value.ToString(),
                    D_Gender = row["D_Gender"].Value.ToString(),
                    D_Age = (int)row["D_Age"].Value,
                    D_Name = row["D_Name"].Value.ToString(),
                    D_Tel = row["D_Tel"].Value.ToString(),
                    D_Title = row["D_Title"].Value.ToString(),
                    D_Specialty = row["D_Specialty"].ToString(),
                    D_Department = row["D_Department"].Value.ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }

        /// <summary>
        /// 获取对应 ID 的医生对象
        /// </summary>
        /// <param name="D_ID">医生 ID</param>
        /// <returns>对应 ID 的医生对象</returns>
        public static Doctor Get_Doctor_By_ID(string D_ID)
        {
            var command = new SqlCommand("select * from Doctor where D_ID = @D_ID");
            command.Parameters.AddWithValue("@D_ID", D_ID);
            // 获取查询到的医生
            var rows = DB.Read(command);
            if (rows.Count == 0)
            {
                return null;
            }
            else
            {
                var result = DB.Read(command).First();
                // 根据获取到的数据实例化一个 Doctor 对象
                return new Doctor()
                {
                    D_ID = result["D_ID"].Value.ToString(),
                    D_Pwd = result["D_Pwd"].Value.ToString(),
                    D_Gender = result["D_Gender"].Value.ToString(),
                    D_Age = (int)result["D_Age"].Value,
                    D_Name = result["D_Name"].Value.ToString(),
                    D_Tel = result["D_Tel"].Value.ToString(),
                    D_Title = result["D_Title"].Value.ToString(),
                    D_Specialty = result["D_Specialty"].ToString(),
                    D_Department = result["D_Department"].Value.ToString()
                };
            }
        }

        public static List<Doctor> Get_Doctor_By_Department(string department)
        {
            // 初始化返回参数
            var doctors = new List<Doctor>();
            var command = new SqlCommand("select * from Doctor where D_Department=@D_Department");
            command.Parameters.AddWithValue("@D_Department", department);
            var result = DB.Read(command);
            foreach (DB.Row row in result)
            {
                var doctor = new Doctor()
                {
                    D_ID = row["D_ID"].Value.ToString(),
                    D_Pwd = row["D_Pwd"].Value.ToString(),
                    D_Gender = row["D_Gender"].Value.ToString(),
                    D_Age = (int)row["D_Age"].Value,
                    D_Name = row["D_Name"].Value.ToString(),
                    D_Tel = row["D_Tel"].Value.ToString(),
                    D_Title = row["D_Title"].Value.ToString(),
                    D_Specialty = row["D_Specialty"].ToString(),
                    D_Department = row["D_Department"].Value.ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }

        /// <summary>
        /// 获取对应擅长领域的医生
        /// </summary>
        /// <param name="specialty">擅长领域</param>
        /// <returns></returns>
        public static List<Doctor> Get_Doctors_By_Specialty(string specialty)
        {
            // 初始化返回参数
            var doctors = new List<Doctor>();
            var command = new SqlCommand("select * from Doctor where D_Specialty = @D_Specialty");
            command.Parameters.AddWithValue("@D_Specialty", specialty);
            var result = DB.Read(command);
            foreach (DB.Row row in result)
            {
                var doctor = new Doctor()
                {
                    D_ID = row["D_ID"].Value.ToString(),
                    D_Pwd = row["D_Pwd"].Value.ToString(),
                    D_Gender = row["D_Gender"].Value.ToString(),
                    D_Age = (int)row["D_Age"].Value,
                    D_Name = row["D_Name"].Value.ToString(),
                    D_Tel = row["D_Tel"].Value.ToString(),
                    D_Title = row["D_Title"].Value.ToString(),
                    D_Specialty = row["D_Specialty"].ToString(),
                    D_Department = row["D_Department"].Value.ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }
    }
}
