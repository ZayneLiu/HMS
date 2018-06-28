using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Doctor
    {
        //编号
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string tel { get; set; }
        //病区管理
        public string region { get; set; }
        public string title { get; set; }

        public override string ToString()
        {
            return String.Format("Doctor: {0}\tTel: {1}\nTitle: {2}\tRegion: {3}", name, tel, title, region);
        }

        public static List<Doctor> Get_All_Doctors()
        {
            var AllDoctors = new List<Doctor>();
            var result = DB_OP.Read_Table("Doctor");
            foreach (DB_OP.Row row in result)
            {
                var a = new Doctor()
                {
                    id = (int)row["_id"].value,
                    name = row["_name"].value.ToString(),
                    age = (int)row["_age"].value,
                    gender = row["_gender"].value.ToString(),
                    region = row["_region"].value.ToString(),
                    tel = row["_tel"].value.ToString(),
                    title = row["_title"].value.ToString()
                };
                AllDoctors.Add(a);
            }
            return AllDoctors;
        }

    }
}