using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Medication
    {
        /// <summary>
        /// 药品编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 药品进价
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// 药品售价
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime Production_Date { get; set; }
        /// <summary>
        /// 最后使用期限(过期时间)
        /// </summary>
        public DateTime Exp_Date { get; set; }
        /// <summary>
        /// 药品库存
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 获取所有药品对象 每个药品对象包含该药品所有信息
        /// </summary>
        /// <returns></returns>
        public static List<Medication> Get_All_Meds()
        {
            //TBC
            return new List<Medication>();
        }
    }
}
