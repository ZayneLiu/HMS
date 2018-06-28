using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 医生类
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// 医生编号
        /// </summary>
        public int Id { get; set; }
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
        /// 重载 ToString() 方法
        /// </summary>
        /// <returns>返回医生基本信息 Console.WriteLine(); 试下就知道了</returns>
        public override string ToString()
        {
            return String.Format("Doctor: {0}\tTel: {1}\nTitle: {2}\tRegion: {3}", Name, Tel, Title, Region);
        }
        /// <summary>
        /// 获取所有医生对象 每个医生对象包含该医生所有信息
        /// </summary>
        /// <returns>Doctor对象的泛型集合</returns>
        public static List<Doctor> Get_All_Doctors()
        {
            var AllDoctors = new List<Doctor>();
            var result = DB_OP.Read_Table("Doctor");
            foreach (DB_OP.Row row in result)
            {
                var a = new Doctor()
                {
                    Id = (int)row["_id"].value,
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