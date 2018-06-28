using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DB_OP
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=Hospital;Integrated Security=True;";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);

        //读取表中数据
        public static Result Read_Table(string table) => Extraction(String.Format("select * from {0}", table));








        //执行SQL(无返回数据) ExecuteNonQuery()实现
        public static void Run(SqlCommand command)
        {
            sqlConnection.Open();
            var reader = command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //读取数据(返回 Result对象) ExecuteReader()实现
        public static Result Extraction(string sql)
        {
            Result result = new Result();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Row row = new Row();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.AddData(new Data()
                    {
                        field_name = reader.GetName(i),
                        value = reader.GetValue(i)
                    });
                }
                result.AddRow(row);
            }
            reader.Close();
            sqlConnection.Close();
            return result;
        }



        public interface CRUD
        {
            void CREATE(object to_create);
            DB_OP.Result READ();
            void UPDATE(object updated);
            void DELETE();
        }
        //数据库 视图、行、数据 对象映射
        #region DB_Structure
        //数据
        public class Data
        {
            //列名
            public string field_name;
            //值
            public object value = new object();
            public override string ToString() => value.ToString();
        }
        //行
        public class Row : IEnumerable
        {
            public Data this[string field_name]
            {
                get
                {
                    return datas.Find(data => (
                      data.field_name == field_name));
                }
                //set { /* set the specified index to value here */ }
            }
            //一行包含的 数据
            public List<Data> datas = new List<Data>();
            public void AddData(Data data) => datas.Add(data);
            public IEnumerator GetEnumerator() => datas.GetEnumerator();
        }
        //视图
        public class Result : IEnumerable
        {
            //查询结果包含的 行
            public List<Row> rows = new List<Row>();
            public void AddRow(Row row) => rows.Add(row);
            public IEnumerator GetEnumerator() => rows.GetEnumerator();
        }

        #endregion
    }
}
