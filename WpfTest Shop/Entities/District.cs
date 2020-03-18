using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class District
    {
        public Guid DistrictId { get; set; }

        public string Name { get; set; }

        public ICollection<County> Counties { get; set; }

        public Country Country { get; set; }
    }
}