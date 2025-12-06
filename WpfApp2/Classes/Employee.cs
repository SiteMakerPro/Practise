using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public string Text { get; set; }
        public string BigImagePath { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Employee(int id, int order, string lastname, string firstname, string patronymic, string text, string bigImagePath)
        {
            Id = id;
            Order = order;
            Name = $"{lastname} {firstname} {patronymic}";
            Lastname = lastname;
            Firstname = firstname;
            Patronymic = patronymic;
            Text = text;
            BigImagePath = bigImagePath;
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
