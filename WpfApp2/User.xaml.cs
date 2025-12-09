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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public users _currentUser;
        public ObservableCollection<BasketCell> BasketCells { get; set; }
        public string category = "Инвентарь";
        public MainWindow mainWindow = new MainWindow();

        public decimal halfPrice = 0;
        public decimal taxPrice = 0;
        public decimal totalPrice = 0;
        public User(users user)
        {
            InitializeComponent();

            _currentUser = user;

            BasketCells = new ObservableCollection<BasketCell> { };

            DataContext = mainWindow.DataContext;
        }

        public void createCategory(ObservableCollection<Card> Cards)
        {
            mainWindow.DataCard.Clear();

            foreach (Card card in Cards)
            {
                if (category == "Все товары")
                {
                    mainWindow.DataCard.Add(card);
                }
                else if (card.Category == category)
                {
                    mainWindow.DataCard.Add(card);
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
            createCategory(mainWindow.Cards);
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
            createCategory(mainWindow.Cards);
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
            createCategory(mainWindow.Cards);
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
            createCategory(mainWindow.Cards);
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
            createCategory(mainWindow.Cards);
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
            createCategory(mainWindow.Cards);
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
            createCategory(mainWindow.Cards);
        }

        public int basketCount = 1;

        private void basketButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as Border;
            int itemId = (int)item.Tag;
            foreach (var card in mainWindow.DataCard)
            {
                decimal price = 0;
                if (BasketCells.Count < 4)
                {
                    if (card.Id == itemId)
                    {
                        BasketCells.Add(new BasketCell(card.Id, basketCount, card.Title, card.Category, card.BigImagePath, card.Price));
                        price = card.Price;
                        halfPrice += price;
                        basketCount++;
                    }
                    ChangePrice(price);
                }

            }
            basket.DataContext = this;
        }

        private void ChangePrice(decimal price)
        {
            taxPrice = halfPrice * 20 / 100;
            totalPrice = halfPrice + taxPrice;

            half_price.Text = $"{halfPrice}р.";
            tax.Text = $"{taxPrice}р.";
            total_price.Text = $"{totalPrice}р.";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (BasketCells.Count > 0)
            {
                BasketCells.Clear();
                halfPrice = 0;
                taxPrice = 0;
                totalPrice = 0;
                basketCount = 1;
                half_price.Text = "0р.";
                tax.Text = "0р.";
                total_price.Text = "0р.";
            }
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
            createCategory(mainWindow.Cards);
        }

        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (BasketCells.Count > 0)
            {
                MessageBox.Show("Оплачено");
            }
            else
            {
                MessageBox.Show("Корзина пустая");
            }
        }

        private void Border_PreviewMouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            Profile profile = new Profile(_currentUser);
            profile.Show();
            this.Close();
        }
    }
}
