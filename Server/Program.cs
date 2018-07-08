using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Logics.Treatment_Record_Logics.Create_Record_If_Info_Valid("123", "34");
        }
    }
}
