using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        private Dictionary<string, string> saleMessage = new Dictionary<string, string>()
        {
            { "Chip", "Crunch Crunch, Yum!" },
            { "Candy", "Munch Munch, Yum!" },
            { "Drink", "Glug Glug, Yum!" },
            { "Gum", "Chew Chew, Yum!" },
        };

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

        public decimal PurchaseItem(string slot, decimal balance)
        {
            if (!items.ContainsKey(slot))
            {
                Console.WriteLine("The slot you entered does not exist, returning to purchase menu");
                return 0M;
            }

            if (items[slot].Quantity == 0)
            {
                Console.WriteLine("Sorry but that item is sold out, returning to purchase menu");
                return 0M;
            }
            
            Item currentItem = items[slot];
            if (currentItem.Price > balance)
            {
                Console.WriteLine("Sorry but you do not have enough funds please add more and try again!");
                return 0M;
            }
            else
            {
                Console.WriteLine($"You succesfully purchased {currentItem.Name}!");
                Console.WriteLine();
                Console.WriteLine(saleMessage[currentItem.Type]);
                Console.WriteLine($"{currentItem.Price} has been deducted from your balance!");
                AuditLog(currentItem.Type, balance, balance - currentItem.Price);
                currentItem.Quantity--;
                return currentItem.Price;
            }

 
        }

        public void AuditLog(string transactionType, decimal previousBalance, decimal newBalance)
        {
            const string PATH = "C:\\Users\\Student\\git\\c-module-1-capstone-team-5\\19_Capstone\\Log.txt";
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
            using (StreamWriter sw = new StreamWriter(PATH, append: true))
            {
                sw.WriteLine($"DATEPLACEHOLDER {transactionType} {previousBalance} {newBalance}");
            }
        }
    }
}
