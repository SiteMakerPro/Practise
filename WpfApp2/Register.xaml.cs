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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
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
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        private void loginInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (loginInput.Text == "Логин")
            {
                loginInput.Text = "";
            }
            if (passwordInput.Text == "")
            {
                passwordInput.Text = "Пароль";
            }
            if (confirmPassword.Text == "")
            {
                confirmPassword.Text = "Подтвердить пароль";
            }
        }

        private void passwordInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordInput.Text == "Пароль")
            {
                passwordInput.Text = "";
            }
            if (loginInput.Text == "")
            {
                loginInput.Text = "Логин";
            }
            if (confirmPassword.Text == "")
            {
                confirmPassword.Text = "Подтвердить пароль";
            }
        }

        private void confirmPassword_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (confirmPassword.Text == "Подтвердить пароль")
            {
                confirmPassword.Text = "";
            }
            if (loginInput.Text == "")
            {
                loginInput.Text = "Логин";
            }
            if (passwordInput.Text == "")
            {
                passwordInput.Text = "Пароль";
            }
        }
    }
}
