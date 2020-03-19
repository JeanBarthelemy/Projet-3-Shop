using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfTest_Shop
{
    public class Shop : INotifyPropertyChanged
    {
        public Guid ShopId {get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public City City { get; set; }
        public string ZipCode { get; set; }
        public ICollection<ShopMagazine> ManyShopMagazines { get; set; }
        public ICollection<PersonShop> ManyPersonShops { get; set; }
        public ICollection<OrderShop> ManyOrderShops { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    

}