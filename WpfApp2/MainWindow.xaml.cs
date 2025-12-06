using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Classes.Card> Cards { get; set; }
        public ObservableCollection<Classes.Card> DataCard { get; set; }

        public string category = "Инвентарь";
        public MainWindow()
        {
            InitializeComponent();
            Cards = new ObservableCollection<Classes.Card>
            {
                new Classes.Card(1, "Гантель гексагональная обрезиненная 12,5 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Classes.Card(2, "Гантель гексагональная обрезиненная 25 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Classes.Card(3, "Гантель гексагональная обрезиненная 50 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Classes.Card(4, "Гантель гексагональная обрезиненная 100 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Classes.Card(5, "Гантель гексагональная обрезиненная 100 кг", "Одежда", "pack://application:,,,/Images/t-shirt.jpg", 999 )
            };

            DataCard = new ObservableCollection<Classes.Card> { };
            foreach (Classes.Card card in Cards)
            {
                DataCard.Add(card);
            }
            DataContext = this;
        }
        public void createCategory(ObservableCollection<Classes.Card> Cards)
        {
            DataCard.Clear();

            foreach (Classes.Card card in Cards)
            {
                if (category == "Все товары")
                {
                    DataCard.Add(card);
                }
                else if (card.Category == category)
                {
                    DataCard.Add(card);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "invent")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            invent.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Инвентарь";
            createCategory(Cards);
        }

        private void allGoods_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "allGoods")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            allGoods.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Все товары";
            createCategory(Cards);
        }

        private void clothes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "clothes")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            clothes.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Одежда";
            createCategory(Cards);
        }

        private void shoes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "shoes")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            shoes.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Обувь";
            createCategory(Cards);
        }

        private void food_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "food")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            food.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Питание";
            createCategory(Cards);
        }

        private void trainer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "trainer")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            trainer.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Тренажёры";
            createCategory(Cards);
        }

        private void games_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "games")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            games.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Игры";
            createCategory(Cards);
        }
        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            foreach (var elem in menu.Children.OfType<Border>())
            {
                if (elem.Name != "allGoods")
                {
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            allGoods.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Все товары";
            createCategory(Cards);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }
    }
}