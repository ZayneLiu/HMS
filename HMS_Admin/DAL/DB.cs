using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using HMS_Partial.DAL.Models;

namespace HMS_Partial.DAL
{
    public static class DB
    {
        static string sql = @"Data Source=(localdb)\MSSQLLocalDB;Database=HMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string connection_String = @"Data Source = (localdb)\MSSQLLocalDB;Database=HMS;Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static SqlConnection connetion = new SqlConnection(connection_String);
        public static DataSet dataset
        {
            get
            {
                var a = new DataSet();
                Med.adapter.Fill(a,"Med");
                return a;
            }
        }
        public static void Close_Connection()
        {
            if (connetion.State == ConnectionState.Open)
            {
                connetion.Close();
            };
        }

        /// <summary>
        /// 获取对应DataAdaptor
        /// </summary>
        /// <param name="command">只用添加sql命令及参数即可，不用connection</param>
        /// <returns>对应DataAdaptor</returns>
        public static SqlDataAdapter GetAdapter(SqlCommand command)
        {
            command.Connection = connetion;
            var adapter = new SqlDataAdapter(command);

            adapter.DeleteCommand = new SqlCommandBuilder(adapter).GetDeleteCommand(true);
            //adapter.DeleteCommand = new SqlCommand("delete from Med where Med_Id = @Med_Id");

            return adapter;
        }

        /// <summary>
        /// 读取动作
        /// </summary>
        /// <param name="cmd">带参数的 SqlCommand对象</param>
        /// <returns>所有记录</returns>
        public static List<Data_Mapping.Row> Read(SqlCommand cmd)
        {
            connetion.Open();
            cmd.Connection = connetion;
            var reader = cmd.ExecuteReader();
            List<Data_Mapping.Row> rows = new List<Data_Mapping.Row>();
            while (reader.Read())
            {
                Data_Mapping.Row row = new Data_Mapping.Row(reader.FieldCount);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.datas[i] = new Data_Mapping.Data(reader.GetName(i))
                    {
                        Value = reader.GetValue(i),
                        Value_Type = reader.GetDataTypeName(i),
                    };
                }
                //每行的记录添加到 List<Row> 中
                rows.Add(row);
            }
            connetion.Close();
            return rows;
        }

        /// <summary>
        /// cmd.ExecuteNonQuery() 无连接实现
        /// </summary>
        /// <param name="cmd">无需connection,只有参数即可</param>
        public static void Execute(SqlCommand cmd)
        {
            connetion.Open();
            cmd.Connection = connetion;
            cmd.ExecuteNonQuery();
            connetion.Close();
        }
    }
}
