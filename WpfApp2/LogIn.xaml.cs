using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (loginInput.Text.Length > 0 && passwordInput.Password.Length > 0)
            {
                if (loginInput.Text == "user" && passwordInput.Password == "12345")
                {
                    User user = new User();
                    user.Show();
                    this.Close();
                }
                else if (loginInput.Text == "admin" && passwordInput.Password == "12345")
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Close();
                }
                else if (loginInput.Text == "pvz" && passwordInput.Password == "12345")
                {
                    PVZ pvz = new PVZ();
                    pvz.Show();
                    this.Close();
                }
            }
        }

        private void loginInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (loginInput.Text == "Логин")
            {
                loginInput.Text = "";
            }
            if (passwordInput.Password == "")
            {
                passwordInput.Password = "Пароль";
            }
        }

        private void passwordInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordInput.Password == "Пароль")
            {
                passwordInput.Password = "";
            }
            if (loginInput.Text == "")
            {
                loginInput.Text = "Логин";
            }
        }
    }
}
