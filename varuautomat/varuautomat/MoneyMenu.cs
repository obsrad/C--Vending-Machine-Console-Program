using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingmachine
{
    public class MoneyMenu : Menu
    {
        public MoneyMenu(string name) : base(name)
        {
        }

        public override void Display()
        {
            Console.WriteLine("1. Enter money into wallet.");
            Console.WriteLine("2. Back to Main Menu.");
            Console.WriteLine("");
        }
    }
}
