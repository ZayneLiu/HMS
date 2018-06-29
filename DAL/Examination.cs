using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 检查类
    /// </summary>
    public class Examination
    {
        /// <summary>
        /// 检查编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 检查名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }

    }
}
