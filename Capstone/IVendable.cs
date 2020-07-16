using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public interface IVendable
    {
        string Name { get; }
        decimal Price { get; }
        string SlotNumber { get; }

        string GetPurchaseMessage();
    }
}
