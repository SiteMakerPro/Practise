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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginInput.Text.Length > 0 && passwordInput.Text.Length > 0)
            {
                if (loginInput.Text == "user" && passwordInput.Text == "12345")
                {
                    User user = new User();
                    user.Show();
                    this.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
