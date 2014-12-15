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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using VisitRoslikde.View;

namespace VisitRoslikde
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer timer;
        private double i;

        public MainPage()
        {
            this.InitializeComponent();
            SlideImages.Begin();
            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            Init();
            timer.Start();
        }
        void timer_Tick(object sender, object e)
        {
            SlideImages_Copy1.Begin();
        }

        public void Init()
        {
            i = 27.5;
            timer.Interval = TimeSpan.FromSeconds(i);
        }
        private void hotelsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPageHotels), null);
        }

        private void restaurantsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPageRestaurants), null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuAppBar.IsOpen = true;
        }
    }
}
