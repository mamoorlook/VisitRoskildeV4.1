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
                Name = "Motel Wittrup",
                Address = "Roskildevej 251, 2620 Albertslund",
                TelephoneNumber = "+45 4364 9551",
                Link = "http://www.wittrupmotel.dk",
                ImageUrl = "ms-appx:///Assets/Hotels/MotelWittrup.jpg",
                Thumb = "ms-appx:///Assets/Hotels/MotelWittrupTh.jpg",
                ThumbDark = "ms-appx:///Assets/Hotels/MotelWittrupDark.jpg",
                Latitude = "55.660267",
                Longitude = "12.328546"
            };
            tempH.Add(hotel);

            Hotel hotel1 = new Hotel
            {
                Name = "Hotel Prindsen",
                Address = "Algade 13, Roskilde 4000, Denmark",
                TelephoneNumber = "+45 4630 9100",
                Link = "http://www.hotelprindsen.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelPrindsen.jpg",
                Thumb = "ms-appx:///Assets/Hotels/HotelPrindsenTh.jpg",
                ThumbDark = "ms-appx:///Assets/Hotels/HotelPrindsenDark.jpg",
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
                Thumb = "ms-appx:///Assets/Hotels/HotelDanhostelTh.jpg",
                ThumbDark = "ms-appx:///Assets/Hotels/HotelDanhostelDark.jpg",
                Latitude = "55.658274",
                Longitude = "12.105931"

            };
            tempH.Add(hotel2);

            Hotel hotel3 = new Hotel
            {
                Name = "Hotel Scandic",
                Address = "Søndre Ringvej 33, 4000 Roskilde",
                TelephoneNumber = "+45 4632 4632",
                Link = "http://www.scandichotels.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelScandic.jpg",
                Thumb = "ms-appx:///Assets/Hotels/HotelScandicTh.jpg",
                ThumbDark = "ms-appx:///Assets/Hotels/HotelScandicDark.jpg",
                Latitude = "55.632028",
                Longitude = "12.080136"

            };
            tempH.Add(hotel3);

            Hotel hotel4 = new Hotel
            {
                Name = "Comwell Roskilde",
                Address = "Vestre Kirkevej 12, 4000 Roskilde",
                TelephoneNumber = "+45 4632 3131",
                Link = "http://www.comwellroskilde.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelComwell.jpg",
                Thumb = "ms-appx:///Assets/Hotels/HotelComwellTh.jpg",
                ThumbDark = "ms-appx:///Assets/Hotels/HotelComwellDark.jpg",
                Latitude = "55.665677",
                Longitude = "12.09526"
            };
            tempH.Add(hotel4);

            Hotel hotel5 = new Hotel
            {
                Name = "Hotel Viby",
                Address = "Skolevej 1, 4130 Viby",
                TelephoneNumber = "+45 4619 3021",
                Link = "http://http://www.vibykro.dk/",
                ImageUrl = "ms-appx:///Assets/Hotels/HotelViby.jpg",
                Thumb = "ms-appx:///Assets/Hotels/HotelVibyTh.jpg",
                ThumbDark = "ms-appx:///Assets/Hotels/HotelVibyDark.jpg",
                Latitude = "55.549295",
                Longitude = "12.024582"
            };
            tempH.Add(hotel5);


            return tempH;
        }
    }
    
}
