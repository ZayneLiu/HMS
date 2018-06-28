using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL
{
    public class Patient
    {
        /// <summary>
        /// 病人编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 病人性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 病人年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 病人电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 房间编号
        /// </summary>
        public int Room_No { get; set; }
        /// <summary>
        /// 床号
        /// </summary>
        public int Bed_No { get; set; }
        /// <summary>
        /// 获取所有病人信息 每一个病人对象包含所有病人信息
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetAllPatients()
        {
            var AllPatients = new List<Patient>();
            var result = DB_OP.Read_Table("Patient");
            foreach (DB_OP.Row row in result)
            {
                var a = new Patient()
                {
                    Id = (int)row["_id"].value,
                    Name = row["_name"].value.ToString(),
                    Age = (int)row["_age"].value,
                    Gender = row["_gender"].value.ToString(),
                    Tel = row["_tel"].value.ToString(),
                    Room_No = (int)row["_room_no"].value,
                    Bed_No = (int)row["_bed_no"].value
                };
                AllPatients.Add(a);
            }
            return AllPatients;
        }


        #region 更新病人信息 (复用)
        //public void UPDATE(object _new)
        //{
        //    Patient updated = (Patient)_new;
        //    var cmd = new SqlCommand("update Patient set _name=@name, _gender=@gender, _age=@age, _tel=@tel where _id=@old_id", DB_OP.sqlConnection);
        //    //添加参数
        //    cmd.Parameters.AddRange(new SqlParameter[] {
        //        new SqlParameter("@name",updated.Name),
        //        new SqlParameter("@gender",updated.Gender),
        //        new SqlParameter("@age",updated.Age),
        //        new SqlParameter("@tel",updated.Tel),
        //        new SqlParameter("@old_id",Old.Id),
        //    });
        //    DB_OP.Run(cmd);
        //} 
        #endregion
    }
}
