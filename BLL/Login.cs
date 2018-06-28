using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class Login
    {
        public static bool  is_login_valid(string username, string pwd)
        {
            return true;
        }

        /// <summary>
        /// 传数据例子
        /// </summary>
        /// <returns>要传的数据</returns>
        public static string GetData()
        {
            return "要传的数据 数据类型可以自己定";
        }
    }
}
