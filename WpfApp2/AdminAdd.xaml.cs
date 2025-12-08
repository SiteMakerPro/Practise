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
    /// Логика взаимодействия для AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : Window
    {
        public users _currentUser;
        public ObservableCollection<DataField> EmployeeField { get; set; }
        public ObservableCollection<DataField> GoodField { get; set; }
        public ObservableCollection<DataField> OrderField { get; set; }
        public int itemId;
        public AdminAdd(users user)
        {
            InitializeComponent();

            _currentUser = user;

            EmployeeField = new ObservableCollection<DataField>
            {
                new DataField("Должность", "Напишите номер должности"),
                new DataField("Логин", "Напишите логин"),
                new DataField("Пароль", "Напишите пароль"),
                new DataField("Фамилия", "Напишите фамилию"),
                new DataField("Имя", "Напишите имя"),
                new DataField("Отчество", "Напишите отчество"),
                new DataField("Телефон", "Напишите телефон"),
                new DataField("Почта", "Напишите почту")
            };
            GoodField = new ObservableCollection<DataField>
            {
                new DataField("Название", "Напишите название"),
                new DataField("Категория", "Напишите категорию"),
                new DataField("Цена", "Напишите цену")
            };
            OrderField = new ObservableCollection<DataField>
            {
                new DataField("Номер", "Напишите номер"),
                new DataField("Дата заказа", "Напишите дату заказа")
            };
            DataContext = this;
        }

        private void edit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Admin admin = new Admin(_currentUser);
            admin.Show();
            this.Close();
        }

        private void employee_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fields.ItemsSource = EmployeeField;
        }

        private void good_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fields.ItemsSource = GoodField;
        }

        private void order_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fields.ItemsSource = OrderField;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DbService.AddEmployee(new users { IdU = App.usersList.Count + 1, IdR = Int32.Parse(EmployeeField[0].Value), Login = EmployeeField[1].Value, Password = EmployeeField[2].Value, Lastname = EmployeeField[3].Value, Firstname = EmployeeField[4].Value, Patronymic = EmployeeField[5].Value, Phone = EmployeeField[6].Value, Email = EmployeeField[7].Value });
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
