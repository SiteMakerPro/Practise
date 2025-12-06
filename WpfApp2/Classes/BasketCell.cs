using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Classes
{
    public class BasketCell
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string SmallImagePath { get; set; }
        public int Row { get; set; }

        public BasketCell(int id, int order, string title, string category, string smallImagePath, decimal price = 0)
        {
            Id = id;
            Order = order;
            Title = title;
            Category = category;
            Price = price;
            SmallImagePath = smallImagePath;
            switch (order)
            {
                case 1:
                    Row = 0;
                    break;
                case 2:
                    Row = 2;
                    break;
                case 3:
                    Row = 4;
                    break;
                case 4:
                    Row = 6;
                    break;
            }
        }
    }
}
