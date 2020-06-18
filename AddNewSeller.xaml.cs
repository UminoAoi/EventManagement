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
    /// Interaction logic for AddNewSeller.xaml
    /// </summary>
    public partial class AddNewSeller : Page
    {
        Event checkedEvent = null;

        public AddNewSeller(Event checkedEvent)
        {
            InitializeComponent();
            this.checkedEvent = checkedEvent;
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
            UserPage page = new UserPage();
            NavigationService.Navigate(page);
        }

        private void AddSeller(object sender, RoutedEventArgs e)
        {
            Cursor previousCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                AddNewSellerToDb();
                YourSellers page = new YourSellers(checkedEvent);
                NavigationService.Navigate(page);
            }
            catch { }
            Mouse.OverrideCursor = previousCursor;
        }

        public void AddNewSellerToDb()
        {
            bool isOk = true;

            NameError.Visibility = Visibility.Hidden;
            SizeError.Visibility = Visibility.Hidden;
            TypeError.Visibility = Visibility.Hidden;
            ContactError.Visibility = Visibility.Hidden;

            if(NameTextBox.Text == "" || NameTextBox.Text.Length<3 || NameTextBox.Text.Length > 20)
            {
                NameError.Text = "Nazwa powinna zawierać min. 3 znaki i maksymalnie 20 znaków.";
                NameError.Visibility = Visibility.Visible;
                isOk = false;
            }

            float parse = 0;

            try
            {
                parse = float.Parse(SizeTextBox.Text);
                if (parse <= 0)
                    isOk = false;
            }
            catch
            {
                SizeError.Text = "Rozmiar stoiska musi być nieujemną liczbą.";
                SizeError.Visibility = Visibility.Visible;
                isOk = false;
            }

            if(TypeTextBox.Text == "")
            {
                TypeError.Text = "To pole jest wymagane.";
                TypeError.Visibility = Visibility.Visible;
                isOk = false;
            }

            if (ContactTextBox.Text == "")
            {
                ContactError.Text = "To pole jest wymagane.";
                ContactError.Visibility = Visibility.Visible;
                isOk = false;
            }

            if (!isOk)
                throw new Exception();

            try
            {
                WystawcaOperations.AddNewWystawca(new Wystawca
                {
                    NazwaFirmy = NameTextBox.Text,
                    RozmiarStoiska = parse,
                    RodzajStoiska = TypeTextBox.Text,
                    DaneKontaktowe = ContactTextBox.Text
                });
            }
            catch(Exception ex)
            {
                ErrorText.Text = ex.Message;
                ErrorText.Visibility = Visibility.Visible;
                throw new Exception();
            }

        }
    }
}
