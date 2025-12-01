using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static WpfApp1.App;
using static WpfApp1.MainWindow;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    ///
    public partial class App : Application
    {
        public class Basket
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string SmallImagePath { get; set; }

            public Basket(int id, string title, string category, decimal price, string smallImagePath)
            {
                Id = id;
                Name = $"Card{id}";
                Title = title;
                Category = category;
                Price = price;
                SmallImagePath = smallImagePath;
            }
        }
       
        //<Grid HorizontalAlignment = "Center" Height="92" Margin="0,872,0,0" VerticalAlignment="Top">
        //    <Grid HorizontalAlignment = "Left" VerticalAlignment="Top" Width="227" Height="36">
        //        <Image HorizontalAlignment = "Left" VerticalAlignment="Center" Width="36" Height="36" Source="/Profile.png" Margin="20, 0, 0, 0"/>
        //        <TextBlock HorizontalAlignment = "Left" VerticalAlignment="Center" Margin="76, 0, 0, 0" FontFamily="Verdana" FontSize="20" Text="Профиль"/>
        //    </Grid>
        //    <Grid HorizontalAlignment = "Left" VerticalAlignment="Bottom" Width="227" Height="36">
        //        <Image HorizontalAlignment = "Left" VerticalAlignment="Center" Width="36" Height="36" Source="/Logout.png" Margin="20, 0, 0, 0"/>
        //        <TextBlock HorizontalAlignment = "Left" VerticalAlignment="Center" Margin="76, 0, 0, 0" FontFamily="Verdana" FontSize="20" Text="Выйти"/>
        //    </Grid>
        //</Grid>
        public static App CurrentApp => (App)Current;
        //public void basketUpdate(Grid block)
        //{
        //    block.Children.Clear();

        //    for (int i = 0; i < BasketCells.Count; i++)
        //    {
        //        Border basketBorder = new Border();
        //        basketBorder.HorizontalAlignment = HorizontalAlignment.Center;
        //        basketBorder.VerticalAlignment = VerticalAlignment.Top;
        //        basketBorder.Width = 324;
        //        basketBorder.Height = 110;
        //        basketBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(205, 205, 205));
        //        basketBorder.BorderThickness = new Thickness(1);
        //        basketBorder.Background = new SolidColorBrush(Colors.White);
        //        basketBorder.CornerRadius = new CornerRadius(8);
        //        Grid.SetRow(basketBorder, 0);
        //        Grid.SetColumn(basketBorder, 0);

        //        Grid basketGrid = new Grid();
        //        basketBorder.Child = basketGrid;

        //        block.Children.Add(basketBorder);
        //    }
        //}
        //public void addGoodToBasket(string itemName, Grid block)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    BasketCells = new ObservableCollection<Basket> { };
        //    for (int i = 0; i < DataCard.Count; i++)
        //    {

        //        if (BasketCells.Count == 0)
        //        {
        //            BasketCells.Add(new Basket(DataCard[i].Id, DataCard[i].Title, DataCard[i].Category, DataCard[i].Price, "pack://application:,,,/Images/good.jpg"));
        //            break;
        //        }
        //        else
        //        {
        //            foreach(Basket basket in BasketCells)
        //            {
        //                if (basket.Name == itemName)
        //                {
        //                    break;
        //                }
        //                else if (itemName == DataCard[i].Name)
        //                {
        //                    BasketCells.Add(new Basket(DataCard[i].Id, DataCard[i].Title, DataCard[i].Category, DataCard[i].Price, "pack://application:,,,/Images/good.jpg"));
        //                    break;
        //                }
        //            }

        //        }
        //    }
        //    block.Children.Clear();

        //    for (int i = 0; i < BasketCells.Count; i++)
        //    {
        //        Border basketBorder = new Border();
        //        basketBorder.HorizontalAlignment = HorizontalAlignment.Left;
        //        basketBorder.VerticalAlignment = VerticalAlignment.Top;
        //        basketBorder.Width = 324;
        //        basketBorder.Height = 110;
        //        basketBorder.BorderThickness = new Thickness(1);
        //        basketBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(205, 205, 205));
        //        basketBorder.Background = new SolidColorBrush(Colors.White);
        //        basketBorder.CornerRadius = new CornerRadius(8);
        //        Grid.SetRow(basketBorder, 0);
        //        Grid.SetColumn(basketBorder, 0);

        //        Grid basketGrid = new Grid();
        //        basketBorder.Child = basketGrid;

        //        block.Children.Add(basketBorder);
        //    }
        //}

        //<Border HorizontalAlignment = "Center" Height="110" VerticalAlignment="Top" Width="324" BorderBrush="#FFCDCDCD" BorderThickness="1,1,1,1" CornerRadius="8,8,8,8">
        //    <Grid>
        //        <Image HorizontalAlignment = "Left" Height="90" VerticalAlignment="Top" Width="90" Margin="20,10,0,0" Source="/image 4.jpg"/>
        //        <Grid HorizontalAlignment = "Left" Height="90" Margin="120,10,0,0" VerticalAlignment="Top" Width="186">
        //            <TextBlock HorizontalAlignment = "Left" Height="42" TextWrapping="Wrap" Typography.Capitals="AllSmallCaps" Text="Гантель гексагональная обрезиненная 12,5 кг" VerticalAlignment="Top" Width="186" Margin="0,10,0,0" FontFamily="Verdana"/>
        //            <TextBlock HorizontalAlignment = "Right" Height="14" TextWrapping="Wrap" Typography.Capitals="AllSmallCaps" VerticalAlignment="Bottom" Width="53" Margin="0,0,0,10" FontFamily="Verdana" Foreground="#FFF2A65B" TextAlignment="Right"><Run Text = "1299" />< Run Language="ru-ru" Text="р."/></TextBlock>
        //        </Grid>
        //    </Grid>
        //</Border>
        //<Grid HorizontalAlignment = "Center" Height="1024" VerticalAlignment="Center" Width="1440" Background="#4C000000">
        //    <Border HorizontalAlignment = "Center" Height="800" VerticalAlignment="Center" Width="600" Background="White" CornerRadius="8,8,8,8">
        //        <Grid>
        //            <Border HorizontalAlignment = "Center" Height="150" VerticalAlignment="Top" Width="600" CornerRadius="8,8,0,0">
        //                <Border.Background>
        //                    <LinearGradientBrush EndPoint = "0.5,1" StartPoint="0.5,0">
        //                        <GradientStop Color = "#FFF2A65B" />
        //                        < GradientStop Color="#FFEE7A6E" Offset="1"/>
        //                    </LinearGradientBrush>
        //                </Border.Background>
        //                <Grid>
        //                    <TextBlock HorizontalAlignment = "Left" Height="56" Margin="40,0,0,0" TextWrapping="Wrap" VerticalAlignment="Center" Width="154" FontFamily="Verdana" FontSize="48" Foreground="White" Text="Войти"/>
        //                    <Button Width = "64" Height="64" HorizontalAlignment="Left" VerticalAlignment="Center" Margin="496,0,0,0" Click="Button_Click">
        //                        <Button.Background>
        //                            <ImageBrush ImageSource = "/Close.png" />
        //                        </ Button.Background >
        //                    </ Button >
        //                </ Grid >
        //            </ Border >
        //            < Grid HorizontalAlignment="Left" Height="650" Margin="0,150,0,0" VerticalAlignment="Top" Width="600">
        //                <Grid HorizontalAlignment = "Center" Height="200" Margin="0,152,0,0" VerticalAlignment="Top" Width="520">
        //                    <Border HorizontalAlignment = "Center" Height="80" Margin="0,0,0,0" VerticalAlignment="Top" Width="520" Background="#FFEFEFEF" CornerRadius="8,8,8,8" >
        //                        <TextBox x:Name="loginInput" TextWrapping="Wrap" Text="Логин" FontFamily="Verdana" FontSize="24" VerticalContentAlignment="Center" Padding="30,0,0,0" BorderBrush="{x:Null}" Background="{x:Null}" Foreground="#FFCDCDCD" PreviewMouseLeftButtonDown="loginInput_PreviewMouseLeftButtonDown"/>
        //                    </Border>
        //                    <Border HorizontalAlignment = "Center" Height="80" Margin="0,0,0,0" VerticalAlignment="Bottom" Width="520" Background="#FFEFEFEF" CornerRadius="8,8,8,8" >
        //                        <TextBox x:Name="passwordInput" TextWrapping="Wrap" Text="Пароль" FontFamily="Verdana" FontSize="24" VerticalContentAlignment="Center" Padding="30,0,0,0" BorderBrush="{x:Null}" Background="{x:Null}" Foreground="#FFCDCDCD" PreviewMouseLeftButtonDown="passwordInput_PreviewMouseLeftButtonDown"/>
        //                    </Border>
        //                </Grid>
        //                <Grid HorizontalAlignment = "Center" Height="104" Margin="0,474,0,0" VerticalAlignment="Top" Width="520">
        //                    <Border HorizontalAlignment = "Center" Height="63" VerticalAlignment="Top" Width="520" CornerRadius="8,8,8,8" >
        //                        <Border.Background>
        //                            <LinearGradientBrush EndPoint = "0.5,1" StartPoint="0.5,0">
        //                                <LinearGradientBrush.RelativeTransform>
        //                                    <TransformGroup>
        //                                        <ScaleTransform CenterY = "0.5" CenterX="0.5"/>
        //                                        <SkewTransform CenterX = "0.5" CenterY="0.5"/>
        //                                        <RotateTransform Angle = "-90" CenterX="0.5" CenterY="0.5"/>
        //                                        <TranslateTransform/>
        //                                    </TransformGroup>
        //                                </LinearGradientBrush.RelativeTransform>
        //                                <GradientStop Color = "#FFF2A65B" />
        //                                < GradientStop Color="#FFEE7A6E" Offset="1"/>
        //                            </LinearGradientBrush>
        //                        </Border.Background>
        //                        <Button Content = "Войти" FontFamily="Verdana" FontSize="20" Foreground="White" BorderBrush="{x:Null}" Background="{x:Null}" Click="Button_Click_2"/>
        //                    </Border>
        //                    <Grid HorizontalAlignment = "Center" Height="30" VerticalAlignment="Top" Width="239" Margin="0,74,0,0">
        //                        <TextBlock HorizontalAlignment = "Left" Height="23" TextWrapping="Wrap" VerticalAlignment="Bottom" Width="151" Margin="0,0,0,7" FontFamily="Verdana" FontSize="20" Text="Нет аккаунта?"/>
        //                        <Button HorizontalAlignment = "Left" VerticalAlignment="Center" Width="88" Margin="151,0,0,0" FontFamily="Verdana" FontSize="20" Content="Создать" Foreground="#FFF2A65B" Background="{x:Null}" BorderBrush="#FFF2A65B" BorderThickness="0,0,0,1" Padding="0,0,0,4" Height="30" Click="Button_Click_1" />
        //                    </Grid>
        //                </Grid>
        //            </Grid>
        //        </Grid>
        //    </Border>
        //</Grid>
        //<Grid HorizontalAlignment = "Center" Height="1024" VerticalAlignment="Center" Width="1440" Background="#4C000000">
        //    <Border HorizontalAlignment = "Center" Height="800" VerticalAlignment="Center" Width="600" Background="White" CornerRadius="8,8,8,8">
        //        <Grid>
        //            <Border HorizontalAlignment = "Center" Height="150" VerticalAlignment="Top" Width="600" CornerRadius="8,8,0,0">
        //                <Border.Background>
        //                    <LinearGradientBrush EndPoint = "0.5,1" StartPoint="0.5,0">
        //                        <GradientStop Color = "#FFF2A65B" />
        //                        < GradientStop Color="#FFEE7A6E" Offset="1"/>
        //                    </LinearGradientBrush>
        //                </Border.Background>
        //                <Grid>
        //                    <TextBlock HorizontalAlignment = "Left" Height="56" Margin="40,0,0,0" TextWrapping="Wrap" VerticalAlignment="Center" Width="312" FontFamily="Verdana" FontSize="48" Foreground="White" Text="Регистрация"/>
        //                    <Button Width = "64" Height="64" HorizontalAlignment="Right" VerticalAlignment="Center" Margin="0,0,40,0" Click="Button_Click">
        //                        <Button.Background>
        //                            <ImageBrush ImageSource = "/Close.png" />
        //                        </ Button.Background >
        //                    </ Button >
        //                </ Grid >
        //            </ Border >
        //            < Grid HorizontalAlignment="Left" Height="650" Margin="0,150,0,0" VerticalAlignment="Top" Width="600">
        //                <Grid HorizontalAlignment = "Center" Height="320" Margin="0,72,0,0" VerticalAlignment="Top" Width="520">
        //                    <Border HorizontalAlignment = "Center" Height="80" Margin="0,0,0,0" VerticalAlignment="Top" Width="520" Background="#FFEFEFEF" CornerRadius="8,8,8,8" >
        //                        <TextBox x:Name="loginInput" TextWrapping="Wrap" Text="Логин" FontFamily="Verdana" FontSize="24" VerticalContentAlignment="Center" Padding="30,0,0,0" BorderBrush="{x:Null}" Background="{x:Null}" Foreground="#FFCDCDCD" PreviewMouseLeftButtonDown="loginInput_PreviewMouseLeftButtonDown"/>
        //                    </Border>
        //                    <Border HorizontalAlignment = "Center" Height="80" Margin="0,0,0,0" VerticalAlignment="Center" Width="520" Background="#FFEFEFEF" CornerRadius="8,8,8,8" >
        //                        <TextBox x:Name="passwordInput" TextWrapping="Wrap" Text="Пароль" FontFamily="Verdana" FontSize="24" VerticalContentAlignment="Center" Padding="30,0,0,0" BorderBrush="{x:Null}" Background="{x:Null}" Foreground="#FFCDCDCD" PreviewMouseLeftButtonDown="passwordInput_PreviewMouseLeftButtonDown"/>
        //                    </Border>
        //                    <Border HorizontalAlignment = "Center" Height="80" Margin="0,0,0,0" VerticalAlignment="Bottom" Width="520" Background="#FFEFEFEF" CornerRadius="8,8,8,8" >
        //                        <TextBox x:Name="confirmPassword" TextWrapping="Wrap" Text="Подтвердить пароль" FontFamily="Verdana" FontSize="24" VerticalContentAlignment="Center" Padding="30,0,0,0" BorderBrush="{x:Null}" Background="{x:Null}" Foreground="#FFCDCDCD" PreviewMouseLeftButtonDown="confirmPassword_PreviewMouseLeftButtonDown"/>
        //                    </Border>
        //                </Grid>
        //                <Grid HorizontalAlignment = "Center" Height="104" Margin="0,474,0,0" VerticalAlignment="Top" Width="520">
        //                    <Border HorizontalAlignment = "Center" Height="63" VerticalAlignment="Top" Width="520" CornerRadius="8,8,8,8" >
        //                        <Border.Background>
        //                            <LinearGradientBrush EndPoint = "0.5,1" StartPoint="0.5,0">
        //                                <LinearGradientBrush.RelativeTransform>
        //                                    <TransformGroup>
        //                                        <ScaleTransform CenterY = "0.5" CenterX="0.5"/>
        //                                        <SkewTransform CenterX = "0.5" CenterY="0.5"/>
        //                                        <RotateTransform Angle = "-90" CenterX="0.5" CenterY="0.5"/>
        //                                        <TranslateTransform/>
        //                                    </TransformGroup>
        //                                </LinearGradientBrush.RelativeTransform>
        //                                <GradientStop Color = "#FFF2A65B" />
        //                                < GradientStop Color="#FFEE7A6E" Offset="1"/>
        //                            </LinearGradientBrush>
        //                        </Border.Background>
        //                        <Button Content = "Создать" FontFamily="Verdana" FontSize="20" Foreground="White" BorderBrush="{x:Null}" Background="{x:Null}"/>
        //                    </Border>
        //                    <Grid HorizontalAlignment = "Center" Height="30" VerticalAlignment="Bottom" Width="217">
        //                        <TextBlock HorizontalAlignment = "Left" Height="23" TextWrapping="Wrap" VerticalAlignment="Bottom" Width="151" Margin="0,0,0,7" FontFamily="Verdana" FontSize="20" Text="Есть аккаунт?"/>
        //                        <Button HorizontalAlignment = "Left" VerticalAlignment="Center" Width="66" Margin="151,0,0,0" FontFamily="Verdana" FontSize="20" Content="Войти" Foreground="#FFF2A65B" Background="{x:Null}" BorderBrush="#FFF2A65B" BorderThickness="0,0,0,1" Padding="0,0,0,4" Height="30" Click="Button_Click_1" />
        //                    </Grid>
        //                </Grid>
        //            </Grid>
        //        </Grid>
        //    </Border>
        //</Grid>
    }
}
