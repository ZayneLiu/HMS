using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            //登陆判断 登陆成功返回值为true
            Login.is_login_valid("用户名","密码");
        }
    }
}
