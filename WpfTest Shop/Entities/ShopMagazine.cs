using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class ShopMagazine
    {
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }
        public Guid MagazineId { get; set; }
        public Magazine Magazine { get; set; }
    }
}