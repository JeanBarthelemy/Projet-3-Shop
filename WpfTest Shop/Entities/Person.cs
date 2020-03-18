using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<PersonShop> ManyPersonShops { get; set; }

        public Person(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public Person()
        { }
    }
}