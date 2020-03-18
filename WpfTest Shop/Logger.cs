using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTest_Shop
{
    public class Logger
    {
        //static ou singleton
        public static void DisplayErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplaySucceedMessage(string message)
        {
            Console.WriteLine(message);
        }

        
    }
}