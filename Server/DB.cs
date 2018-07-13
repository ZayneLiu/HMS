using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Server
{
    public class DB
    {
        public static string conString = @"server = 127.0.0.1;integrated security = true;database=HMS";
        public static SqlConnection connection = new SqlConnection(conString);

        /// <summary>
        /// 执行对应SqlCommand
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <param name="command">带有参数的 SqlCommand 对象，无需加入SqlConnection</param>
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
            }
            finally
            {
                Close_DB_Connection();
            }
            return false;
        }

        /// <summary>
        /// 执行对应 sql命令
        /// </summary>
        /// <returns>SqlDataReader </returns>
        /// <param name="command">带有参数的SqlCommand 对象</param>
        public static List<Row> Read(SqlCommand command)
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                var rows = new List<Row>();
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
                if (rows.Count == 0)
                {
                    return null;
                }
                connection.Close();
                return rows;

            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("DB.Read() <- ERR: {0}", e.Message));
            }
            finally
            {
                Close_DB_Connection();
            }
            return null;
        }

        public static void Close_DB_Connection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public static DataSet dataSet = new DataSet();

        public static SqlDataAdapter GetAdapter(string sql)
        {
            return new SqlDataAdapter(sql, connection);
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
