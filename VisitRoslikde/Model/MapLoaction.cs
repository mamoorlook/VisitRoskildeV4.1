using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using VisitRoslikde.Annotations;

namespace VisitRoslikde
{
    class MapLoaction : INotifyPropertyChanged
    {
        private Geocoordinate _location;
        private string _name;

        public Geocoordinate Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
