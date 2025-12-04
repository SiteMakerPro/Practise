using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Text { get; set; }
        public string BigImagePath { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Good(int id, string name, string category, string bigImagePath, decimal text = 0)
        {
            Id = id;
            Name = name;
            Category = category;
            BigImagePath = bigImagePath;
            Text = text;
            switch (id)
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
            if (id % 2 == 0)
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
