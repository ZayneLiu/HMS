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

        /// <summary>
        /// cmd.ExecuteNonQuery()实现
        /// </summary>
        /// <param name="command">有 SQL命令文本 和 <c>SqlConnection</c> 的 <c>SqlCommand</c> 对象</param>
        public static void Run(SqlCommand command)
        {
            sqlConnection.Open();
            var reader = command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        /// <summary>
        /// cmd.ExecuteReader()实现
        /// </summary>
        /// <param name="sql"> SQL 语句</param>
        /// <returns>查询结果</returns>
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
        

        /// <summary>
        /// select * from table 实现
        /// </summary>
        /// <param name="table">要查询的表名</param>
        /// <returns>视图对象</returns>
        public static Result Read_Table(string table) => Extraction(String.Format("select * from {0}", table));

        //public interface CRUD
        //{
        //    void CREATE(object to_create);
        //    DB_OP.Result READ();
        //    void UPDATE(object updated);
        //    void DELETE();
        //}

        //数据库 视图、行、数据 对象映射

        #region DB_Structure
        /// <summary>
        /// 数据对象 自身包含 列名 和 值
        /// </summary>
        public class Data
        {
            //列名
            public string field_name;
            //值
            public object value = new object();
            //public override string ToString() => value.ToString();
        }
        //行
        public class Row : IEnumerable
        {
            /// <summary>
            /// 索引器
            /// </summary>
            /// <param name="field_name">列名</param>
            /// <returns>对应列的Data对像</returns>
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
