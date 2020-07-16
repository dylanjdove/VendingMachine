using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Panel
    {
        private int GetOptionSelection()
        {
            int userInput = 0;
            bool canParse = false;
            while (!canParse)
            {
                canParse = int.TryParse(Console.ReadKey().KeyChar.ToString(), out userInput);
            }
            return userInput;
        }

        public int GetMainMenuOptionSelection()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            return GetOptionSelection();
        }

        public void DisplayVendingItems(List<Tuple<IVendable, int>> items)
        {
            foreach (Tuple <IVendable, int> item in items)
            {                
                string quantity = item.Item2.ToString();
                if (item.Item2 == 0)
                {
                    quantity = "SOLD OUT";
                }
                Console.WriteLine($"{item.Item1.SlotNumber} {item.Item1.Name} Cost: {item.Item1.Price} Quantity Remaining: {quantity}");
            }
            Console.WriteLine("\n");
        }

        public int GetPurchaseOptionSelection()
        {
            Console.WriteLine("\n");
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("\n");
            return GetOptionSelection();
        }

        public int FeedMoney()
        {
            Console.WriteLine("Please input the amount you would like to feed.");
            int userInput = 0;
            bool canParse = false;
            while (!canParse)
            {
                canParse = int.TryParse(Console.ReadLine(), out userInput);
            }
            return userInput;
        }

        public string GetPurchaseSelection()
        {
            Console.WriteLine("Please enter the code to purchase an item.");
            string purchaseSelection = Console.ReadLine();
            return purchaseSelection.ToUpper();
        }

        public void DisplayPurchaseMessage(IVendable vendable, decimal amountRemaining)
        {
            Console.WriteLine($"Item: {vendable.Name} Cost: {vendable.Price} Money Remaining: {amountRemaining}");
            vendable.GetPurchaseMessage();
        }

        public void DisplayError(string errorText)
        {
            Console.WriteLine($"{errorText}");
        }
    }
}
