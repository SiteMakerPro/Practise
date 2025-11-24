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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var margin = loginGrid.Margin;
        //    margin.Left = 0;
        //    loginGrid.Margin = margin;
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        // <Frame x:Name="overlayLogin" HorizontalAlignment="Center" Height="1024" VerticalAlignment="Top" Width="1440" Background="#4C000000" Source="/Page2.xaml" Visibility="Collapsed"/>

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    overlayLogin.Visibility = Visibility.Visible;
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //CatalogInvent catalogInvent = new CatalogInvent();
            //catalogInvent.Show();
            //this.Close();
        }

        //private void loginInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (loginInput.Text == "Логин")
        //    {
        //        loginInput.Text = "";
        //    }
        //    if (passwordInput.Text == "")
        //    {
        //        passwordInput.Text = "Пароль";
        //    }
        //}

        //private void passwordInput_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (passwordInput.Text == "Пароль")
        //    {
        //        passwordInput.Text = "";
        //    }
        //    if (loginInput.Text == "")
        //    {
        //        loginInput.Text = "Логин";
        //    }
        //}

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    var margin = loginGrid.Margin;
        //    margin.Left = 1500;
        //    loginGrid.Margin = margin;
        //}
    }
}
