using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class County
    {
        public Guid CountyId { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        public District District { get; set; }
    }
}