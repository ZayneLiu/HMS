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
            #region 数据有效性判定

            #endregion
            return Models.Med.Add(new Models.Med()
                {
                    M_Name = Name,
                    M_Category = Category,
                    M_Unit = Unit,
                    M_Price = Price,
                    M_Effect = Effect,
                    M_Stock = Stock
                });
        }

        

        //public static bool Create_If_Med_Info_Valid(string id, string name, string category, string unit, double price, int stock, string effect)
        //{
        //    try
        //    {
        //        var _New_Med = new Models.Med()
        //        {
        //            M_ID = int.Parse(id),
        //            M_Name = name,
        //            M_Category = category,
        //            M_Unit = unit,
        //            M_Price = price,
        //            M_Stock = stock,
        //            M_Effect = effect
        //        };
        //        //更新
        //        Models.Med.Create(_New_Med);
        //        return true;
        //    }
        //    catch (Exception exc)
        //    {
        //        Console.WriteLine("|| ERR From BLL.Medsmanagement.cs => " + exc.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        DAL.DB.Close_Connection();
        //    }
        //}

    }
}
