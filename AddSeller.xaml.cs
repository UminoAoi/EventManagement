using ProjektImplementacja.DatabaseOperations;
using ProjektImplementacja.Model;
using System;
using System.Collections.Generic;
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

namespace ProjektImplementacja
{
    /// <summary>
    /// Interaction logic for AddSeller.xaml
    /// </summary>
    public partial class AddSeller : Page
    {
        Event eventForAdding = null;
        Wystawca wystForAdding = null;

        public AddSeller(Event checkedEvent, Wystawca checkedSeller)
        {
            InitializeComponent();
            eventForAdding = checkedEvent;
            wystForAdding = checkedSeller;

            try
            {
                EventOperations.AddWystawcaToEvent(eventForAdding, wystForAdding);
                ResultText.Text = "Dodawanie wystawcy do eventu zakończono pomyślnie.";
                DataText.Text = "Wystawca " + wystForAdding.NazwaFirmy + " został przypisany do eventu " + eventForAdding.NazwaEventu + ".";
                DataText.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ResultText.Foreground = new SolidColorBrush(Colors.Red);
                ResultText.Text = ex.Message;
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
