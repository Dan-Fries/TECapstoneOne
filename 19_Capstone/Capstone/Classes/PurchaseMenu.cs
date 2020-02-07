using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu
    {
        #region Properties
        //Private property to store a read-only reference to a vending machine object
        private VendingMachine vm { get; }
        #endregion

        #region Constructors
        //Constructor that requires a reference to a vending machine object this is the only constructor that should be used
        public PurchaseMenu(VendingMachine vm)
        {
            this.vm = vm;
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
            Console.WriteLine($"Current Money Provided: {vm.CurrentBalance}");
            GetUserMenuInput();
        }

        //Method to recieve and validate user input and take the appropriate action based on user menu selection
        private void GetUserMenuInput()
        {
            //Prompt the user to make a selection and recieve input from the user
            int selection;
            Console.Write("Enter your selection: ");
            bool isValid = int.TryParse(Console.ReadLine(), out selection);

            //Validate the user input
            while (!isValid || selection < 1 || selection > 3)
            {
                Console.WriteLine("You did not enter a valid choice please enter the number corresponding to your selection");
                isValid = int.TryParse(Console.ReadLine(), out selection);
            }

            //Check which option the user selected and call the appropriate methods
            switch (selection)
            {
                case 1:                     //Call the feed money method and then recall display after the method returns
                    vm.FeedMoney();
                    Display();
                    break;
                case 2:
                    PurchaseItemSubMenu();  //Displat the Purchase Item submenu and then recall display when it returns
                    Display();
                    break;
                case 3:                     //Call the make change method and then create a new menu object and call display when make change returns
                    vm.MakeChange();
                    Menu mn = new Menu(vm);
                    mn.Display();
                    break;
            }
        }

        //Method to display a submenu that allows the user to purchase an item by slot ID
        private void PurchaseItemSubMenu()
        {
            //Clear the console before displaying the purchase submenu
            Console.Clear();
            //Display all items in the vending machine
            vm.DisplayItems();

            //Ask the user to enter a slot number corresponding to the item they want to purchase
            Console.WriteLine();
            Console.Write("Please enter an item to purchase by slot (A1, B3, etc): ");
            string input = Console.ReadLine().ToUpper();            //Add a ToUpper method to user input for case insensitivity 

            //Pass user input to purchase item method which will determine if it is a valid purchase
            vm.PurchaseItem(input);

            //After returning from purchase item wait for the user to press enter before going back to main purchase menu
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
        #endregion
    }
}
