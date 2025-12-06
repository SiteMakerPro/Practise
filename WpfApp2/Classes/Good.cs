using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2.Classes
{
    public class Good
    {
        public int Id { get; set; }
        public int Order {  get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Text { get; set; }
        public byte[] BigImagePath { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Good(int id, int order, string name, string category, byte[] bigImagePath, decimal text = 0)
        {
            Id = id;
            Order = order;
            Name = name;
            Category = category;
            BigImagePath = bigImagePath;
            Text = text;
            switch (order)
            {
                case 1:
                case 2:
                    Row = 0;
                    break;
                case 3:
                case 4:
                    Row = 2;
                    break;
            }
            if (order % 2 == 0)
            {
                Col = 3;
            }
            else
            {
                Col = 0;
            }
        }
    }
}
