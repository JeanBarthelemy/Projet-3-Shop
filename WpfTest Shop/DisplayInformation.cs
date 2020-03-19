using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WpfTest_Shop
{
    public class DisplayInformation
    {
        public static List<Shop> DisplayDefaultShop()
        {
            using (var context = new ShopContext())
            {
                var defaultList = (from s in context.Shops
                                  select s).ToList();

                return defaultList;

            }
        }

        public static List<string> GetCity()
        {
            using (var context = new ShopContext())
            {
                var cityList = (from c in context.City
                                   select c.Name).ToList();
                return cityList;
            }
        }

        public static List<string> GetCounty()
        {
            using (var context = new ShopContext())
            {
                var countyList = (from co in context.County
                                select co.Name).ToList();
                return countyList;
            }
        }

        public static List<string> GetDistrict()
        {
            using (var context = new ShopContext())
            {
                var districtList = (from d in context.District
                                select d.Name).ToList();
                return districtList;
            }
        }

        public static List<string> GetCountry()
        {
            using (var context = new ShopContext())
            {
                var countryList = (from ct in context.Country
                                select ct.Name).ToList();
                return countryList;
            }
        }
    }
}