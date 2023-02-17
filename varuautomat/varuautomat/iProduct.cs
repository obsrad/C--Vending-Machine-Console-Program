using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vendingmachine
{
    public interface iProduct
    {
        void Description();
        void Buy();
        void Use();
    }
}