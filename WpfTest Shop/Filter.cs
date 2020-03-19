using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WpfTest_Shop
{
    public class Filter
    {
        public static List<Shop> FilterByCity(string city)
        {
            using (var context = new ShopContext())
            {
                var getCity = (from c in context.City
                              where c.Name == city
                              select c).FirstOrDefault();

                var shopList = (from s in context.Shops
                               join c in context.City
                               on s.City.CityId equals c.CityId
                               where c.CityId == getCity.CityId
                               select s).ToList();

                return shopList;
            }
        }

        public static List<Shop> FilterByCountry(string country)
        {
            using (var context = new ShopContext())
            {
                var getCountry = (from ct in context.Country
                                   where ct.Name == country
                                   select ct).FirstOrDefault();

                var shopList = (from s in context.Shops
                               join c in context.City
                               on s.City.CityId equals c.CityId
                               join co in context.County
                               on c.County.CountyId equals co.CountyId
                               join di in context.District
                               on co.District.DistrictId equals di.DistrictId
                               join cou in context.Country
                               on di.Country.CountryId equals cou.CountryId
                               where cou.CountryId == getCountry.CountryId
                               select s).ToList();

                return shopList;
            }
        }

        public static List<Shop> FilterByDistrict(string district)
        {
           using (var context = new ShopContext())
           {
                var getDistrict = (from d in context.District
                               where d.Name == district
                               select d).FirstOrDefault();

                var shopList = (from s in context.Shops
                               join c in context.City
                               on s.City.CityId equals c.CityId
                               join co in context.County
                               on c.County.CountyId equals co.CountyId
                               join di in context.District
                               on co.District.DistrictId equals di.DistrictId
                               where di.DistrictId == getDistrict.DistrictId
                               select s).ToList();
                return shopList;
           }
        }

        public static List<Shop> FilterByCounty(string county)
        {
            using (var context = new ShopContext())
            {
                var getCounty = (from co in context.County
                               where co.Name == county
                               select co).FirstOrDefault();

                var shopList = (from s in context.Shops
                                join c in context.City
                                on s.City.CityId equals c.CityId
                                join co in context.County
                                on c.County.CountyId equals co.CountyId
                                where co.CountyId == getCounty.CountyId
                                select s).ToList();

                return shopList;
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