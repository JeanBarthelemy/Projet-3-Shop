using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WpfTest_Shop
{
    public class Filter
    {
        public static void FilterByCity(City city)
        {
            using (var context = new ShopContext())
            {
                var shopList = from s in context.Shops.AsEnumerable()
                               join c in context.City
                               on s.City.CityId equals c.CityId
                               where c.CityId == city.CityId
                               select new { cityName = c.Name, s.ShopId,  shopName = s.Name };

                foreach (var Shop in shopList)
                {
                    Console.WriteLine(Shop);
                }
            }
        }

        public static void FilterByCountry(Country country)
        {
            using (var context = new ShopContext())
            {
                var shopList = from s in context.Shops
                               join c in context.City
                               on s.City.CityId equals c.CityId
                               join co in context.County
                               on c.County.CountyId equals co.CountyId
                               join di in context.District
                               on co.District.DistrictId equals di.DistrictId
                               join cou in context.Country
                               on di.Country.CountryId equals cou.CountryId
                               where cou.CountryId == country.CountryId
                               select new { CountryName= cou.Name, DistrictName = di.Name, CountyName = co.Name, c.Name, s.ShopId, shopName = s.Name };

                foreach (var shop in shopList)
                {
                    Console.WriteLine(shop);
                }
            }
        }

        public static void FilterByDistrict(District district)
        {
           using (var context = new ShopContext())
           {
                var shopList = from s in context.Shops
                               join c in context.City
                               on s.City.CityId equals c.CityId
                               join co in context.County
                               on c.County.CountyId equals co.CountyId
                               join di in context.District
                               on co.District.DistrictId equals di.DistrictId
                               where di.DistrictId == district.DistrictId
                               select new { DistrictName = di.Name, CountyName = co.Name, c.Name, s.ShopId, shopName = s.Name };

                foreach(var shop in shopList)
                {
                    Console.WriteLine(shop);
                }
           }
        }

        public static void FilterByCounty(County county)
        {
            using (var context = new ShopContext())
            {
                var shopList = from s in context.Shops
                            join c in context.City
                            on s.City.CityId equals c.CityId
                            join co in context.County
                            on c.County.CountyId equals co.CountyId
                            where co.CountyId == county.CountyId
                            select new { CountyName = co.Name, c.Name, s.ShopId, shopName = s.Name };

                foreach (var Shop in shopList)
                {
                    Console.WriteLine(Shop);
                }
            }
        }

        public static List<Shop> FilterTestCity (City city)
        {
            List<Shop> shopList = new List<Shop>();

            foreach(Shop shop in city.Shops)
            {
                shopList.Add(shop);
            }
            return shopList;

        }

        public static List<Shop> FilterTestCounty(County county)
        {
            List<Shop> shopList = new List<Shop>();

            foreach (City city in county.Cities)
            {
                foreach(Shop shop in city.Shops)
                {
                    shopList.Add(shop);
                }
                
            }
            return shopList;

        }

        public static List<Shop> FilterTestDistrict(District district)
        {
            List<Shop> shopList = new List<Shop>();
            foreach (County county in district.Counties)
            {
                foreach (City city in county.Cities)
                {
                    foreach (Shop shop in city.Shops)
                    {
                        shopList.Add(shop);
                    }

                }
            }
            return shopList;

        }

        public static List<Shop> FilterTestCountry(Country country)
        {
            List<Shop> shopList = new List<Shop>();
            foreach (District district in country.Districts)
            {
                foreach (County county in district.Counties)
                {
                    foreach (City city in county.Cities)
                    {
                        foreach (Shop shop in city.Shops)
                        {
                            shopList.Add(shop);
                        }

                    }
                }
            }
            return shopList;

        }
    }
}