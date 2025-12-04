using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text {  get; set; }
        public string BigImagePath { get; set; }
        public int Row {  get; set; }
        public int Col { get; set; }

        public Employee(int id, string name, string text, string bigImagePath)
        {
            Id = id;
            Name = name;
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
