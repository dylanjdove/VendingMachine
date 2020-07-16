using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    // readme doesn't mention tracking current till amount, but we could expand it to do that here.
    public class MoneyTill
    {
        public decimal Purchase(IVendable product, decimal moneyIn)
        {
            return moneyIn - product.Price;
        }
    }
}
