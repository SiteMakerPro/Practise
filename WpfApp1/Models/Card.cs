using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Text { get; set; }
        public string BigImagePath { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Card(int id, string title, string category, string bigImagePath, decimal price = 0)
        {
            Id = id;
            Title = title;
            Category = category;
            Price = price;
            BigImagePath = bigImagePath;
            switch(id)
            {
                case 1: case 2:
                    Row = 0;
                    break;
                case 3: case 4:
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
        public Card(int id, string title, string category, string bigImagePath, string text)
        {
            Id = id;
            Title = title;
            Category = category;
            Text = text;
            BigImagePath = bigImagePath;
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
