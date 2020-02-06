using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        public VendingMachine()
        {

        }
        public void Stock()
        {
            const string path = "C:\\Users\\Student\\git\\c-module-1-capstone-team-5\\19_Capstone\\vendingmachine.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    //Parse each line of the vending machine file and split it into an array of strings
                    string[] itemLine = sr.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                    //Create a new item and add it to the item dictionary by accessing the appropriate data item by index in itemLine strings
                    items.Add(itemLine[0], new Item(itemLine[1], decimal.Parse(itemLine[2]), 5, itemLine[3]));
                }
            }
        }

        public void DisplayItems()
        {
            foreach (KeyValuePair<string, Item> kvp in items)
            {
                if (kvp.Value.Quantity == 0)
                {
                    Console.WriteLine($"{kvp.Key}) {kvp.Value.Name} - {kvp.Value.Price} - SOLD OUT");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key}) {kvp.Value.Name} - {kvp.Value.Price} - {kvp.Value.Quantity}");
                }

            }
        }

        public Item Dispense(string slot)
        {
            Item currentItem = items[slot];
            currentItem.Quantity--;
            return currentItem;
        }
    }
}
