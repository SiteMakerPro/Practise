using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public ObservableCollection<Employee> EmployeeCard { get; set; }
        public ObservableCollection<Good> GoodCard { get; set; }
        public ObservableCollection<Order> OrderCard { get; set; }
        public ObservableCollection<DataField> GoodField { get; set; }
        public string category = "goods";
        public Admin()
        {
            InitializeComponent();
            EmployeeCard = new ObservableCollection<Employee>
            {
                new Employee(1, "Ктотов Ктото Ктотович", "Оператор ПВЗ", "pack://application:,,,/Images/good.jpg"),
                new Employee(2, "Ктотов Ктото Ктотович", "Администратор", "pack://application:,,,/Images/good.jpg"),
                new Employee(3, "Ктотов Ктото Ктотович", "Оператор ПВЗ", "pack://application:,,,/Images/good.jpg"),
                new Employee(4, "Ктотов Ктото Ктотович", "Оператор ПВЗ", "pack://application:,,,/Images/good.jpg")
            };

            GoodCard = new ObservableCollection<Good>
            {
                new Good(1, "Гантель гексагональная обрезиненная 12,5 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Good(2, "Гантель гексагональная обрезиненная 25 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Good(3, "Гантель гексагональная обрезиненная 50 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Good(4, "Гантель гексагональная обрезиненная 100 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
            };

            OrderCard = new ObservableCollection<Order>
            {
                new Order(1, "Заказ", 1, "pack://application:,,,/Images/good.jpg"),
                new Order(2, "Заказ", 2, "pack://application:,,,/Images/good.jpg"),
                new Order(3, "Заказ", 3, "pack://application:,,,/Images/good.jpg"),
                new Order(4, "Заказ", 4, "pack://application:,,,/Images/good.jpg"),
            };

            GoodField = new ObservableCollection<DataField>{};

            DataContext = this;
        }

        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var item = sender as Border;
            int itemId = (int)item.Tag;
            GoodField.Clear();
            if (category == "goods")
            {
                foreach (Good good in GoodCard)
                {
                    if (good.Id == itemId)
                    {
                        GoodField.Add(new DataField("Номер", good.Id.ToString()));
                        GoodField.Add(new DataField("Название", good.Name));
                        GoodField.Add(new DataField("Категория", good.Category));
                    }
                        
                }
            }
            else if (category == "employees")
            {
                foreach (Employee employee in EmployeeCard)
                {
                    if (employee.Id == itemId)
                    {
                        GoodField.Add(new DataField("Имя", employee.Name));
                        GoodField.Add(new DataField("Должность", employee.Text));
                    }
                        
                }
            }
            
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "goods")
                {
                    //elem.Background = new SolidColorBrush(Colors.White);
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            goods.Style = (Style)Application.Current.FindResource("BtnActivated");
            catalog.ItemsSource = GoodCard;
            category = "goods";
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "goods")
                {
                    //elem.Background = new SolidColorBrush(Colors.White);
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            goods.Style = (Style)Application.Current.FindResource("BtnActivated");

        }

        private void employees_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "employees")
                {
                    //elem.Background = new SolidColorBrush(Colors.White);
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            employees.Style = (Style)Application.Current.FindResource("BtnActivated");
            catalog.ItemsSource = EmployeeCard;
            category = "employees";
        }

        private void orders_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "orders")
                {
                    //elem.Background = new SolidColorBrush(Colors.White);
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            orders.Style = (Style)Application.Current.FindResource("BtnActivated");
            catalog.ItemsSource = OrderCard;
            category = "orders";
        }

        private void add_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminAdd adminAdd = new AdminAdd();
            adminAdd.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Изменено");
        }

        private void Border_PreviewMouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
