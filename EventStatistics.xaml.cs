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
    /// Interaction logic for EventStatistics.xaml
    /// </summary>
    public partial class EventStatistics : Page
    {
        public EventStatistics(Event evnt)
        {
            InitializeComponent();
            InitializeInformation(evnt);
        }

        private void InitializeInformation(Event evnt)
        {
            NazwaBig.Text = evnt.NazwaEventu;
            Nazwa.Text = evnt.NazwaEventu;
            Tematyka.Text = evnt.Tematyka;
            string text = evnt.DataRozpoczecia.ToString();
            text = text.Remove(text.Length - 9);
            DataStart.Text = text;
            text = evnt.DataRozpoczecia.ToString();
            text = text.Remove(text.Length - 9);
            DataEnd.Text = text;
            Cena.Text = evnt.CenaBiletow.ToString();
            Miejsca.Text = evnt.IloscMiejsc.ToString();

            EventSellersGrid.Children.Clear();
            List<Wystawca> wystawcy = EventOperations.GetWystawcyOfEvent(evnt);
            AddWystawcy(wystawcy);

            EventAtractionsGrid.Children.Clear();
            List<Atrakcja> atrakcje = EventOperations.GetAtrakcjeOfEvent(evnt);
            AddAtrakcje(atrakcje);
        }

        private void AddWystawcy(List<Wystawca> wystawcy)
        {
            int count = 0;
            foreach(Wystawca w in wystawcy)
            {
                RowDefinition newRow = new RowDefinition();
                newRow.Height = new GridLength(80);
                EventSellersGrid.RowDefinitions.Add(newRow);
                
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
                sellerGrid.MouseDown += OnSeller;

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
                EventSellersGrid.Children.Add(sellerGrid);
            }
        }

        private void OnSeller(object sender, MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            Color color = (Color)ColorConverter.ConvertFromString("#FFF58E78");
            grid.Background = new SolidColorBrush(color);
            Label valueLabel = grid.Children.OfType<Label>().FirstOrDefault();

            Cursor previousCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                Wystawca wystawca = WystawcaOperations.GetWystawcaById(int.Parse(valueLabel.Content.ToString()));
                SellerStatistics page = new SellerStatistics(wystawca);
                NavigationService.Navigate(page);
            }
            catch { }
            Mouse.OverrideCursor = previousCursor;
        }

        private void AddAtrakcje(List<Atrakcja> atrakcje)
        {
            int count = 0;
            foreach (Atrakcja a in atrakcje)
            {
                RowDefinition newRow = new RowDefinition();
                newRow.Height = new GridLength(80);
                EventAtractionsGrid.RowDefinitions.Add(newRow);

                Grid atractionGrid = new Grid();
                atractionGrid.Effect = new DropShadowEffect
                {
                    Color = new Color { A = 0, R = 0, G = 0, B = 0 },
                    Direction = 330,
                    ShadowDepth = 2,
                    Opacity = 0.5,
                    BlurRadius = 4
                };

                atractionGrid.Margin = new Thickness(10);
                Color color = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                atractionGrid.Background = new SolidColorBrush(color);
                atractionGrid.MouseEnter += Over;
                atractionGrid.MouseLeave += Out;

                Label valueLabel = new Label();
                valueLabel.Content = a.IdAtrakcja;
                valueLabel.Visibility = Visibility.Hidden;
                atractionGrid.Children.Add(valueLabel);

                TextBlock atractionName = new TextBlock();
                atractionName.Text = a.Nazwa;
                atractionName.Foreground = new SolidColorBrush(Colors.White);
                atractionName.VerticalAlignment = VerticalAlignment.Center;
                atractionName.FontSize = 30;
                atractionName.Margin = new Thickness(10, 0, 10, 0);
                Grid.SetRow(atractionName, 0);
                atractionGrid.Children.Add(atractionName);

                Grid.SetRow(atractionGrid, count++);
                EventAtractionsGrid.Children.Add(atractionGrid);
            }
        }
        private void Over(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            Color color = (Color)ColorConverter.ConvertFromString("#FFFFC7BB");
            grid.Background = new SolidColorBrush(color);
        }

        private void Out(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            Color color = (Color)ColorConverter.ConvertFromString("#FFF58E78");
            grid.Background = new SolidColorBrush(color);
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

        private void ToUserPage(object sender, RoutedEventArgs e)
        {
            Cursor previousCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                UserPage page = new UserPage();
                NavigationService.Navigate(page);
            }
            catch { }
            Mouse.OverrideCursor = previousCursor;
        }

    }
}
