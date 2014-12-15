using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Documents;
using VisitRoslikde.Annotations;
using VisitRoslikde.Model;

namespace VisitRoslikde.ViewModel
{
    public class ListHotelViewModel : INotifyPropertyChanged
    {
        private StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;

        private Hotel _h1;
        private Hotel _h2;
        private Hotel _h3;
        private Hotel _h4;
        private Hotel _h5;
        private string _hotelComment;
        private CommentModelHotel _comment;
        private ICommand _serializeComment;
        private Hotel _h6;

        public static Hotel ActualHotel { get; set; }


        public CommentModelHotel Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }

        public ICommand SerializeComment
        {
            get { return _serializeComment; }
            set { _serializeComment = value; }
        }

        #region properties

        public Hotel h1
        {
            get { return _h1; }
            set { _h1 = value; }
        }

        public Hotel h2
        {
            get { return _h2; }
            set { _h2 = value; }
        }

        public Hotel h3
        {
            get { return _h3; }
            set { _h3 = value; }
        }

        public Hotel h4
        {
            get { return _h4; }
            set { _h4 = value; }
        }

        public Hotel h5
        {
            get { return _h5; }
            set { _h5 = value; }
        }

        public Hotel h6
        {
            get { return _h6; }
            set { _h6 = value; }
        }


        public string hotelComment
        {
            get { return _hotelComment; }
            set { _hotelComment = value; }
        }

        #endregion


        public ListHotelViewModel()
        {
            _h1 = new Hotel("Danhostel Roskilde", "Vindeboder 7, 4000 Roskilde", "+45 4635 2184", "../Assets/Hotels/HotelDanhostel.jpg", "../Assets/Hotels/HotelDanhostelTh.jpg", "../Assets/Hotels/HotelDanhostelDark.jpg", "http://www.danhostel.dk/", "55.649568", "12.077544");
            _h2 = new Hotel("Hotel Prindsen", "Algade 13, Roskilde 4000", "+45 46 30 91 00", "../Assets/Hotels/HotelPrindsen.jpg", "../Assets/Hotels/HotelPrindsenTh.jpg", "../Assets/Hotels/HotelPrindsenDark.jpg", "http://www.hotelprindsen.dk/", "55.64126", "12.083565");
            _h3 = new Hotel("Comwell Roskilde", "Skomagergade 10, Roskilde 4000", "+45 40 44 60 04", "../Assets/Hotels/HotelComwell.jpg", "../Assets/Hotels/HotelComwellTh.jpg", "../Assets/Hotels/HotelComwellDark.jpg", "http://www.comwellroskilde.dk/", "55.665677", "12.09526");
            _h4 = new Hotel("Scandic Roskilde", "Søndre Ringvej 33, 4000 Roskilde", "+45 46 32 46 32", "../Assets/Hotels/HotelScandic.jpg", "../Assets/Hotels/HotelScandicTh.jpg", "../Assets/Hotels/HotelScandicDark.jpg", "http://www.scandichotels.dk/", "55.632028", "12.080136");
            _h5 = new Hotel("Motel Wittrup", "Roskildevej 251, 2620 Albertslund", "+45 4364 9551", "../Assets/Hotels/MotelWittrup.jpg", "../Assets/Hotels/MotelWittrupTh.jpg", "../Assets/Hotels/MotelWittrupDark.jpg", "http://www.wittrupmotel.com.dk/", "55.660267", "12.328546");
            _h6 = new Hotel("Hotel Viby Kro", "Skolevej 1, 4130 Viby", "+45 4619 3021", "../Assets/Hotels/HotelViby.jpg", "../Assets/Hotels/HotelVibyTh.jpg", "../Assets/Hotels/HotelVibyDark.jpg", "http://www.vibykro.dk", "55.549295", "12.024582");

            _comment = new CommentModelHotel();
            //_serializeComment = new RelayCommand(SerializeNewComment);
            _serializeComment = new Common.RelayCommand(SerializeNewComment);

        }

        
        public ObservableCollection<Hotel> ListOfHotels
        {
            get { return HotelSource.GetHotels(); }
        }


        private async void SerializeNewComment()
        {
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                Stream stream =
                    await storageFolder.OpenStreamForWriteAsync("hotel.xml", CreationCollisionOption.ReplaceExisting);

                DataContractSerializer serializer = new DataContractSerializer(typeof (CommentModelHotel));
                serializer.WriteObject(stream, _comment);
            }
            catch (UnauthorizedAccessException)
            {
                MessageDialog dialog = new MessageDialog("Please enter a comment");
                dialog.ShowAsync();
            }
        }

        public void Center()
        {
            var latidtude = Convert.ToDouble(ActualHotel.Latitude);
            var longitude = Convert.ToDouble(ActualHotel.Longitude);


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




