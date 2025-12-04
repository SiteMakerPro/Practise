using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class DataField
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public DataField(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
