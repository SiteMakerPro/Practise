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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    /// 
    public partial class User : Window
    {
        public ObservableCollection<BasketCell> BasketCells { get; set; }
        public string category = "Инвентарь";
        public MainWindow mainWindow = new MainWindow();

        public decimal halfPrice = 0;
        public decimal taxPrice = 0;
        public decimal totalPrice = 0;
        public User()
        {
            InitializeComponent();

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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            games.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Игры";
            createCategory(mainWindow.Cards);
        }

        public void basketButton_PreviewMouseLeftButtonDown(object sender, MouseEventArgs e)
        {

            //foreach (var card in DataCard)
            //{
            //    if(card.Name == itemName)
            //    {
            //        BasketCells.Add(card);
            //    }
            //}
            //App.CurrentApp.addGoodToBasket(itemName, basket);
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //App.CurrentApp.basketUpdate(basket);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
                    elem.Style = (Style)Application.Current.FindResource("BorderStyle1");
                }
            }
            allGoods.Style = (Style)Application.Current.FindResource("BtnActivated");
            category = "Все товары";
            createCategory(mainWindow.Cards);
        }

        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }
    }
}
