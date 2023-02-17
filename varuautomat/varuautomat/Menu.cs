using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingmachine
{
    public abstract class Menu
    {
        public static List<Menu> menus = new List<Menu>();
        public string Name { get; set; }

        public Menu(string name)
        {
            Name = name;

            menus.Add(this);
        }

        public virtual void Display()
        {
            Console.WriteLine("Default Menu Display");
        }
    }
}
