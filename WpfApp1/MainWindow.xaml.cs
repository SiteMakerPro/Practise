using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Properties;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Card> Cards { get; set; }
        public ObservableCollection<Card> DataCard { get; set; }

        public string category = "Инвентарь";
        public MainWindow()
        {
            InitializeComponent();
            Cards = new ObservableCollection<Card>
            {
                new Card(1, "Гантель гексагональная обрезиненная 12,5 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Card(2, "Гантель гексагональная обрезиненная 25 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Card(3, "Гантель гексагональная обрезиненная 50 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Card(4, "Гантель гексагональная обрезиненная 100 кг", "Инвентарь", "pack://application:,,,/Images/good.jpg", 1299 ),
                new Card(5, "Гантель гексагональная обрезиненная 100 кг", "Одежда", "pack://application:,,,/Images/clothes.jpg", 999 )
            };

            DataCard = new ObservableCollection<Card> { };
            foreach (Card card in Cards)
            {
                DataCard.Add(card);
            }
            DataContext = this;
        }
        public void createCategory(ObservableCollection<Card> Cards)
        {
            DataCard.Clear();

            foreach (Card card in Cards)
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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
                    //elem.Background = new SolidColorBrush(Colors.White);
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



        // Оверлей страницы Логин

        // <Frame x:Name="overlayLogin" HorizontalAlignment="Center" Height="1024" VerticalAlignment="Top" Width="1440" Background="#4C000000" Source="/Page2.xaml" Visibility="Collapsed"/>

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    overlayLogin.Visibility = Visibility.Visible;
        //}

        // Вёрстка каталога

        //<Grid HorizontalAlignment = "Left" VerticalAlignment="Top" Width="693" Height="839">
        //    <Grid.RowDefinitions>
        //        <RowDefinition Height = "*" />
        //        < RowDefinition Height="39"/>
        //        <RowDefinition Height = "*" />
        //    </ Grid.RowDefinitions >
        //    < Grid.ColumnDefinitions >
        //        < ColumnDefinition Width="*"/>
        //        <ColumnDefinition Width = "93" />
        //        < ColumnDefinition Width="*"/>
        //    </Grid.ColumnDefinitions>
        //    <Border BorderThickness = "1" CornerRadius="8,8,8,8" Background="White">
        //        <Grid>
        //            <Image HorizontalAlignment = "Left" Height="200" VerticalAlignment="Top" Width="260" Margin="20,20,0,0" Source="/image 3.jpg" Stretch="Fill"/>
        //            <TextBlock HorizontalAlignment = "Left" Height="38" Margin="20,240,0,0" TextWrapping="Wrap" Price="Гантель гексагональная обрезиненная 12,5 кг" VerticalAlignment="Top" Width="260" FontFamily="Verdana" FontSize="16"/>
        //            <TextBlock HorizontalAlignment = "Left" Height="21" Margin="20,298,0,0" TextWrapping="Wrap" Price="1299р" VerticalAlignment="Top" Width="51" FontFamily="Verdana" FontSize="16"/>
        //            <Border HorizontalAlignment = "Left" Height="41" Margin="20,339,0,0" VerticalAlignment="Top" Width="260" CornerRadius="8,8,8,8" >
        //                <Border.Background>
        //                    <LinearGradientBrush EndPoint = "0.5,1" StartPoint="0.5,0">
        //                        <LinearGradientBrush.RelativeTransform>
        //                            <TransformGroup>
        //                                <ScaleTransform CenterY = "0.5" CenterX="0.5"/>
        //                                <SkewTransform CenterX = "0.5" CenterY="0.5"/>
        //                                <RotateTransform Angle = "-90" CenterX="0.5" CenterY="0.5"/>
        //                                <TranslateTransform/>
        //                            </TransformGroup>
        //                        </LinearGradientBrush.RelativeTransform>
        //                        <GradientStop Color = "#FFF2A65B" />
        //                        < GradientStop Color="#FFEE7A6E" Offset="1"/>
        //                    </LinearGradientBrush>
        //                </Border.Background>
        //                <Button Content = "В корзину" FontFamily="Verdana" FontSize="18" Background="{x:Null}" BorderBrush="{x:Null}" Foreground="White"/>
        //            </Border>
        //        </Grid>
        //    </Border>
    }
}
