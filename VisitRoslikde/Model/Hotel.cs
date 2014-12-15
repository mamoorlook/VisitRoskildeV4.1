using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Documents;
using Bing.Maps;
using VisitRoslikde.Annotations;

namespace VisitRoslikde.Model
{
        public class Hotel : INotifyPropertyChanged
        {
            private string _name;
            private string _address;
            private string _telephoneNumber;
            private string _imageUrl;
            private string _comment;
            private string _link;
            private string _latitude;
            private string _longitude;
            private string _thumb;
            private string _thumbDark;

            public Hotel(string name, string address, string telephoneNumber, string imageUrl, string thumb, string thumbDark, string link, string latitude, string longitude)
            {
                _address = address;
                _name = name;
                _telephoneNumber = telephoneNumber;
                _imageUrl = imageUrl;
                _link = link;
                _latitude = latitude;
                _longitude = longitude;
                _thumb = Thumb;
                _thumbDark = ThumbDark;
            }

            public Hotel()
            {

            }

            public string Thumb
            {
                get { return _thumb; }
                set { _thumb = value; }
            }

            public string ThumbDark
            {
                get { return _thumbDark; }
                set { _thumbDark = value; }
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
            
            

            public string Link
            {
                get { return _link; }
                set { _link = value; }
            }

            public string ImageUrl
            {
                get { return _imageUrl; }
                set { _imageUrl = value; }
            }
            
            public string Comment
            {
                get { return _comment; }
                set { _comment = value; }
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
