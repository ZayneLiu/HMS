using System;
using System.Collections.Generic;
using System.Data;
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
        # region 字段
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
        #endregion

        
        public bool SaveChanges()
        {
            try
            {
                var command = new SqlCommand("update Doctor set D_Name=@D_Name, D_Gender=@D_Gender, D_Age=@D_Age, D_Tel=@D_Tel, D_Specialty=@D_Specialty, D_Department=@D_Department, D_Title=@D_Title, D_Pwd=@D_Pwd where D_ID=@D_ID");
                command.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@D_Name", D_Name),
                    new SqlParameter("@D_Gender", D_Gender),
                    new SqlParameter("@D_Age", D_Age),
                    new SqlParameter("@D_Title", D_Title),
                    new SqlParameter("@D_Pwd", D_Pwd),
                    new SqlParameter("@D_Tel", D_Tel),
                    new SqlParameter("@D_Specialty", D_Specialty),
                    new SqlParameter("@D_Department", D_Department),
                    new SqlParameter("@D_ID", D_ID)
                });
                return DB.Execute(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Doctor.SaveChanges() <- ERR: "+ex.Message);
                DB.Close_DB_Connection();
                return false;
            }
        }

        
        /// <summary>
        /// 添加医生
        /// </summary>
        /// <param name="doctor">要添加的医生对象</param>
        /// <returns>成功 true; 失败 false</returns>
        public static bool Add(Doctor doctor)
        {
            var command = new SqlCommand("insert into Doctor values " +
                "(@D_ID, @D_Pwd, @D_Name, @D_Age, @D_Gender, @D_Tel, @D_Title, @D_Specialty, @D_Department)");
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
            var departments = new List<string>();
            var command = new SqlCommand("select distinct D_Department from Doctor");
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (var row in rows)
            {
                departments.Add(row["D_Department"].Value.ToString());
            }
            return departments;
        }

        /// <summary>
        /// 获取所有专长病类
        /// </summary>
        public static List<string> Get_All_Specialty()
        {
            var specialties = new List<string>();
            var command = new SqlCommand("select distinct D_Specialty from Doctor");
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (var row in rows)
            {
                specialties.Add(row["D_Specialty"].Value.ToString());
            }
            return specialties;
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
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (DB.Row row in rows)
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
                    D_Specialty = row["D_Specialty"].Value.ToString(),
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
            if (rows == null)
            {
                return null;
            }
            var row = rows.First();
            // 根据获取到的数据实例化一个 Doctor 对象
            return new Doctor()
            {
                D_ID = row["D_ID"].Value.ToString(),
                D_Pwd = row["D_Pwd"].Value.ToString(),
                D_Gender = row["D_Gender"].Value.ToString(),
                D_Age = (int)row["D_Age"].Value,
                D_Name = row["D_Name"].Value.ToString(),
                D_Tel = row["D_Tel"].Value.ToString(),
                D_Title = row["D_Title"].Value.ToString(),
                D_Specialty = row["D_Specialty"].Value.ToString(),
                D_Department = row["D_Department"].Value.ToString()
            };

        }

        /// <summary>
        /// 联合查询
        /// </summary>
        /// <param name="D_Department">医生所在科室</param>
        /// <param name="D_Specialty">医生专长</param>
        /// <returns></returns>
        public static List<Doctor> Get_Doctors_By_Department_And_Specialty(string D_Department, string D_Specialty)
        {
            return Get_Doctor(new string[] { "D_Department", "D_Specialty" }, new string[] { D_Department, D_Specialty });
        }

        /// <summary>
        /// 根据科室获取所有医生
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static List<Doctor> Get_Doctor_By_Department(string department)
        {
            // 初始化返回参数
            var doctors = new List<Doctor>();
            var command = new SqlCommand("select * from Doctor where D_Department=@D_Department");
            command.Parameters.AddWithValue("@D_Department", department);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (DB.Row row in rows)
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
                    D_Specialty = row["D_Specialty"].Value.ToString(),
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
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (DB.Row row in rows)
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
                    D_Specialty = row["D_Specialty"].Value.ToString(),
                    D_Department = row["D_Department"].Value.ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }

        static List<Doctor> Get_Doctor(string[] condition, object[] value)
        {
            var doctors = new List<Doctor>();
            var command = new SqlCommand(String.Format("select * from Doctor where {0}=@{0} and {1}=@{1}", condition[0], condition[1]));
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@" + condition[0], value[0]),
                new SqlParameter("@" + condition[1], value[1])
            });
            var rows = DB.Read(command);
            if (rows ==null)
            {
                return null;
            }
            foreach (DB.Row row in rows)
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
                    D_Specialty = row["D_Specialty"].Value.ToString(),
                    D_Department = row["D_Department"].Value.ToString()
                };
                doctors.Add(doctor);
            }
            return doctors;
        }

        /// <summary>
        /// 获取该医生的坐诊记录
        /// </summary>
        /// <param name="D_ID">医生编号</param>
        /// <returns></returns>
        public static List<Treatment_Record> GeMyTreatmentRecords(string D_ID)
        {
            // 初始化返回参数
            var records = new List<Treatment_Record>();
            var command = new SqlCommand("select * from Treatment_Record where D_ID=@D_ID");
            command.Parameters.AddWithValue("@D_ID", D_ID);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (var row in rows)
            {
                records.Add(new Treatment_Record()
                {
                    T_ID = (int) row["T_ID"].Value,
                    T_Time = (DateTime) row["T_Time"].Value,
                    D_ID = row["D_ID"].Value.ToString(),
                    P_ID = row["P_ID"].Value.ToString(),
                    Detail = row["Detail"].Value.ToString()
                });
            }
            return records;
        }

        public List<Treatment_Record> GeMyTreatmentRecords()
        {
            return GeMyTreatmentRecords(D_ID);
        }
    }
}
