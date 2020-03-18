using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfTest_Shop
{
    public class DatabaseServices
    {
        public static bool IsPersonExisting(string Name)
        {
            Person existingPerson = GetPersonFromDbWhereName(Name);
            if (existingPerson == null)
            {
                Logger.DisplayErrorMessage("The user is not registered in the Database!");
                return false;
            }
            else
            {
                Logger.DisplayErrorMessage("The user is existing in the Database.");
                return true;
            }
        }

        public static Person GetPersonFromDbWhereName(string Name)
        {
            //requête linq
            using (var context = new ShopContext())
            {
                var personFromDB = (from p in context.Person
                                   where p.Name == Name
                                   select p).ToList().FirstOrDefault();

                return personFromDB;
            }
            
        }

        public static bool IsPasswordCorresponding(string Password, string Name)
        {
            using (var context = new ShopContext())
            {
                var passwordFromDb = (from p in context.Person
                                     where p.Name == Name
                                     select p.Password).ToList().First();
                if (Password == passwordFromDb)
                {
                    return true;
                }
                else 
                {
                    return false; 
                }
            }
        }

    }
}