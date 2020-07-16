using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Drink : IVendable
    {
        public string Name { get; }

        public decimal Price { get; }

        public string SlotNumber { get; }

        public Drink(string name, decimal price, string slotNumber )
        {
            Name = name;
            Price = price;
            SlotNumber = slotNumber;
        }

        public string GetPurchaseMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
