using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Good
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string ImagePath { get; set; }
        }
        public ObservableCollection<Good> Goods { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Goods = new ObservableCollection<Good>
            {
                new Good {Id=1, ImagePath="/Images/good.jpg", Title="Гантель гексагональная обрезиненная 12,5 кг", Category="Инвентарь", Price=1299 },
                new Good {Id=2, ImagePath="/Images/good.jpg", Title="Гантель гексагональная обрезиненная 25 кг", Category="Инвентарь", Price=1299 },
                new Good {Id=3, ImagePath="/Images/good.jpg", Title="Гантель гексагональная обрезиненная 50 кг", Category="Инвентарь", Price=1299 },
                new Good {Id=4, ImagePath="/Images/good.jpg", Title="Гантель гексагональная обрезиненная 100 кг", Category="Инвентарь", Price=1299 }
            };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        void createCard()
        {
            for (int i = 0, count = 0; i < (Goods.Count + 1) / 2 || count <= Goods.Count - 1; i++)
            {
                for (int j = 0; count <= Goods.Count - 1 && j < 2; j++, count++)
                {
                    Border card = new Border();
                    var id = Goods[count].Id;
                    card.Name = $"card{id}";
                    card.BorderThickness = new Thickness(1);
                    card.CornerRadius = new CornerRadius(8);
                    card.Background = new SolidColorBrush(Colors.White);
                    Grid.SetRow(card, i + i);
                    Grid.SetColumn(card, j + j);
                    Grid cardGrid = new Grid();
                    card.Child = cardGrid;

                    Image cardImage = new Image();
                    cardImage.HorizontalAlignment = HorizontalAlignment.Left;
                    cardImage.VerticalAlignment = VerticalAlignment.Top;
                    cardImage.Width = 260;
                    cardImage.Height = 200;
                    cardImage.Margin = new Thickness(20, 20, 0, 0);
                    cardImage.Stretch = Stretch.Fill;
                    cardImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/good.jpg"));
                    cardGrid.Children.Add(cardImage);

                    TextBlock cardTitle = new TextBlock();
                    cardTitle.HorizontalAlignment = HorizontalAlignment.Left;
                    cardTitle.VerticalAlignment = VerticalAlignment.Top;
                    cardTitle.Width = 260;
                    cardTitle.Height = 38;
                    cardTitle.Margin = new Thickness(20, 240, 0, 0);
                    cardTitle.FontFamily = new FontFamily("Verdana");
                    cardTitle.FontSize = 16;
                    cardTitle.Text = Goods[count].Title;
                    cardTitle.TextWrapping = TextWrapping.Wrap;
                    cardGrid.Children.Add( cardTitle );

                    TextBlock cardPrice = new TextBlock();
                    cardPrice.HorizontalAlignment = HorizontalAlignment.Left;
                    cardPrice.VerticalAlignment = VerticalAlignment.Top;
                    cardPrice.Width = 51;
                    cardPrice.Height = 21;
                    cardPrice.Margin = new Thickness(20, 298, 0, 0);
                    cardPrice.FontFamily = new FontFamily("Verdana");
                    cardPrice.FontSize = 16;
                    cardPrice.Text = $"{Goods[count].Price}р.";
                    cardGrid.Children.Add( cardPrice );

                    TransformGroup gradientGroup = new TransformGroup();
                    gradientGroup.Children.Add(new ScaleTransform(0.5, 0.5));
                    gradientGroup.Children.Add(new SkewTransform(0.5, 0.5));
                    gradientGroup.Children.Add(new RotateTransform(-90, 0.5, 0.5));

                    GradientStopCollection gradientStops = new GradientStopCollection();
                    gradientStops.Add(new GradientStop(Color.FromRgb(242, 166, 91), 0.0));
                    gradientStops.Add(new GradientStop(Color.FromRgb(238, 122, 110), 1.0));

                    LinearGradientBrush buttonGradient = new LinearGradientBrush();
                    buttonGradient.StartPoint = new Point(0.5, 0);
                    buttonGradient.EndPoint = new Point(0.5, 1);
                    buttonGradient.RelativeTransform = gradientGroup;
                    buttonGradient.GradientStops = gradientStops;

                    Border buttonBorder = new Border();
                    buttonBorder.HorizontalAlignment = HorizontalAlignment.Left;
                    buttonBorder.VerticalAlignment = VerticalAlignment.Top;
                    buttonBorder.Width = 260;
                    buttonBorder.Height = 41;
                    buttonBorder.Margin = new Thickness(20, 339, 0, 0);
                    buttonBorder.CornerRadius = new CornerRadius(8);
                    buttonBorder.Background = buttonGradient;
                    cardGrid.Children.Add(buttonBorder);

                    Button cardButton = new Button();
                    cardButton.FontFamily = new FontFamily("Verdana");
                    cardButton.FontSize = 18;
                    cardButton.Content = "В корзину";
                    cardButton.Foreground = new SolidColorBrush(Colors.White);
                    cardButton.Background = null;
                    cardButton.BorderBrush = null;
                    buttonBorder.Child = cardButton;

                    catalog.Children.Add( card );
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            createCard();
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
        //            <TextBlock HorizontalAlignment = "Left" Height="38" Margin="20,240,0,0" TextWrapping="Wrap" Text="Гантель гексагональная обрезиненная 12,5 кг" VerticalAlignment="Top" Width="260" FontFamily="Verdana" FontSize="16"/>
        //            <TextBlock HorizontalAlignment = "Left" Height="21" Margin="20,298,0,0" TextWrapping="Wrap" Text="1299р" VerticalAlignment="Top" Width="51" FontFamily="Verdana" FontSize="16"/>
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
