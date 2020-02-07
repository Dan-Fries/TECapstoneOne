using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu
    {
        #region Properties
        //Property to store the current balance the user has fed into the vending machine
        public decimal CurrentBalance { get; set; }

        //Private property to store a reference to a vending machine object
        private VendingMachine VM { get; set; }
        #endregion

        #region Constructors
        //Constructor that requires a reference to a vending machine object as well as resetting the Balance to 0 this is the only constructor that should be used
        public PurchaseMenu(VendingMachine vm)
        {
            VM = vm;
            CurrentBalance = 0;

        }
        #endregion

        #region Methods
        //Method to display the purchase menu
        public void Display()
        {
            //Clear the console whenever the display method is called
            Console.Clear();

            //Display menu options to the user
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            
            //Display the current balance the 
            Console.WriteLine();
            Console.WriteLine($"Current Money Provided: {CurrentBalance}");
            GetUserMenuInput();
        }

        public void FeedMoney()
        {
            Console.WriteLine("How many dollars do you want to feed?: ");
            decimal dollar;
            bool isValid = decimal.TryParse(Console.ReadLine(), out dollar);
            while (!isValid)
            {
                Console.WriteLine("You did not enter a valid amount please enter a whole dollar amount: ");


            }
            VM.AuditLog("FEED MONEY: ", CurrentBalance, CurrentBalance + dollar);
            CurrentBalance += dollar;
            Display();
        }

        private void GetUserMenuInput()
        {
            int selection;
            Console.Write("Enter your selection: ");
            bool isValid = int.TryParse(Console.ReadLine(), out selection);

            while (!isValid || selection < 1 || selection > 3)
            {
                Console.WriteLine("You did not enter a valid choice please enter the number corresponding to your selection");
                isValid = int.TryParse(Console.ReadLine(), out selection);
            }

            switch (selection)
            {
                case 1:
                    FeedMoney();
                    break;
                case 2:
                    PurchaseItemSubMenu();
                    break;
                case 3:
                    Money money = new Money(VM);
                    money.MakeChange(CurrentBalance);
                    Menu mn = new Menu(VM);
                    mn.Display();
                    break;

            }
        }

        private void PurchaseItemSubMenu()
        {
            Console.Clear();
            VM.DisplayItems();
            Console.WriteLine();
            Console.Write("Please enter an item to purchase by slot (A1, B3, etc): ");
            string input = Console.ReadLine();
            decimal debitAmount = VM.PurchaseItem(input, CurrentBalance);
            CurrentBalance -= debitAmount;
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Display();

        }

        #endregion
    }
}
