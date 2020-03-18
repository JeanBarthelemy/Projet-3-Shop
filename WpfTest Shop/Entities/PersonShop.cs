using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class PersonShop
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid ShopId { get; set; }
        public Shop Shop { get;set; }
    }
}