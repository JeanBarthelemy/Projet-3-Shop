using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Windows.Forms;




namespace WpfTest_Shop
{
    public class Authentification
    {
        public static bool Authentify(Person currentPerson)
        {
            using (var context = new ShopContext())
            {
                var getNameAndPassword = from p in context.Person
                                         where currentPerson.Name == p.Name && currentPerson.Password == p.Password
                                         select new { p.Name, p.Password };



                if (getNameAndPassword.Count() == 1)
                {
                    Logger.DisplaySucceedMessage("Authentification succeded");
                    return true;

                }
                else
                {
                    Logger.DisplayErrorMessage("Authentification failed, the password was not corresponding to the user");
                    return false;
                }
            }
        }
    


         public static bool AuthentifyTest(Person currentPerson, Person testPerson)
         {

            if (currentPerson.Name == testPerson.Name)
            {
                if (currentPerson.Password == testPerson.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            
            //on cherche si le nom de la person existe en base de donnée
           
         

         }
    }
}
