using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Documents;

namespace VisitRoslikde.Model
{
    public class HotelSource    
    {
        public static ObservableCollection<Hotel> GetHotels()
        {
            var tempH = new ObservableCollection<Hotel>();

            Hotel hotel = new Hotel 
            {
                Name = "Danhostel Roskilde",
                Address = "Vindeboder 7, 4000 Roskilde",
                TelephoneNumber = "+45 4635 2184",
                Link = "http://www.danhostel.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelDanhostel.jpg",
                Latitude = "55.658274",
                Longitude = "12.105931"
            };
            tempH.Add(hotel);

            Hotel hotel1 = new Hotel
            {
                Name = "Hotel Prindsen",
                Address = "Algade 13, Roskilde 4000, Denmark",
                TelephoneNumber = "+45 4630 9100",
                Link = "http://www.hotelprindsen.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelPrindsen.jpg",
                Latitude = "55.658274",
                Longitude = "12.105931"
            };
            tempH.Add(hotel1);

            Hotel hotel2 = new Hotel
            {
                Name = "Danhostel Roskilde",
                Address = "Vindeboder 7, 4000 Roskilde",
                TelephoneNumber = "+45 4635 2184",
                Link = "http://www.danhostel.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelDanhostel.jpg",
                Latitude = "55.658274",
                Longitude = "12.105931"

            };
            tempH.Add(hotel2);

            Hotel hotel3 = new Hotel
            {
                Name = "Danhostel Roskilde",
                Address = "Vindeboder 7, 4000 Roskilde",
                TelephoneNumber = "+45 4635 2184",
                Link = "http://www.danhostel.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelDanhostel.jpg",
                Latitude = "55.658274",
                Longitude = "12.105931"

            };
            tempH.Add(hotel3);
            
            return tempH;
        }
    }
    
}
