using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Partial.BLL
{
    class Meds_Management_Logic
    {
        /// <summary>
        /// 如果药品信息正确即添加药品信息
        /// </summary>
        /// <param name="Med_To_Add">元组</param>
        /// <returns>true/false</returns>
        public static bool Create_If_Med_Info_Valid(Tuple<string, string, string, double, int, string> Med_To_Add)
        {
            try
            {
                var _New_Med = new DAL.Models.Med()
                {
                    Med_Name = Med_To_Add.Item1,
                    Med_Catgory = Med_To_Add.Item2,
                    Med_Unit = Med_To_Add.Item3,
                    Med_Price = Med_To_Add.Item4,
                    Med_Stock = Med_To_Add.Item5,
                    Med_Effect = Med_To_Add.Item6
                };
                //更新
                _New_Med.Create();
                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine("|| ERR From BLL.Medsmanagement.cs => " + exc.Message);
                return false;
            }
            finally
            {
                DAL.DB.Close_Connection();
            }
        }

        public static bool Update_If_Med_Info_Valid(DAL.Models.Med med_To_Update)
        {
            return true;
        }
    }
}
