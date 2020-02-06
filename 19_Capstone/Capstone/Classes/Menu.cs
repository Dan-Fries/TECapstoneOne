using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Menu
    {
        const string path = "C:\\Users\\Student\\git\\c-module-1-capstone-team-5\\19_Capstone\\vendingmachine.csv";

        private VendingMachine vendingMachine { get; }

        private PurchaseMenu purchaseMenu { get; }

        Dictionary<string, Item> MenuList = new Dictionary<string, Item>()
        {
            
        };





        

        public Menu (VendingMachine vm)
        {
            vendingMachine = vm;
        }

        public void Display ()
        {
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
                vendingMachine.DisplayItems();
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
            else
            {
                // Prompt user to add valid selection
                while (!(selection >= 1 || selection <= 3))
                {
                    Console.WriteLine("Please enter valid selection: ");
                    input = Console.ReadLine();
                }
                
            }
        }

        public string Read ()
        {
            return null;
        }

        virtual public void Exit ()
        {
            return;
        }

        public string Reporting()
        {
            throw new NotImplementedException();
        }
    }
}
