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
    }
}