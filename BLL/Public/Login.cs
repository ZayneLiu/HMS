using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Public
{
    public static class Login
    {
        partial
        public static bool is_login_valid(string username, string pwd)
        {
            
            return true;
        }
        public static bool Select(string sql)
        {
            return Patient.All_Patients( );
        }

      
    }
}
