using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取所有医生对象
            List<Doctor> doctors = Doctor.All_Doctors;



            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
