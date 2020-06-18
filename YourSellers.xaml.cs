using ProjektImplementacja.DatabaseOperations;
using ProjektImplementacja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektImplementacja
{
    /// <summary>
    /// Interaction logic for YourSellers.xaml
    /// </summary>
    public partial class YourSellers : Page
    {
        Event checkedEvent = null;
        Wystawca checkedSeller = null;

        Grid checkedGrid = null;

        public YourSellers(Event checkedEvent)
        {
            InitializeComponent();
            this.checkedEvent = checkedEvent;

            YourSellersGrid.Children.Clear();
            List<Wystawca> wystawcy = UzytkownikOperations.GetWystawcy();
            AddWystawcy(wystawcy);

            if (wystawcy.Count == 0)
            {
                ErrorText.Text = "Nie posiadasz żadnych zaplanowanych eventów.";
                ErrorText.Visibility = Visibility.Visible;
            }
        }

        private void AddWystawcy(List<Wystawca> wystawcy)
        {
            int count = 0;
            foreach (Wystawca w in wystawcy)
            {
                RowDefinition newRow = new RowDefinition();
                newRow.Height = new GridLength(80);
                YourSellersGrid.RowDefinitions.Add(newRow);

                Grid sellerGrid = new Grid();
                sellerGrid.Effect = new DropShadowEffect
                {
                    Color = new Color { A = 0, R = 0, G = 0, B = 0 },
                    Direction = 330,
                    ShadowDepth = 2,
                    Opacity = 0.5,
                    BlurRadius = 4
                };

                sellerGrid.Margin = new Thickness(10);
                Color color = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                sellerGrid.Background = new SolidColorBrush(color);
                sellerGrid.MouseEnter += Over;
                sellerGrid.MouseLeave += Out;
                sellerGrid.MouseDown += CheckSeller;

                Label valueLabel = new Label();
                valueLabel.Content = w.IdWystawca;
                valueLabel.Visibility = Visibility.Hidden;
                sellerGrid.Children.Add(valueLabel);

                TextBlock sellerName = new TextBlock();
                sellerName.Text = w.NazwaFirmy;
                sellerName.Foreground = new SolidColorBrush(Colors.White);
                sellerName.VerticalAlignment = VerticalAlignment.Center;
                sellerName.FontSize = 30;
                sellerName.Margin = new Thickness(10, 0, 10, 0);
                Grid.SetRow(sellerName, 0);
                sellerGrid.Children.Add(sellerName);

                Grid.SetRow(sellerGrid, count++);
                YourSellersGrid.Children.Add(sellerGrid);
            }
        }

        private void CheckSeller(object sender, MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (checkedGrid == grid)
            {
                Color c = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                checkedGrid.Background = new SolidColorBrush(c);
                checkedSeller = null;
                checkedGrid = null;
                NextButton.IsEnabled = false;
            }
            else if (checkedGrid != null)
            {
                Color c = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                checkedGrid.Background = new SolidColorBrush(c);
                checkedSeller = null;
                checkedGrid = null;

                Color color = (Color)ColorConverter.ConvertFromString("#FFFFC7BB");
                grid.Background = new SolidColorBrush(color);
                checkedGrid = grid;
                Label valueLabel = grid.Children.OfType<Label>().FirstOrDefault();
                checkedSeller = WystawcaOperations.GetWystawcaById(int.Parse(valueLabel.Content.ToString()));
                NextButton.IsEnabled = true;
            }
            else if (checkedGrid == null)
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FFFFC7BB");
                grid.Background = new SolidColorBrush(color);
                checkedGrid = grid;
                Label valueLabel = grid.Children.OfType<Label>().FirstOrDefault();
                checkedSeller = WystawcaOperations.GetWystawcaById(int.Parse(valueLabel.Content.ToString()));
                NextButton.IsEnabled = true;
            }

        }

        private void WhenSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window window = Application.Current.MainWindow;
            double scale;

            if (window.WindowState == WindowState.Maximized)
                scale = System.Windows.SystemParameters.PrimaryScreenHeight / 720;
            else
                scale = 1;

            ScaleTransform.ScaleX = scale;
            ScaleTransform.ScaleY = scale;
        }

        private void ToEventPage(object sender, RoutedEventArgs e)
        {
            YourEvents page = new YourEvents();
            NavigationService.Navigate(page);
        }

        private void AddNewSeller(object sender, RoutedEventArgs e)
        {
            AddNewSeller page = new AddNewSeller(checkedEvent);
            NavigationService.Navigate(page);
        }
        
        private void AddSeller(object sender, RoutedEventArgs e)
        {
            AddSeller page = new AddSeller(checkedEvent, checkedSeller);
            NavigationService.Navigate(page);
        }

        private void Over(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (checkedGrid != grid)
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FFFFC7BB");
                grid.Background = new SolidColorBrush(color);
            }
        }

        private void Out(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (checkedGrid != grid)
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                grid.Background = new SolidColorBrush(color);
            }
        }
    }
}
