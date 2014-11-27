using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using VisitRoslikde.View;

namespace VisitRoslikde
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void pushpinTapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Hello from Roskilde.");
            await dialog.ShowAsync();
        }
        
        private void hotelsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPageHotels), null);
        }

        private void restaurantsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPageRestaurants), null);
        }
    }
}
