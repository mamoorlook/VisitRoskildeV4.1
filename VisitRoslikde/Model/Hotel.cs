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
        public class Hotel : INotifyPropertyChanged
    {
        private string _name;
        private string _address;
        private string _telephoneNumber;
        private string _category;
        private string _imageUrl;
        private string _xml;
        private string _comment;

        public Hotel(string name, string address, string telephoneNumber, string category, string imageUrl, string XML)
        {
            _address = address;
            _name = name;
            _telephoneNumber = telephoneNumber;
            _category = category;
            _imageUrl = imageUrl;
            _xml = XML;
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

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }
        public string XML
        {
            get { return _xml; }
            set { _xml = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", _name );
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
