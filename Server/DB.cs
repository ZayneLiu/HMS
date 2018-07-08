using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server
{
    public class DB
    {
        public static string conString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;database=HMS";
        public static SqlConnection connection = new SqlConnection(conString);

        public static bool Execute(SqlCommand command)
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("DB.Execute() <- ERR: {0}", e.Message));
                return false;
            }
        }

        public static List<Row> Read(SqlCommand command)
        {
            command.Connection = connection;
            connection.Open();
            var reader = command.ExecuteReader();
            var rows = new List<Row>(reader.FieldCount);
            while (reader.Read())
            {
                Row row = new Row(reader.FieldCount);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.datas[i] = new Data(reader.GetName(i))
                    {
                        Value = reader.GetValue(i),
                        Value_Type = reader.GetDataTypeName(i),
                    };
                }
                //每行的记录添加到 List<Row> 中
                rows.Add(row);
            }
            connection.Close();
            return rows;
        }

        public class Data
        {
            public Data(string Field_Name) => this.Field_Name = Field_Name;
            public string Field_Name { get; }
            public object Value { get; set; }
            public string Value_Type { get; set; }
        }

        public class Row
        {
            public Row(Data[] datas) => this.datas = datas;
            public Row(int field_count) => datas = new Data[field_count];
            public Data[] datas;
            public Data this[string field_name]
            {
                get
                {
                    Predicate<Data> match = new Predicate<Data>(
                        (data) => { return (data.Field_Name == field_name); });
                    return Array.Find(datas, match);
                }
            }
        }
    }
}
