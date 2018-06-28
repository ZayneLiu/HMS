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

            List<Doctor> doctors = Doctor.Get_All_Doctors();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
