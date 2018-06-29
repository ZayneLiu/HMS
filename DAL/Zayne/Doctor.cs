using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Zayne
{
    /// <summary>
    /// 医生类
    /// </summary>
    public class Doctor
    {
        public Doctor(int id)
        {
            Id = id;
        }
        /// <summary>
        /// 医生编号
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 医生性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 医生年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 医生电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 医生职称
        /// </summary>
        public string Title { get; set; }




        /// <summary>
        /// 更新医生信息
        /// </summary>
        /// <param name="doctor">更新后的 Doctor 对象</param>
        public void Update()
        {
            string sql = @"update Doctor set _name=@name, _age=@age, _gender=@gender, _region=@region, _tel=@tel, _title=@title where _id=@id";
            var cmd = new SqlCommand(sql, DB_OP.sqlConnection);
            //添加 SQL语句 参数列表
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@name",Name),
                new SqlParameter("@age",Age),
                new SqlParameter("@gender",Gender),
                new SqlParameter("@region",Region),
                new SqlParameter("@tel",Tel),
                new SqlParameter("@title",Title),
                new SqlParameter("@id",Id),
            });
            DB_OP.Run(cmd);
        }


        //以下为静态成员方法
        /// <summary>
        /// 获取所有医生
        /// </summary>
        /// <returns>Doctor对象的泛型集合</returns>
        public static List<Doctor> All_Doctors
        {
            get
            {
                var AllDoctors = new List<Doctor>();
                var result = DB_OP.Read_Table("Doctor");
                foreach (DB_OP.Row row in result)
                {
                    var a = new Doctor((int)row["_id"].value)
                    {
                        Name = row["_name"].value.ToString(),
                        Age = (int)row["_age"].value,
                        Gender = row["_gender"].value.ToString(),
                        Region = row["_region"].value.ToString(),
                        Tel = row["_tel"].value.ToString(),
                        Title = row["_title"].value.ToString()
                    };
                    AllDoctors.Add(a);
                }
                return AllDoctors;
            }
        }
    }
}