using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        #region Properties
        //Dictionary to store vending machine items slot number is the key with an Item object stored as the value
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        //Dictionary to store messages for each type of item to be displayed when an item is purchased. Key is the item type and value is the message
        private Dictionary<string, string> saleMessage = new Dictionary<string, string>()
        {
            { "Chip", "Crunch Crunch, Yum!" },
            { "Candy", "Munch Munch, Yum!" },
            { "Drink", "Glug Glug, Yum!" },
            { "Gum", "Chew Chew, Yum!" },
        };

        //Property to store total sales, resets to 0 each time the program is started.
        public decimal GetTotalSales { get; set; }
        #endregion

        #region Constructors
        //Default Constructor resets total sales to 0 and calls stock method to restock vending machine
        public VendingMachine()
        {
            GetTotalSales = 0;
            Stock();
        }
        #endregion

        #region Methods
        //Method to stock the vending machine should only be called once by the default constructor when a new vending machine is created
        private void Stock()
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

        //Method to display all items in the vending machine by slot number
        public void DisplayItems()
        {
            foreach (KeyValuePair<string, Item> kvp in items)
            {
                //If the item is sold out change display value to SOLD OUT otherwise display quantity remaining
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

        //Method to purchase an item returns a decimal with the amount charged for the transaction
        public decimal PurchaseItem(string slot, decimal balance)
        {
            //Check if the user entered an invalid slot number return 0 since no transaction takes place
            if (!items.ContainsKey(slot))
            {
                Console.WriteLine("The slot you entered does not exist, returning to purchase menu");
                return 0M;
            }

            //Check if the item selected is sold out, if it is return 0 as no transaction takes place
            if (items[slot].Quantity == 0)
            {
                Console.WriteLine("Sorry but that item is sold out, returning to purchase menu");
                return 0M;
            }

            //Check if the user has enough funds to complete the transaction if not return 0 and display a message otherwise process the transaction and return the purchase price to the caller
            Item currentItem = items[slot];
            if (currentItem.Price > balance)    //Insufficient funds for purchase
            {
                Console.WriteLine("Sorry but you do not have enough funds please add more and try again!");
                return 0M;
            }
            else                                //Successful purchase
            {
                //Display purchase success message
                Console.WriteLine($"You succesfully purchased {currentItem.Name}!");
                Console.WriteLine();

                //Display appropriate message based on type of item purchased
                Console.WriteLine(saleMessage[currentItem.Type]);

                //Inform the user how much has been deducted from their balance
                Console.WriteLine($"{currentItem.Price} has been deducted from your balance!");

                //Log the purchase to the audit log
                AuditLog(currentItem.Type, balance, balance - currentItem.Price);

                //Complete the sale by adding the purchase to Total Sales and decrementing the quantity of the item in stock
                GetTotalSales += currentItem.Price;
                currentItem.Quantity--;

                //Return purchase price to caller to update balance
                return currentItem.Price;
            }
        }

        //Method to log new transaction to the audit log
        public void AuditLog(string transactionType, decimal previousBalance, decimal newBalance)
        {
            const string PATH = "C:\\Users\\Student\\git\\c-module-1-capstone-team-5\\19_Capstone\\Log.txt";

            using (StreamWriter sw = new StreamWriter(PATH, append: true))
            {
                sw.WriteLine($"{DateTime.Now} {transactionType} {previousBalance:c} {newBalance:c}");
            }
        }

        //Method to print the sales report for the current session
        public void PrintSalesReport()
        {
            string timeStamp = string.Format(("{0:yyyy-MM-dd_hh-mm-ss}"), DateTime.Now);
            string path = ($"C:\\Users\\Student\\git\\c-module-1-capstone-team-5\\19_Capstone\\SalesReports\\{timeStamp}.txt");

            using (StreamWriter report = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, Item> item in items)
                {
                    report.WriteLine($"{item.Value.Name} | {5 - item.Value.Quantity}");
                }

                report.WriteLine($"Total Sales: ${GetTotalSales}");
            }
        }
        #endregion
    }
}
