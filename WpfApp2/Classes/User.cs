using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp2.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public User(int id, string name, string email, string login, string password, string address, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Phone = phone;
            Login = login;
        }
    }
}
