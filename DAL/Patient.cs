using System;
using System.Data.SqlClient;


namespace DAL
{
    public class Patient : DB_OP.CRUD
    {
        public Patient Old { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Tel { get; set; }

        public void CREATE(object to_create)
        {
            throw new NotImplementedException();
        }
        public DB_OP.Result READ()
        {
            throw new NotImplementedException();
        }
        public void UPDATE(object _new)
        {
            Patient updated = (Patient)_new;
            var cmd = new SqlCommand("update Patient set _name=@name, _gender=@gender, _age=@age, _tel=@tel where _id=@old_id", DB_OP.sqlConnection);
            //添加参数
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@name",updated.Name),
                new SqlParameter("@gender",updated.Gender),
                new SqlParameter("@age",updated.Age),
                new SqlParameter("@tel",updated.Tel),
                new SqlParameter("@old_id",Old.Id),
            });
            DB_OP.Run(cmd);
        }
        public void DELETE()
        {
            throw new NotImplementedException();
        }

    }
}
