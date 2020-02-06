using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu
    {
        public decimal CurrentBalance { get; set; }
        
        

        private VendingMachine VM { get; set; }
        public PurchaseMenu(VendingMachine vm)
        {
            VM = vm;
            CurrentBalance = 0;
           
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
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
            Console.Clear();
            Display();
        }

        //private void PurchaseItem(string slot)
        //{
            
        //    Item current = VM.Dispense(slot);
        //    AuditLog(current.Type, CurrentBalance + current.Price, CurrentBalance);
        //}



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

        
    }
}
