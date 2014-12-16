using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.Data.Xml.Dom;
using Windows.Devices.Enumeration;
using Windows.UI.Popups;
using VisitRoslikde.Annotations;
using VisitRoslikde.Model;


namespace VisitRoslikde.ViewModel
{
    class WeatherViewModel : INotifyPropertyChanged
    {
        //private static string AppID = "cd9fda274c6d97c9ab3d5daa32609b4d";
        private WeatherModel _weather;
    
        private ICommand _setCityCommand;

        public WeatherViewModel()
        {
            _weather = new WeatherModel();
            _setCityCommand = new WeatherRelayCommand(SetCityCommand) {IsEnabled = true};
            loadXML();
        }

        public async void loadXML()
        {
            try
            {
                Uri weatherUrl = new Uri("http://api.openweathermap.org/data/2.5/weather?id=2614481&mode=xml&units=metric&APPID=219217a064068cd442f00ee0f8c52ae4");

                XmlDocument doc = await XmlDocument.LoadFromUriAsync(weatherUrl);

                _weather.City = doc.GetElementsByTagName("city")[0].Attributes[1].NodeValue.ToString();
                _weather.Temperature = doc.GetElementsByTagName("temperature")[0].Attributes[0].NodeValue.ToString();
                _weather.Cloudiness = doc.GetElementsByTagName("clouds")[0].Attributes[1].NodeValue.ToString();
                int dotIndex = _weather.Temperature.IndexOf(".");

                _weather.Temperature = _weather.Temperature.Remove(dotIndex);

                OnPropertyChanged("Weather");
            }
            catch (Exception)
            {
                new MessageDialog("Can't show weather.").ShowAsync();
            }
        }



        public ICommand SetCity
        {
            get { return _setCityCommand; }
        }

        public WeatherModel Weather
        {
            get { return _weather; }
        }
        
        private void SetCityCommand()
        {
            //set city stuff
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}