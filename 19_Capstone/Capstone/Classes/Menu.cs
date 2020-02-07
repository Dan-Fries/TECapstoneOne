using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Menu
    {
        #region Properties
        public VendingMachine vendingMachine { get; }

        public PurchaseMenu purchaseMenu { get; }
        #endregion

        #region Constructors
        public Menu (VendingMachine vm)
        {
            vendingMachine = vm;
            purchaseMenu = new PurchaseMenu(vm);
        }
        #endregion

        #region Methods
        public void Display ()
        {
            Console.Clear();
            //Display menu options
            Console.Write(
                @"Please choose from the following options:
                    1. Display Vending Machine Items
                    2. Purchase Menu
                    3. Exit
                    ");
            string input = Console.ReadLine();
            int selection = int.Parse(input);

            // Based on user input, determine outcome.
            if (selection == 1)
            {
                // Display Menu Items
                DisplayItems();
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Display();
            }
            else if (selection == 2)
            {
                // Display Purchase Menu
                purchaseMenu.Display();
            }
            else if (selection == 3)
            {
                // Exit Program
                return;
            } 
            else if(selection == 4)
            {
                // Generate a sales report and print it to file.
                vendingMachine.PrintSalesReport();

                //Inform the user that a report was generated and return to main menu
                Console.WriteLine("Sales report generated, check the SalesReport folder to view the report.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Display();
            }
            else
            {
                // Prompt user to add valid selection
                while (!(selection >= 1 || selection <= 4))
                {
                    Console.WriteLine("Please enter valid selection: ");
                    input = Console.ReadLine();
                }               
            }
        }

        public void DisplayItems()
        {
            Dictionary<string, Item> items = vendingMachine.items;

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
        #endregion
    }
}
