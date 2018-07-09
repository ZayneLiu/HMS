using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logics
{
    public static class Med_Logics
    {
        /// <summary>
        /// 如果药品信息合法 则添加药品
        /// </summary>
        /// <param name="Name">名称</param>
        /// <param name="Category">类别</param>
        /// <param name="Unit">单位</param>
        /// <param name="Price">单价</param>
        /// <param name="Stock">库存</param>
        /// <param name="Effect">功效</param>
        /// <returns></returns>
        public static bool Add_Med_If_Info_Valid(string Name, string Category, string Unit, double Price, int Stock, string Effect )
        {
            var command = new SqlCommand("Insert into Med (Med_Name, Med_Category, Med_Unit, Med_Price, Med_Stock, Med_Effect) values " +
                "(@Med_Name, @Med_Category, @Med_Unit, @Med_Price, @Med_Stock, @Med_Effect)");
            command.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@Med_Name", Name),
                new SqlParameter("@Med_Category", Category),
                new SqlParameter("@Med_Unit", Unit),
                new SqlParameter("@Med_Price", Price),
                new SqlParameter("@Med_Stock", Stock),
                new SqlParameter("@Med_Effect", Effect)
            });
            DB.Execute(command);
            return true;
        }

        public static void Method()
        {

        }
    }
}
