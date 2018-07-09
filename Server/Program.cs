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
            Models.Patient patient = new Models.Patient()
            {
                P_ID = "aqwr",
                P_Age = 12,
                P_Name = "fadsf",
                P_Gender = "adsf"
            };


            var a = Models.Patient.Get_Patient_By_ID("adsfadsf");
            a.P_Gender = "adsf";
            a.SaveChanges();

            Logics.Treatment_Record_Logics.Create_Record_If_Info_Valid("123", "34");
        }
    }
}
