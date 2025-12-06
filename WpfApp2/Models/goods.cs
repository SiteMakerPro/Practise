using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2.Models
{
    public class goods
    {
        public int IdG { get; set; }
        public string Name { get; set; }
        public int IdCa { get; set; }
        public decimal Price { get; set; }
        public byte[] Img { get; set; }
    }
}
