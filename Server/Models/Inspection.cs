using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    /// <summary>
    /// 检查项目表
    /// </summary>
    public class Inspection
    {
        /// <summary>
        /// 检查项目ID
        /// </summary>
        public int I_ID { get; set; }
        public string I_Name { get; set; }
        public double I_Price { get; set; }

        public static void Add_Inspection()
        {

        }
    }
}
