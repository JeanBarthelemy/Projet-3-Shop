using NUnit.Framework;
using WpfTest_Shop;
using System.Collections.Generic;

namespace Test_Projet3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFilterByCity()
        {
            List<Shop> shopList = new List<Shop>()
            {
                new Shop { Name = "shop2city2" },
                new Shop {Name = "shop1city2"}
            };
            City newCity = new City();
            newCity.Name = "city2";
            newCity.Shops = shopList;

            List<Shop> shopByCity = Filter.FilterTestCity(newCity);

            Assert.AreEqual(shopList, shopByCity);
        }

        [Test]
        public void TestFilterByCounty()
        {
            List<Shop> shopList = new List<Shop>()
            {
                new Shop { Name = "shop2city2" },
                new Shop {Name = "shop1city2"}
            };
            List<City> newCity = new List<City>()
            {
                new City { Name = "city2", Shops = shopList }
            };

            County newCounty = new County();
            newCounty.Name = "county1";
            newCounty.Cities = newCity;

            List<Shop> shopByCounty = Filter.FilterTestCounty(newCounty);

            Assert.AreEqual(shopList, shopByCounty);
        }

        [Test]
        public void TestFilterByDistrict()
        {
            List<Shop> shopList = new List<Shop>()
            {
                new Shop { Name = "shop2city2" },
                new Shop {Name = "shop1city2"}
            };
            List<City> newCity = new List<City>()
            {
                new City { Name = "city2", Shops = shopList }
            };

            List<County> newCountyList = new List<County>()
            {
                new County { Name = "county1" , Cities = newCity }
            };

            District newDistrict = new District();
            newDistrict.Name = "district1";
            newDistrict.Counties = newCountyList;
            List<Shop> shopByDistrict = Filter.FilterTestDistrict(newDistrict);
            Assert.AreEqual(shopList, shopByDistrict);
        }


        [Test]
        public void TestFilterByCountry()
        {
            List<Shop> shopList = new List<Shop>()
            {
                new Shop { Name = "shop2city2" },
                new Shop {Name = "shop1city2"}
            };
            List<City> newCity = new List<City>()
            {
                new City { Name = "city2", Shops = shopList }
            };

            List<County> newCountyList = new List<County>()
            {
                new County { Name = "county1" , Cities = newCity }
            };

            List<District> newDistrictList = new List<District>()
            { new District { Name = "district1", Counties = newCountyList }
            };

            Country newCountry = new Country();
            newCountry.Name = "france";
            newCountry.Districts = newDistrictList;
            List<Shop> shopByCountry = Filter.FilterTestCountry(newCountry);
            Assert.AreEqual(shopList, shopByCountry);
        }

        [Test]
        public void TestAuthentification()
        {
            Person currentPerson = new Person("toto", "1234");
            Person testPerson = new Person("toto", "1234");

            Assert.IsTrue(Authentification.AuthentifyTest(currentPerson, testPerson));
        }

    }
}