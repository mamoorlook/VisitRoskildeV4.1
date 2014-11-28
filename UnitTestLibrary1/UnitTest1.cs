using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using VisitRoslikde.Model;
using VisitRoslikde.ViewModel;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListHotelViewModel()
        {
            //private string _name;
            //private string _address;
            //private string _telephoneNumber;
            //private string _category;
            //private string _imageUrl;
            //private string _comment;
            //private string _link;
            //private string _latitude;
            //private string _longitude;
            var a = new ListHotelViewModel();
            a.hotelComment = "XMLFile1.xml";
            a.Comment = new CommentModelHotel();
            a.h1 = new Hotel("TestHotel_b", "TestAdress1, DK", "545643453", "comments", "RestGusto.jpg", "www.test.dk", "255", "255");
            a.h2 = new Hotel("TestHotel_C", "TestAdress2, UK", "555165165", "comments", "RestGusto.jpg", "www.test.dk", "250", "25");
            a.h3 = new Hotel("Scandic Roskilde", "Søndre Ringvej 33, 4000 Roskilde, Denmark", "+45 46 32 46 32", "4 Stars", "../Assets/Hotels/HotelScandic.jpg", "http://www.scandichotels.dk/", "", "");

            //Assert.IsTrue(NIGGERCOCK);
            Assert.IsTrue(a.h1.Address == "TestAdress1, DK");
            Assert.IsTrue(a.h2.Comment == a.h1.Comment);
            Assert.IsTrue(a.h1.ImageUrl == a.h2.ImageUrl);
            Assert.IsTrue(a.h1.Latitude == a.h1.Longitude);
            Assert.IsTrue(a.h2.Name == "TestHotel_C");

            //Assert.IsTrue(a.);
        }

        [TestMethod]
        public void TestHotelModel()
        {
            var b = new Hotel("TestHotel_b", "TestAdress1, DK", "545643453", "comments", "RestGusto.jpg", "www.test.dk", "255", "255");
            var c = new Hotel("TestHotel_C", "TestAdress2, UK", "555165165", "comments", "RestGusto.jpg", "www.test.dk", "250", "25");
            Assert.IsTrue(b.Name.GetType() == c.Name.GetType());
            //Assert.IsTrue(b.Comment == "comments");
            Assert.IsFalse(c.Address == b.Address);
        }

    }
}
