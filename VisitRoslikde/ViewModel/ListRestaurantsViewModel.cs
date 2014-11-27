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
using VisitRoslikde.Annotations;
using VisitRoslikde.Model;

namespace VisitRoslikde.ViewModel
{
    internal class ListRestaurantsViewModel : INotifyPropertyChanged
    {
        private Restaurant _r1;
        private Restaurant _r2;
        private Restaurant _r3;
        private Restaurant _r4;
        private CommentModelRestaurant _comment;
        private ICommand _serializeComment;
        private string _restaurantComment;

        public static Restaurant ActualRestaurant { get; set; }

        public CommentModelRestaurant Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public ICommand SerializeComment
        {
            get { return _serializeComment; }
            set { _serializeComment = value; }
        }

        #region properties
        public Restaurant r1
        {
            get { return _r1; }
            set { _r1 = value; }
        }

        public Restaurant r2
        {
            get { return _r2; }
            set { _r2 = value; }
        }

        public Restaurant r3
        {
            get { return _r3; }
            set { _r3 = value; }
        }

        public Restaurant r4
        {
            get { return _r4; }
            set { _r4 = value; }
        }

        public string RestaurantComment
        {
            get { return _restaurantComment; }
            set { _restaurantComment = value; }
        }

        #endregion
        public ListRestaurantsViewModel()
        {
            _r1 = new Restaurant("Mumm", "Karen Olsdatter Straede 9, Roskilde 4000, Denmark", "+45 4637-2201", "French, Danish", "Mon - Sat 17:30 - 21:30", "../Assets/Restaurans/MummRoskilde.jpg");
            _r2 = new Restaurant("Skank", "Hestetorvet 10, Roskilde 4000, Denmark", "+45 3214-3204", "Tapas", "Mon - Sun 11:00 - 23:00", "../Assets/Restaurans/SkankRoskilde.jpg");
            _r3 = new Restaurant("Gusto Giusto", "Jernbanegade 19, Roskilde 4000, Denmark", "+45 4632-7377", "Italian", "Mon - Sat 14:00 - 23:00", "../Assets/Restaurans/GustoRoskilde.jpg");
            _r4 = new Restaurant("Vigen", "Baunehojve 5, 4000 Roskilde, Denmark", "+45 6475-5008", "European-Danish", "Sun - Sat 12:00 - 22:00", "../Assets/Restaurans/VigenRoskilde.jpg");
            _comment = new CommentModelRestaurant();
            _serializeComment = new Common.RelayCommand(SerializeNewRComment);
        }

        private async void SerializeNewRComment()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            Stream stream = await storageFolder.OpenStreamForWriteAsync("restaurants.xml", CreationCollisionOption.ReplaceExisting);

            DataContractSerializer serializer = new DataContractSerializer(typeof(CommentModelRestaurant));
            serializer.WriteObject(stream, _comment);
        }
        #region InotifyPropertyChanged
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
