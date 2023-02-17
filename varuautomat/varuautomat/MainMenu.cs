using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingmachine
{
    public class MainMenu : Menu
    {
        public MainMenu(string name) : base(name)
        {
        }

        public override void Display()
        {
            //remove later?
            Console.WriteLine("Menu options ");
            Console.WriteLine("");
            Console.WriteLine("1. Product selection menu");
            Console.WriteLine("2. Money menu");
            Console.WriteLine("3. Exit ");
            Console.WriteLine("");
        }
    }
}

