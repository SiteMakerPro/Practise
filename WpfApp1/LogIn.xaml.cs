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

namespace WpfApp1
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
            if (loginInput.Text.Length > 0 && passwordInput.Text.Length > 0)
            {
                if (loginInput.Text == "user" && passwordInput.Text == "12345")
                {
                    User user = new User();
                    user.Show();
                    this.Close();
                }
            }
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (loginInput.Text.Length > 0)
        //    {
        //        if (loginInput.Text == "admin")
        //        {
        //            AdminPanel adminPanel = new AdminPanel();
        //            adminPanel.Show();
        //            this.Close();
        //        }
        //        else if (loginInput.Text == "manager")
        //        {
        //            Manager manager = new Manager();
        //            manager.Show();
        //            this.Close();
        //        }
        //    }
        //}

        //private void loginInput_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    if (loginInput.Text == "Логин" && passwordInput.Text == "12345")
        //    {
        //        loginInput.Text = "";
        //    }
        //}

        //private void Window_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        if (loginInput.Text.Length > 0)
        //        {
        //            if (loginInput.Text == "admin")
        //            {
        //                AdminPanel adminPanel = new AdminPanel();
        //                adminPanel.Show();
        //                this.Close();
        //            }
        //            else if (loginInput.Text == "manager")
        //            {
        //                Manager manager = new Manager();
        //                manager.Show();
        //                this.Close();
        //            }
        //        }
        //    }
        //}
    }
}
