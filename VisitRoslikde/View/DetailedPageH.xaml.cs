using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Bing.Maps;
using VisitRoslikde.Common;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.Devices.Geolocation;
using System.Threading;
using System.Threading.Tasks;
using Bing.Maps;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using VisitRoslikde.Model;
using VisitRoslikde.ViewModel;

namespace VisitRoslikde.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DetailedPageH : Page
    {
        // member variables to add
        private Geolocator _geolocator = null;
        private CancellationTokenSource _cts = null;
        
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }
        

        public DetailedPageH()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
          
        }

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {

        }
        

        
        private async void pushpinTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailedMap), null);
        }

        private void hotelsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPageHotels), null);
        }

        private void restaurantsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPageRestaurants), null);
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var latitudeSmall = Convert.ToDouble(ListHotelViewModel.ActualHotel.Latitude);
            var longitudeSmall = Convert.ToDouble(ListHotelViewModel.ActualHotel.Longitude);

            navigationHelper.OnNavigatedTo(e);
            mapSmall.SetView(new Location(latitudeSmall, longitudeSmall));
        }

        #endregion

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ListPageHotels), null);
        }
    }
}