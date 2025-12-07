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
using WpfApp2.Classes;
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public users _currentUser;
        public ObservableCollection<Employee> EmployeeCard { get; set; }
        public ObservableCollection<Good> GoodCard { get; set; }
        public ObservableCollection<Order> OrderCard { get; set; }
        public ObservableCollection<DataField> GoodField { get; set; }
        public string category = "goods";
        public int order = 1;
        public int itemOrder;
        public int itemId;
        public Admin(users user)
        {
            InitializeComponent();
            _currentUser = user;

            
            var categoriesList = DbService.GetAllCategories();

            EmployeeCard = new ObservableCollection<Employee>{};

            foreach(users users in App.usersList)
            {
                if (users.IdR == 1 && users.IdU != _currentUser.IdU)
                {
                    EmployeeCard.Add(new Employee(users.IdU, order, users.Lastname, users.Firstname, users.Patronymic, "Админ", "pack://application:,,,/Images/human.png"));
                    order++;
                }
                if (users.IdR == 3)
                {
                    EmployeeCard.Add(new Employee(users.IdU, order, users.Lastname, users.Firstname, users.Patronymic, "ПВЗ", "pack://application:,,,/Images/human.png"));
                    order++;
                }
            }
            order = 0;

            GoodCard = new ObservableCollection<Good> { };

            foreach (goods good in App.goodList)
            {
                GoodCard.Add(new Good(good.IdG, order, good.Name, categoriesList[good.IdCa].Name, good.Img, good.Price));
                order++;
            }

            OrderCard = new ObservableCollection<Order>
            {
                new Order(1, "Заказ", 1, "pack://application:,,,/Images/good.jpg"),
                new Order(2, "Заказ", 2, "pack://application:,,,/Images/good.jpg"),
                new Order(3, "Заказ", 3, "pack://application:,,,/Images/good.jpg"),
                new Order(4, "Заказ", 4, "pack://application:,,,/Images/good.jpg"),
            };

            GoodField = new ObservableCollection<DataField> { };

            DataContext = this;
        }

        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var item = sender as Border;
            itemOrder = (int)item.Tag;
            GoodField.Clear();
            if (category == "goods")
            {
                foreach (Good good in GoodCard)
                {
                    if (good.Id == itemOrder)
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
                    if (employee.Order == itemOrder)
                    {
                        GoodField.Add(new DataField("Фамилия", employee.Lastname));
                        GoodField.Add(new DataField("Имя", employee.Firstname));
                        GoodField.Add(new DataField("Отчество", employee.Patronymic));
                        GoodField.Add(new DataField("Должность", employee.Text));
                    }

                }
            }
            else if (category == "orders")
            {
                foreach (Order order in OrderCard)
                {
                    if (order.Id == itemOrder)
                    {
                        GoodField.Add(new DataField("Номер заказа", order.Id.ToString()));
                        GoodField.Add(new DataField("Номер товара", order.Text.ToString()));
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
            AdminAdd adminAdd = new AdminAdd(_currentUser);
            adminAdd.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Employee employee in EmployeeCard)
            {
                if (itemOrder == employee.Order)
                {
                    itemId = employee.Id;
                    break;
                }
            }
            foreach (users user in App.usersList)
            {
                if (itemId == user.IdU)
                {
                    DbService.UpdateEmployee(user);
                    break;
                }
            }
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

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var item = sender as TextBox;
            if (item.Text != "")
            {
                foreach (users user in App.usersList)
                {
                    if (itemId == user.IdU)
                    {
                        if (item.Tag == "Фамилия")
                        {
                            user.Lastname = item.Text;
                        }
                    }
                }
            }
        }
    }
}
