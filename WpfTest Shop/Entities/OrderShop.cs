using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class OrderShop
    {
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}