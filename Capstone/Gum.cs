using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : IVendable
    {
        public string Name { get; }

        public decimal Price { get; }

        public string SlotNumber { get; }

        public Gum(string name, decimal price, string slotNumber )
        {
            Name = name;
            Price = price;
            SlotNumber = slotNumber;
        }

        public string GetPurchaseMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
