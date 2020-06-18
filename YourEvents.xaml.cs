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
    public partial class YourEvents : Page
    {
        Event checkedEvent = null;
        Grid checkedGrid = null;

        public YourEvents()
        {
            InitializeComponent();
            List<Event> eventyOrganizator = UzytkownikOperations.GetLoggedOrganizatorEvents();

            YourEventsGrid.Children.Clear();
            AddEventToList(eventyOrganizator, Rola.Organizator);

            if (eventyOrganizator.Count == 0)
            {
                ErrorText.Text = "Nie posiadasz żadnych zaplanowanych eventów.";
                ErrorText.Visibility = Visibility.Visible;
            }
        }

        private void AddEventToList(List<Event> eventList, Rola rola)
        {
            int count = 0;
            foreach (Event e in eventList)
            {
                RowDefinition newRow = new RowDefinition();
                newRow.Height = new GridLength(100);
                YourEventsGrid.RowDefinitions.Add(newRow);

                Grid eventGrid = new Grid();
                eventGrid.Effect = new DropShadowEffect
                {
                    Color = new Color { A = 0, R = 0, G = 0, B = 0 },
                    Direction = 330,
                    ShadowDepth = 2,
                    Opacity = 0.5,
                    BlurRadius = 4
                };
                eventGrid.Margin = new Thickness(10);
                Color color = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                eventGrid.Background = new SolidColorBrush(color);
                eventGrid.MouseDown += CheckEvent;
                eventGrid.MouseEnter += OverEvent;
                eventGrid.MouseLeave += OutEvent;

                RowDefinition newRow2 = new RowDefinition();
                newRow2.Height = new GridLength(1, GridUnitType.Star);
                eventGrid.RowDefinitions.Add(newRow2);
                RowDefinition newRow3 = new RowDefinition();
                newRow3.Height = new GridLength(2, GridUnitType.Star);
                eventGrid.RowDefinitions.Add(newRow3);

                ColumnDefinition newColumn = new ColumnDefinition();
                newColumn.Width = new GridLength(4, GridUnitType.Star);
                eventGrid.ColumnDefinitions.Add(newColumn);
                ColumnDefinition newColumn2 = new ColumnDefinition();
                newColumn2.Width = new GridLength(1, GridUnitType.Star);
                eventGrid.ColumnDefinitions.Add(newColumn2);

                Label valueLabel = new Label();
                valueLabel.Content = e.IdEvent;
                valueLabel.Visibility = Visibility.Hidden;
                eventGrid.Children.Add(valueLabel);

                TextBlock eventName = new TextBlock();
                eventName.Text = e.NazwaEventu;
                eventName.Foreground = new SolidColorBrush(Colors.White);
                eventName.VerticalAlignment = VerticalAlignment.Center;
                eventName.FontSize = 30;
                eventName.Margin = new Thickness(10, 0, 10, 0);
                Grid.SetRow(eventName, 1);
                Grid.SetColumn(eventName, 0);
                eventGrid.Children.Add(eventName);

                TextBlock role = new TextBlock();
                role.Text = rola.ToString();
                role.Foreground = new SolidColorBrush(Colors.White);
                role.VerticalAlignment = VerticalAlignment.Center;
                role.FontSize = 15;
                role.Margin = new Thickness(10, 0, 10, 0);
                Grid.SetRow(role, 0);
                Grid.SetColumn(role, 0);
                eventGrid.Children.Add(role);

                Grid dataGrid = new Grid();
                dataGrid.Margin = new Thickness(10, 0, 10, 0);
                RowDefinition newRow4 = new RowDefinition();
                newRow4.Height = new GridLength(1, GridUnitType.Star);
                dataGrid.RowDefinitions.Add(newRow4);
                RowDefinition newRow5 = new RowDefinition();
                newRow5.Height = new GridLength(1, GridUnitType.Star);
                dataGrid.RowDefinitions.Add(newRow5);
                Grid.SetRowSpan(dataGrid, 2);
                Grid.SetColumn(dataGrid, 1);
                eventGrid.Children.Add(dataGrid);

                TextBlock start = new TextBlock();
                string text = e.DataRozpoczecia.ToString();
                text = text.Remove(text.Length - 9);
                start.Text = text;
                start.Foreground = new SolidColorBrush(Colors.White);
                start.VerticalAlignment = VerticalAlignment.Center;
                start.FontSize = 15;
                start.Margin = new Thickness(10, 0, 10, 0);
                start.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(start, 0);
                dataGrid.Children.Add(start);

                TextBlock end = new TextBlock();
                text = e.DataZakonczenia.ToString();
                text = text.Remove(text.Length - 9);
                end.Text = text;
                end.Foreground = new SolidColorBrush(Colors.White);
                end.VerticalAlignment = VerticalAlignment.Center;
                end.FontSize = 15;
                end.Margin = new Thickness(10, 0, 10, 0);
                end.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(end, 1);
                dataGrid.Children.Add(end);

                Grid.SetRow(eventGrid, count++);
                YourEventsGrid.Children.Add(eventGrid);
            }
        }

        private void CheckEvent(object sender, MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (checkedGrid == grid)
            {
                Color c = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                checkedGrid.Background = new SolidColorBrush(c);
                checkedEvent = null;
                checkedGrid = null;
                NextButton.IsEnabled = false;
            }
            else if (checkedGrid != null)
            {
                Color c = (Color)ColorConverter.ConvertFromString("#FFF58E78");
                checkedGrid.Background = new SolidColorBrush(c);
                checkedEvent = null;
                checkedGrid = null;

                Color color = (Color)ColorConverter.ConvertFromString("#FFFFC7BB");
                grid.Background = new SolidColorBrush(color);
                checkedGrid = grid;
                Label valueLabel = grid.Children.OfType<Label>().FirstOrDefault();
                checkedEvent = EventOperations.GetEventById(int.Parse(valueLabel.Content.ToString()));
                NextButton.IsEnabled = true;
            }
            else if (checkedGrid == null)
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FFFFC7BB");
                grid.Background = new SolidColorBrush(color);
                checkedGrid = grid;
                Label valueLabel = grid.Children.OfType<Label>().FirstOrDefault();
                checkedEvent = EventOperations.GetEventById(int.Parse(valueLabel.Content.ToString()));
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

        private void ToSellerPage(object sender, RoutedEventArgs e)
        {
            Cursor previousCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                YourSellers page = new YourSellers(checkedEvent);
                NavigationService.Navigate(page);
            }
            catch (Exception er)
            {
                ErrorText.Text = er.Message;
                ErrorText.Visibility = Visibility.Visible;
            }
            Mouse.OverrideCursor = previousCursor;
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
            catch (Exception er)
            {
                ErrorText.Text = er.Message;
                ErrorText.Visibility = Visibility.Visible;
            }
            Mouse.OverrideCursor = previousCursor;
        }

        private void OverEvent(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            if (checkedGrid != grid)
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FFFFC7BB");
                grid.Background = new SolidColorBrush(color);
            }
        }

        private void OutEvent(object sender, MouseEventArgs e)
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
