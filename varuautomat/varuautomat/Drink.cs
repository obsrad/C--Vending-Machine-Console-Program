using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vendingmachine
{

    public class Drink : Product, iProduct
    {
        public Drink(string Name, string Desc, int Price, int Id) : base(Name, Desc, Price, Id)
        {
        }

        public override void Description()
        {
            Console.WriteLine("|=============================================================|");
            Console.WriteLine("Product\t\t Description\t\t\t\t Price");
            Console.WriteLine("");
            Console.WriteLine($"{this.Name}\t {this.Desc}\t {this.Price} Kr");
            Console.WriteLine("|=============================================================|");
            Console.WriteLine("");
        }

        public override void Use()
        {
            Console.WriteLine($"You drank: {this.Name}. Refreshing! ");
            Console.WriteLine("|=============================================================|");
            Console.WriteLine("");
        }

        public override void Buy()
        {
            Console.WriteLine("");
            Console.WriteLine("|=============================================================|");
            Console.WriteLine($"You bought: {this.Name}, for {this.Price} Kr");
            Console.WriteLine("|=============================================================|");
        }
    }
}