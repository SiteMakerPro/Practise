using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static WpfApp1.MainWindow;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    ///
    public partial class App : Application
    {
        public class Card
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string Text { get; set; }
            public string BigImagePath { get; set; }

            public Card(int id, string title, string category, string bigImagePath, decimal price = 0)
            {
                Id = id;
                Title = title;
                Category = category;
                Price = price;
                BigImagePath = bigImagePath;
            }
            public Card(int id, string title, string category, string bigImagePath, string text)
            {
                Id = id;
                Title = title;
                Category = category;
                Text = text;
                BigImagePath = bigImagePath;
            }
        }
        public static App CurrentApp => (App)Current;
        public void createCard(ObservableCollection<Card> Cards, Grid block)
        {
            bool text = true;

            foreach (Card card in Cards)
            {
                if (card.Text == null) text = false;
            }
            for (int i = 0, count = 0; i < (Cards.Count + 1) / 2 || count <= Cards.Count - 1; i++)
            {
                for (int j = 0; count <= Cards.Count - 1 && j < 2; j++, count++)
                {
                    Border card = new Border();
                    var id = Cards[count].Id;
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
                    cardImage.Source = new BitmapImage(new Uri(Cards[count].BigImagePath));
                    cardGrid.Children.Add(cardImage);

                    TextBlock cardTitle = new TextBlock();
                    cardTitle.HorizontalAlignment = HorizontalAlignment.Left;
                    cardTitle.VerticalAlignment = VerticalAlignment.Top;
                    cardTitle.Width = 260;
                    cardTitle.Height = 38;
                    cardTitle.Margin = new Thickness(20, 240, 0, 0);
                    cardTitle.FontFamily = new FontFamily("Verdana");
                    cardTitle.FontSize = 16;
                    cardTitle.Text = Cards[count].Title;
                    cardTitle.TextWrapping = TextWrapping.Wrap;
                    cardGrid.Children.Add(cardTitle);

                    if (text)
                    {
                        TextBlock cardText = new TextBlock();
                        cardText.HorizontalAlignment = HorizontalAlignment.Left;
                        cardText.VerticalAlignment = VerticalAlignment.Top;
                        cardText.Width = 120;
                        cardText.Height = 21;
                        cardText.Margin = new Thickness(20, 298, 0, 0);
                        cardText.FontFamily = new FontFamily("Verdana");
                        cardText.FontSize = 16;
                        cardText.Text = $"{Cards[count].Text}";
                        cardGrid.Children.Add(cardText);
                    }
                    else
                    {
                        TextBlock cardPrice = new TextBlock();
                        cardPrice.HorizontalAlignment = HorizontalAlignment.Left;
                        cardPrice.VerticalAlignment = VerticalAlignment.Top;
                        cardPrice.Width = 61;
                        cardPrice.Height = 21;
                        cardPrice.Margin = new Thickness(20, 298, 0, 0);
                        cardPrice.FontFamily = new FontFamily("Verdana");
                        cardPrice.FontSize = 16;
                        cardPrice.Text = $"{Cards[count].Price}р.";
                        cardGrid.Children.Add(cardPrice);
                    }

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

                    block.Children.Add(card);
                }
            }
        }
    }
}
