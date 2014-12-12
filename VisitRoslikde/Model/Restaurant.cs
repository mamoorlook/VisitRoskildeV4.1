using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VisitRoslikde.Annotations;

namespace VisitRoslikde.Model
{
    internal class Restaurant : INotifyPropertyChanged
    {
        private string _name;
        private string _address;
        private string _telephoneNumber;
        private string _cuisine;
        private string _imageUrl;
        private string _openingHours;
        private string _latitude;
        private string _longitude;


        public Restaurant(string name, string address, string telephoneNumber, string cuisine, string openingHours, string imageUrl, string latitude, string longitude)
        {
            _name = name;
            _address = address;
            _telephoneNumber = telephoneNumber;
            _openingHours = openingHours;
            _cuisine = cuisine;
            _imageUrl = imageUrl;
            _latitude = latitude;
            _longitude = longitude;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }

        public string Prices { get; set; }

        public string Cuisine
        {
            get { return _cuisine; }
            set { _cuisine = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public string OpeningHours
        {
            get { return _openingHours; }
            set { _openingHours = value; }
        }

        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", _name);
        }

        #region

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
