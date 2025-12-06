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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public ObservableCollection<Classes.Employee> EmployeeCard { get; set; }
        public ObservableCollection<Classes.Good> GoodCard { get; set; }
        public ObservableCollection<Classes.Order> OrderCard { get; set; }
        public ObservableCollection<Classes.DataField> GoodField { get; set; }
        public string category = "goods";
        public Admin()
        {
            InitializeComponent();
            EmployeeCard = new ObservableCollection<Classes.Employee>
            {
                new Classes.Employee(1, "Ктотов Ктото Ктотович", "Оператор ПВЗ", "pack://application:,,,/Images/good.jpg"),
                new Classes.Employee(2, "Ктотов Ктото Ктотович", "Администратор", "pack://application:,,,/Images/good.jpg"),
                new Classes.Employee(3, "Ктотов Ктото Ктотович", "Оператор ПВЗ", "pack://application:,,,/Images/good.jpg"),
                new Classes.Employee(4, "Ктотов Ктото Ктотович", "Оператор ПВЗ", "pack://application:,,,/Images/good.jpg")
            };

            GoodCard = new ObservableCollection<Classes.Good>
            {
                new Classes.Good(1, "Гантель гексагональная обрезиненная 12,5 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Classes.Good(2, "Гантель гексагональная обрезиненная 25 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Classes.Good(3, "Гантель гексагональная обрезиненная 50 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Classes.Good(4, "Гантель гексагональная обрезиненная 100 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
            };

            OrderCard = new ObservableCollection<Classes.Order>
            {
                new Classes.Order(1, "Заказ", 1, "pack://application:,,,/Images/good.jpg"),
                new Classes.Order(2, "Заказ", 2, "pack://application:,,,/Images/good.jpg"),
                new Classes.Order(3, "Заказ", 3, "pack://application:,,,/Images/good.jpg"),
                new Classes.Order(4, "Заказ", 4, "pack://application:,,,/Images/good.jpg"),
            };

            GoodField = new ObservableCollection<Classes.DataField> { };

            DataContext = this;
        }

        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var item = sender as Border;
            int itemId = (int)item.Tag;
            GoodField.Clear();
            if (category == "goods")
            {
                foreach (Classes.Good good in GoodCard)
                {
                    if (good.Id == itemId)
                    {
                        GoodField.Add(new Classes.DataField("Номер", good.Id.ToString()));
                        GoodField.Add(new Classes.DataField("Название", good.Name));
                        GoodField.Add(new Classes.DataField("Категория", good.Category));
                    }

                }
            }
            else if (category == "employees")
            {
                foreach (Classes.Employee employee in EmployeeCard)
                {
                    if (employee.Id == itemId)
                    {
                        GoodField.Add(new Classes.DataField("Имя", employee.Name));
                        GoodField.Add(new Classes.DataField("Должность", employee.Text));
                    }

                }
            }
            else if (category == "orders")
            {
                foreach (Classes.Order order in OrderCard)
                {
                    if (order.Id == itemId)
                    {
                        GoodField.Add(new Classes.DataField("Номер заказа", order.Id.ToString()));
                        GoodField.Add(new Classes.DataField("Номер товара", order.Text.ToString()));
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

        private void Border_PreviewMouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            var item = sender as Border;
            int itemId = (int)item.Tag;

            if (category == "goods")
            {
                for (int i = 0; i < GoodCard.Count; i++)
                {
                    if (GoodCard[i].Id == itemId)
                    {
                        GoodCard.Remove(GoodCard[i]);
                    }
                }
            }
            else if (category == "employees")
            {
                for (int i = 0; i < EmployeeCard.Count; i++)
                {
                    if (EmployeeCard[i].Id == itemId)
                    {
                        EmployeeCard.Remove(EmployeeCard[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < OrderCard.Count; i++)
                {
                    if (OrderCard[i].Id == itemId)
                    {
                        OrderCard.Remove(OrderCard[i]);
                    }
                }
            }
        }
    }
}
