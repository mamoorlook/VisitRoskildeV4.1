using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Bing.Maps;
using VisitRoslikde.ViewModel;

namespace VisitRoslikde.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailedMap : Page
    {
        private Geolocator _geolocator = null;
        private CancellationTokenSource _cts = null;
        Location10 _locationIcon10m;
        Pushpin _pushpin = new Pushpin();

        public DetailedMap()
        {
            this.InitializeComponent();
            _geolocator = new Geolocator();
            _locationIcon10m = new Location10();
            _pushpin = new Pushpin();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MapLocationButton.IsEnabled = true;
            CancelGetLocationButton.IsEnabled = false;

        }

        async private void MapLocationButton_Click(object sender, RoutedEventArgs e)
        {
            MapLocationButton.IsEnabled = false;
            CancelGetLocationButton.IsEnabled = true;
            pushpin_1.IsEnabled = true;
            
            // If neccesary, you could remove all the previous pushpins using this code

            //if (Map.Children.Count > 0)
            //{
            //    Map.Children.RemoveAt(0);
            //}

            try
            {
                _cts = new CancellationTokenSource();
                CancellationToken token = _cts.Token;

                MessageTextbox.Text = "Waiting for update...";

                Geoposition pos = await _geolocator.GetGeopositionAsync().AsTask(token);

                var myLatitude = pos.Coordinate.Point.Position.Latitude;
                var myLongitude = pos.Coordinate.Point.Position.Longitude;

                var pushpinLatitude = Convert.ToDouble(ListHotelViewModel.ActualHotel.Latitude);
                var pushpinLongitude = Convert.ToDouble(ListHotelViewModel.ActualHotel.Longitude);

                var centerLatitude = pushpinLatitude - ((pushpinLatitude - myLatitude)/2);
                var centerLongitude = pushpinLongitude - ((pushpinLongitude - myLongitude)/2);

                MessageTextbox.Text = "";

                Location myLocation = new Location(myLatitude, myLongitude);
                Location centerLocation = new Location(centerLatitude, centerLongitude);

                double zoomLevel = 12.0f;

                if (pos.Coordinate.Accuracy <= 100)
                {
                    Map.Children.Add(_locationIcon10m);
                    MapLayer.SetPosition(_locationIcon10m, myLocation);
                    zoomLevel = 12.0f;
                }
                Map.SetView(centerLocation, zoomLevel);

                LatitudeTextbox.Text = myLatitude.ToString();
                LongitudeTextbox.Text = myLongitude.ToString();
                AccuracyTextbox.Text = pos.Coordinate.Accuracy.ToString();
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageTextbox.Text = "Location disabled.";
                LatitudeTextbox.Text = "No data";
                LongitudeTextbox.Text = "No data";
                AccuracyTextbox.Text = "No data";
            }
            catch (TaskCanceledException)
            {
                MessageTextbox.Text = "Operation Cancelledd";
            }
            finally
            {
                _cts = null;
            }

            MapLocationButton.IsEnabled = true;
            CancelGetLocationButton.IsEnabled = false;
        }
        private void CancelGetLocationButton_Click(object sender, RoutedEventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }

            MapLocationButton.IsEnabled = true;
            CancelGetLocationButton.IsEnabled = false;
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }

            base.OnNavigatingFrom(e);
        }
    }
}
