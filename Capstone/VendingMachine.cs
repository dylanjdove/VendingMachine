using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        private MoneyTill till;
        private Inventory inventory;
        private Logger logger;
        private Panel panel;

        Dictionary<string, int> itemsSold;

        private decimal currentMoneyProvided;

        public VendingMachine()
        {
            inventory = new Inventory();
            till = new MoneyTill();
            logger = new Logger();
            panel = new Panel();

            itemsSold = new Dictionary<string, int>();
        }

        public void Run()
        {
            bool running = true;

            do
            {
                int chosenOption = panel.GetMainMenuOptionSelection();

                if (chosenOption == 1) displayItems();
                else if (chosenOption == 2) handlePurchaseMenu();
                else if (chosenOption == 3) running = false;
                else if (chosenOption == 4) generateSalesReport();
            }
            while (running);
        }

        private void displayItems()
        {
            List<Tuple<IVendable, int>> vendables = inventory.GetVendableList();
            panel.DisplayVendingItems(vendables);
        }

        private void handlePurchaseMenu()
        {
            bool purchasing = true;

            while (purchasing)
            {
                int selection = panel.GetPurchaseOptionSelection();

                switch (selection)
                {
                    case 1:
                        {
                            currentMoneyProvided += (decimal)panel.FeedMoney();
                            break;
                        }
                    case 2:
                        {
                            handlePurchase();
                            break;
                        }
                    case 3:
                        {
                            purchasing = false;
                            break;
                        }
                }
            }
        }

        private void handlePurchase()
        {
            displayItems();
            string chosenSlotNumber = panel.GetPurchaseSelection();

            if (!inventory.InventoryExists(chosenSlotNumber))
            {
                panel.DisplayError("Your chosen product doesn't exist.");
                return;
            }

            if (!inventory.CanSell(chosenSlotNumber))
            {
                panel.DisplayError("That item is sold out!");
                return;
            }

            IVendable chosenProduct = inventory.GetVendable(chosenSlotNumber);

            if (currentMoneyProvided < chosenProduct.Price)
            {
                panel.DisplayError("Please insert more money to buy this product.");
                return;
            }

            // Add money to till.
            currentMoneyProvided = till.Purchase(chosenProduct, currentMoneyProvided);

            // Remove inventory.
            inventory.ReduceInventory(chosenSlotNumber);

            // Output the purchase.
            panel.DisplayPurchaseMessage(chosenProduct, currentMoneyProvided);
        }

        private void generateSalesReport()
        {
            logger.MakeSalesReport(itemsSold);
        }
    }
}
