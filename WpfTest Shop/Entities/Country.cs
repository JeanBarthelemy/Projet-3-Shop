using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class Country
    {
        public Guid CountryId { get; set; }

        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}