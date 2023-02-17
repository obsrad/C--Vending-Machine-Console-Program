using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingmachine
{
    public class ProductMenu : Menu
    {

        public ProductMenu(string name) : base(name)
        {
        }

        public override void Display()
        {
            Console.WriteLine("1. Buy and Use Product.");
            Console.WriteLine("2. Back to Main Menu.");
            Console.WriteLine("");
        }


    }
}