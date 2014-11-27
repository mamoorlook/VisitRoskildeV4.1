using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Popups;
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
        private string _hotelComment;
        private CommentModelHotel _comment;
        private ICommand _serializeComment;

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


        public string hotelComment
        {
            get { return _hotelComment; }
            set { _hotelComment = value; }
        }


        #endregion


        public ListHotelViewModel()
        {
            _h1 = new Hotel("Danhostel Roskilde", "Vindeboder 7, Roskilde 4000, Denmark", "+45 4635 2184", "No Stars!",
                "../Assets/Hotels/HotelDanhostel.jpg", "../Assets/XML/Hotels/HotelPrindesn.xml");
            _h2 = new Hotel("Hotel Prindsen", "Algade 13, Roskilde 4000, Denmark", "+45 46 30 91 00", "4 stars",
                "../Assets/Hotels/HotelPrindsen.jpg", "../Assets/XML/Hotels/HotelPrindesn.xml");
            _h3 = new Hotel("Comwell Roskilde", "Skomagergade 10, Roskilde 4000, Denmark", "+45 40 44 60 04", "3 Stars",
                "../Assets/Hotels/HotelComwell.jpg", "../Assets/XML/Hotels/HotelPrindesn.xml");
            _h4 = new Hotel("Scandic Roskilde", "Søndre Ringvej 33, 4000 Roskilde, Denmark", "+45 46 32 46 32",
                "4 Stars", "../Assets/Hotels/HotelScandic.jpg", "../Assets/XML/Hotels/HotelPrindesn.xml");

            _comment = new CommentModelHotel();
            //_serializeComment = new RelayCommand(SerializeNewComment);
            _serializeComment = new Common.RelayCommand(SerializeNewComment);

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




