using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace vendingmachine
{
    public abstract class Product
    {
        public static List<Product> products = new List<Product>();

        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }

        public Product(string name, string desc, int price, int id)
        {
            this.Name = name;
            this.Desc = desc;
            this.Price = price;
            this.Id = id;

            products.Add(this);
        }

        public virtual void Use()
        {
            Console.WriteLine("Default Use");
        }

        public virtual void Buy()
        {
            Console.WriteLine("Default Buy");
        }

        public virtual void Description()
        {
            Console.WriteLine("Default Description");
        }

    }
}