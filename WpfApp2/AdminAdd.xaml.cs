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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : Window
    {
        public ObservableCollection<DataField> EmployeeField { get; set; }
        public ObservableCollection<DataField> GoodField { get; set; }
        public ObservableCollection<DataField> OrderField { get; set; }
        public AdminAdd()
        {
            InitializeComponent();

            EmployeeField = new ObservableCollection<DataField>
            {
                new DataField("Имя", "Напишите имя"),
                new DataField("Должность", "Напишите должность")
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
            Admin admin = new Admin();
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
            MessageBox.Show("Добавлено");
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
