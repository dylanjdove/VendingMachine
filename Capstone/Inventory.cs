using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;

namespace Capstone
{
    class Inventory
    {
        private Dictionary<string, int> currentInventory { get; } = new Dictionary<string, int>();
        private Dictionary<string, IVendable> items { get; } = new Dictionary<string, IVendable>();


        public Inventory()
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "vendingmachine.csv";
            
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(path, fileName)))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split("|");
                        decimal cost = decimal.Parse(words[2]);
                        IVendable newItem = null;
                        currentInventory.Add(words[0], 5);
                        if (words[3] == "Chip")
                        {
                            newItem = new Chip(words[1], cost, words[0]);
                        }
                        if (words[3] == "Candy")
                        {
                            newItem = new Candy(words[1], cost, words[0]);
                        }
                        if (words[3] == "Drink")
                        {
                            newItem = new Drink(words[1], cost, words[0]);
                        }
                        if (words[3] == "Gum")
                        {
                            newItem = new Gum(words[1], cost, words[0]);
                        }
                        items.Add(words[0], newItem);
                    }
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found. Try again.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect format for cost.");
            }
            catch(Exception)
            {
                Console.WriteLine("Could not load inventory.  Try again.");
            }
        }

        public bool CanSell(string slotNumber)
        {
            bool canSell = false;
            if(currentInventory[slotNumber] > 0)
            {
                canSell = true;
            }
            return canSell;
        }

        public int ReduceInventory(string slotNumber)
        {
            currentInventory[slotNumber]--;
            return currentInventory[slotNumber];
        }

        public List<Tuple<IVendable, int>> GetVendableList()
        {
            List<Tuple<IVendable, int>> vendableList = new List<Tuple<IVendable, int>>();
            foreach (KeyValuePair<string, IVendable> item in items)
            {
                Tuple<IVendable, int> newTuple = new Tuple<IVendable, int> (item.Value, currentInventory[item.Key]);
                vendableList.Add(newTuple);
            }
            return vendableList;
        }

        public bool InventoryExists(string slotNumber)
        {
            bool doesExist = false;
            if (currentInventory.ContainsKey(slotNumber))
            {
                doesExist = true;
            }
            return doesExist;
        }

        public IVendable GetVendable(string slotNumber)
        {
            return items[slotNumber];
        }
    }
}
