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
        public ObservableCollection<Classes.Employee> EmployeeCard { get; set; }
        public ObservableCollection<Classes.Good> GoodCard { get; set; }
        public ObservableCollection<Classes.Order> OrderCard { get; set; }
        public ObservableCollection<Classes.DataField> GoodField { get; set; }
        public string category = "goods";
        public int order = 1;
        public Admin(users user)
        {
            InitializeComponent();
            _currentUser = user;

            var usersList = DbService.GetAllUsers();
            var goodList = DbService.GetAllGoods();

            EmployeeCard = new ObservableCollection<Classes.Employee>{};

            foreach(users users in usersList)
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

            GoodCard = new ObservableCollection<Classes.Good> { };

            foreach (goods good in goodList)
            {
                if (good.IdCa == 1)
                {
                    GoodCard.Add(new Good(good.IdG, order, good.Name, "Инвентарь", good.Img, good.Price));
                    order++;
                }
                else if (good.IdCa == 2)
                {
                    GoodCard.Add(new Good(good.IdG, order, good.Name, "Одежда", good.Img, good.Price));
                    order++;
                }
                else if (good.IdCa == 3)
                {
                    GoodCard.Add(new Good(good.IdG, order, good.Name, "Обувь", good.Img, good.Price));
                    order++;
                }
            }

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
                    if (employee.Order == itemId)
                    {
                        GoodField.Add(new Classes.DataField("Фамилия", employee.Lastname));
                        GoodField.Add(new Classes.DataField("Имя", employee.Firstname));
                        GoodField.Add(new Classes.DataField("Отчество", employee.Patronymic));
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
            AdminAdd adminAdd = new AdminAdd(_currentUser);
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
