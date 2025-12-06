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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public ObservableCollection<Classes.User> Users { get; set; }
        public ObservableCollection<Classes.DataField> DataFields { get; set; }
        public Profile()
        {
            InitializeComponent();

            Users = new ObservableCollection<Classes.User>
            {
                new Classes.User(1, "Ктото", "djksdjdks@mail.ru", "user", "12345", "Г. Гдетонск", "88005553535")
            };
            DataFields = new ObservableCollection<Classes.DataField> { };

            DataContext = this;
        }

        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (DataFields.Count > 0)
            {
                DataFields.Clear();
            }
            DataFields.Add(new Classes.DataField("Имя", Users[0].Name));
            DataFields.Add(new Classes.DataField("Адрес", Users[0].Address));
            DataFields.Add(new Classes.DataField("Телефон", Users[0].Phone));
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataFields.Count > 0)
            {
                DataFields.Clear();
            }
            DataFields.Add(new Classes.DataField("Логин", Users[0].Login));
            DataFields.Add(new Classes.DataField("Почта", Users[0].Email));
            DataFields.Add(new Classes.DataField("Пароль", Users[0].Password));
        }
    }
}
