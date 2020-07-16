using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chip : IVendable
    {
        public string Name { get; }

        public decimal Price { get; }

        public string SlotNumber { get; }

        public Chip(string name, decimal price, string slotNumber )
        {
            Name = name;
            Price = price;
            SlotNumber = slotNumber;
        }

        public string GetPurchaseMessage()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
