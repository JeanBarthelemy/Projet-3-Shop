using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class Magazine
    {
        public Guid MagazineId { get; set; }
        public String Name { get; set; }
        public Editor Editor { get; set; }
        public ICollection<ShopMagazine> ManyShopMagazines { get; set; }
        public ICollection<MagazineOrder> ManyMagazineOrders { get; set; }
        public int PeriodicityDays { get; set; }
    }
}