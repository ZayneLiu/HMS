﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL.Zayne
{
    public class Patient
    {
        /// <summary>
        /// 无参构造函数 添加病人时使用
        /// </summary>
        public Patient()
        {

        }
        /// <summary>
        /// 有参构造函数 从数据库读取时使用
        /// </summary>
        /// <param name="id"></param>
        public Patient(int id)
        {
            Id = id;
        }
        /// <summary>
        /// 病人编号 只有get访问器，保证只有一个途径可以给起赋值，判断病人是否为新加
        /// </summary>
        public int Id { get; }
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
        /// 用无参构造函数声明病人对象并填充数据，然后调用该方法创建病人
        /// </summary>
        public void Create()
        {
            if (Id == 0)
            {
                string sql = @"insert into Patient(_name, _gender, _age, _tel, _room_no, _bed_no) values (@name,@gender,@age,@tel,@room_no,@bed_no)";
                var cmd = new SqlCommand(sql, DB_OP.sqlConnection);
                cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@name",Name),
                new SqlParameter("@gender",Name),
                new SqlParameter("@tel",Name),
                new SqlParameter("@age",Name),
                new SqlParameter("@room_no",Name),
                new SqlParameter("@bed_no",Name),
                });
                DB_OP.Run(cmd);

            }
            else
            {
                throw new Exception("该病人已存在");
            }
        }

        /// <summary>
        /// 更新病人信息
        /// </summary>
        /// <example>
        /// <code>
        /// p1.name = "adsfadf";
        /// p1.Tel = "12454545454";
        /// p1.Update();
        /// </code>
        /// </example>
        /// <param name="patient">修改后的病人对象</param>
        public void Update()
        {
            string sql = @"update Doctor set _name=@name, _age=@age, _gender=@gender, _room_no=@room_no, _bed_no=@bed_no _tel=@tel where _id=@id";
            var cmd = new SqlCommand(sql, DB_OP.sqlConnection);
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@name", Name),
                new SqlParameter("@age", Age),
                new SqlParameter("@gender", Gender),
                new SqlParameter("@tel", Tel),
                new SqlParameter("@room_no", Room_No),
                new SqlParameter("@bed_no", Bed_No),
                new SqlParameter("@id", Id),
            });
            DB_OP.Run(cmd);
        }


        //以下为静态成员 字段及方法
        /// <summary>
        /// 所有病人
        /// </summary>
        public static List<Patient> All_Patients
        {
            get
            {
                var AllPatients = new List<Patient>();
                var result = DB_OP.Read_Table("Patient");
                foreach (DB_OP.Row row in result)
                {
                    var a = new Patient((int)row["_id"].value)
                    {
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
        }
        /// <summary>
        /// 创建病人
        /// </summary>

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