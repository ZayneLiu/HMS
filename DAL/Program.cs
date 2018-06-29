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


            new Patient().Create();
            //获取所有医生对象
            List<Doctor> doctors = Doctor.All_Doctors;

            Console.WriteLine(doctors[0].Name);

            doctors[0].Name = "杨小康";
            var a = new Patient(12);
            doctors[0].Update();


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
