using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Patient
    {
        #region 字段
        /// <summary>
        /// 身份证号
        /// </summary>
        public string P_ID { get; set; }
        /// <summary>
        /// 病人密码
        /// </summary>
        public string P_Pwd { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string P_Name { get; set; }
        /// <summary>
        /// 病人性别
        /// </summary>
        public string P_Gender { get; set; }
        /// <summary>
        /// 病人年龄
        /// </summary>
        public int P_Age { get; set; }
        /// <summary>
        /// 病人电话
        /// </summary>
        public string P_Tel { get; set; }
        /// <summary>
        /// 病人病史
        /// </summary>
        public string P_Med_History { get; set; }
        #endregion

        /// <summary>
        /// 获取所有我的就诊记录
        /// </summary>
        /// <returns>The my treatment records.</returns>
        public List<Treatment_Record> Get_My_Treatment_Records()
        {
            var records = new List<Treatment_Record>();
            var command = new SqlCommand("select * from Treatment_Record where P_ID=@P_ID");
            command.Parameters.AddWithValue("@P_ID", P_ID);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (var row in rows)
            {
                records.Add(new Treatment_Record()
                {
                    T_ID = (int)row["T_ID"].Value,
                    T_Time = (DateTime)row["T_Time"].Value,
                    D_ID = row["D_ID"].Value.ToString(),
                    P_ID = row["P_ID"].Value.ToString(),
                    Detail = row["Detail"].Value.ToString()
                });
            }
            return records;
        }

        /// <summary>
        /// 将对 patient 对象的更改更新至数据库
        /// </summary>
        public bool SaveChanges()
        {
            try
            {
                var command = new SqlCommand("update Patient set P_Name=@P_Name, P_Gender=@P_Gender, P_Age=@P_Age, P_Tel=@P_Tel, P_Med_History=@P_Med_History where P_ID=@P_ID");
                command.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@P_Name", P_Name),
                    new SqlParameter("@P_Gender", P_Gender),
                    new SqlParameter("@P_Age", P_Age),
                    new SqlParameter("@P_Tel", P_Tel),
                    new SqlParameter("@P_Med_History", P_Med_History),
                    new SqlParameter("@P_ID", P_ID)
                });
                return DB.Execute(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SaveChanges() <- ERR: "+ex.Message);
                DB.Close_DB_Connection();
                return false;
            }
        }
        
        /// <summary>
        /// 获取对应病人ID的坐诊记录
        /// </summary>
        /// <returns>The treatment records by p identifier.</returns>
        /// <param name="P_ID">病人ID</param>
        public static List<Treatment_Record> Get_Treatment_Records_By_P_ID(string P_ID){
            return Get_Patient_By_ID(P_ID).Get_My_Treatment_Records();
        }

        /// <summary>
        /// 注册病人用户
        /// </summary>
        /// <param name="patient">病人对象</param>
        /// <returns>成功则返回 true; 失败则返回 false</returns>
        public static bool Register_Patient(Patient patient)
        {
            var command = new SqlCommand("insert into Patient values " +
                "(@P_ID, @P_Pwd, @P_Name, @P_Gender, @P_Age, @P_Tel, @P_Med_History)");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@P_ID", patient.P_ID),
                new SqlParameter("@P_Pwd", patient.P_Pwd),
                new SqlParameter("@P_Name", patient.P_Name),
                new SqlParameter("@P_Gender", patient.P_Gender),
                new SqlParameter("@P_Age", patient.P_Age),
                new SqlParameter("@P_Tel", patient.P_Tel),
                new SqlParameter("@P_Med_History", patient.P_Med_History)
            });
            return DB.Execute(command);
        }

        /// <summary>
        /// 查询所有病人
        /// </summary>
        /// <returns>patient 对象集合</returns>
        public static List<Patient> Get_All_Patient()
        {
            // 初始化返回参数
            var patients = new List<Patient>();
            SqlCommand command = new SqlCommand("select * from Patient");
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            else
            {
                foreach (DB.Row row in rows)
                {
                    patients.Add(new Patient()
                    {
                        P_ID = row["P_ID"].Value.ToString(),
                        P_Name = row["P_Name"].Value.ToString(),
                        P_Age = (int)row["P_Age"].Value,
                        P_Gender = row["P_Gender"].Value.ToString(),
                        P_Pwd = row["P_Pwd"].Value.ToString(),
                        P_Tel = row["P_Tel"].Value.ToString(),
                        P_Med_History = row["P_Med_History"].Value.ToString(),
                    });
                }
                return patients;
            }
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID">要查询的ID</param>
        /// <returns></returns>
        public static Patient Get_Patient_By_ID(string ID)
        {
            var command = new SqlCommand("select * from Patient where P_ID = @P_ID");
            command.Parameters.AddWithValue("@P_ID", ID);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            var row = rows.First();
            return new Patient()
            {
                P_ID = row["P_ID"].Value.ToString(),
                P_Age = (int)row["P_Age"].Value,
                P_Gender = row["P_Gender"].Value.ToString(),
                P_Name = row["P_Name"].Value.ToString(),
                P_Tel = row["P_Tel"].Value.ToString(),
                P_Pwd = row["P_Pwd"].Value.ToString(),
                P_Med_History = row["P_Med_History"].Value.ToString()
            };
        }

        /// <summary>
        /// 根据姓名查询 模糊
        /// </summary>
        /// <param name="name">要查询的姓名</param>
        /// <returns>对应的 patient对象集合</returns>
        public static List<Patient> Get_Patient_By_Name(string name)
        {
            //初始化返回变量
            var patients = new List<Patient>();
            var command = new SqlCommand("select * from Patient where P_ID like (@P_Name)");
            command.Parameters.AddWithValue("@P_Name", "%"+name+"%");
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            else
            {
                foreach (DB.Row row in rows)
                {
                    patients.Add(new Patient()
                    {
                        P_ID = row["P_ID"].Value.ToString(),
                        P_Age = (int)row["P_Age"].Value,
                        P_Gender = row["P_Gender"].Value.ToString(),
                        P_Name = row["P_Name"].Value.ToString(),
                        P_Tel = row["P_Tel"].Value.ToString(),
                        P_Pwd = row["P_Pwd"].Value.ToString(),
                        P_Med_History = row["P_Med_History"].Value.ToString()
                    });
                }
                return patients;
            }
        }

        /// <summary>
        /// 按性别查询
        /// </summary>
        /// <param name="gender">病人性别</param>
        /// <returns></returns>
        public static List<Patient> Get_Patients_By_Gender(string gender)
        {
            // 初始化返回变量
            var patients = new List<Patient>();
            var command = new SqlCommand("select * from Patient where P_Gender = @P_Gender");
            command.Parameters.AddWithValue("@P_Gender", gender);
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            else
            {
                foreach (DB.Row row in rows)
                {
                    patients.Add(new Patient()
                    {
                        P_ID = row["P_ID"].Value.ToString(),
                        P_Name = row["P_Name"].Value.ToString(),
                        P_Age = (int)row["P_Age"].Value,
                        P_Gender = row["P_Gender"].Value.ToString(),
                        P_Pwd = row["P_Pwd"].Value.ToString(),
                        P_Tel = row["P_Tel"].Value.ToString(),
                        P_Med_History = row["P_Med_History"].Value.ToString(),
                    });
                }
                return patients;
            }
        }

        /// <summary>
        /// 性别 + 姓名 查询
        /// </summary>
        /// <param name="gender">性别</param>
        /// <param name="name">姓名</param>
        /// <returns>符合条件的 patient对象集合</returns>
        public static List<Patient> Get_Patients_By_Gender_And_Name(string gender, string name)
        {
            // 初始化返回变量
            var patients = new List<Patient>();
            var command = new SqlCommand("select * from Patient where P_Gender = @P_Gender and P_Name like (@P_Name)");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@P_Gender", gender),
                new SqlParameter("@P_Name", "%"+name+"%")
            });
            var rows = DB.Read(command);
            if (rows == null)
            {
                return null;
            }
            foreach (DB.Row row in rows)
            {
                patients.Add(new Patient()
                {
                    P_ID = row["P_ID"].Value.ToString(),
                    P_Name = row["P_Name"].Value.ToString(),
                    P_Age = (int)row["P_Age"].Value,
                    P_Gender = row["P_Gender"].Value.ToString(),
                    P_Pwd = row["P_Pwd"].Value.ToString(),
                    P_Tel = row["P_Tel"].Value.ToString(),
                    P_Med_History = row["P_Med_History"].Value.ToString(),
                });
            }
            return patients;
        }
    }
}
