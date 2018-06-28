using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Patient : DB_OP.CRUD
    {
        public Patient old { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string tel { get; set; }
        public Patient()
        {

        }
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
                new SqlParameter("@name",updated.name),
                new SqlParameter("@gender",updated.gender),
                new SqlParameter("@age",updated.age),
                new SqlParameter("@tel",updated.tel),
                new SqlParameter("@old_id",old.id),
            });
            DB_OP.Run(cmd);
        }
        public void DELETE()
        {
            throw new NotImplementedException();
        }

    }
}
