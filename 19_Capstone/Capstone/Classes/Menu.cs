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

        VendingMachine vendingMachine = new VendingMachine();

        PurchaseMenu purchaseMenu = new PurchaseMenu();

        Dictionary<string, Item> MenuList = new Dictionary<string, Item>()
        {
            
        };





        

        public Menu (Dictionary<string, Item> menuList)
        {
            MenuList = menuList;
        }

        public void Display ()
        {
            //Display menu options
            Console.WriteLine("@" +
                "Please choose from the following options:" +
                "\t 1. Display Vending Machine Items" +
                "\t 2. Purchase Menu" +
                "\t 3. Exit");
            string input = Console.ReadLine();
            int selection = int.Parse(input);

            // Based on user input, determine outcome.
            if (selection == 1)
            {
                vendingMachine.DisplayItems();
            }
            else if (selection == 2)
            {
                purchaseMenu.DisplayItems();
            }
            else if (selection == 3)
            {
                return;
            } 
            else
            {
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
