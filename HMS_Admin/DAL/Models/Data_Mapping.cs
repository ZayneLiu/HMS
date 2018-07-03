using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Partial.DAL.Models
{
    public static class Data_Mapping
    {
        public class Row
        {
            public Row(Data[] datas) => this.datas = datas;
            public Row(int field_count) => datas = new Data[field_count];
            public Data[] datas;
            public Data this[string field_name]
            {
                get
                {
                    Predicate<Data> match = new Predicate<Data>(
                        (data) => { return (data.Field_Name == field_name); });
                    return Array.Find(datas, match);
                }
            }
        }
        public class Data
        {
            public Data(string Field_Name) => this.Field_Name = Field_Name;
            public string Field_Name { get; }
            public object Value { get; set; }
            public string Value_Type { get; set; }
        }
    }
}
