using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu
    {
        public decimal CurrentBalance { get; private set; }
        private VendingMachine VM { get; set; }

        Dictionary<int, string> menuOptions = new Dictionary<int, string>()
        {
            { 1, "Feed Money" },
            { 2, "Select Product" },
            { 3, "Finish Transaction" }
        };
        public PurchaseMenu(VendingMachine vm)
        {
            VM = vm;
            CurrentBalance = 0.00M;
        }

        public void Display()
        {
            foreach (KeyValuePair<int, string> kvp in menuOptions)
            {
                Console.WriteLine($"({kvp.Key}) {kvp.Value}");
            }
            Console.WriteLine();
            Console.WriteLine($"Current Money Provided: {CurrentBalance}");
        }


        public void PurchaseItem(string slot)
        {
            Item current = VM.Dispense(slot);
            AuditLog(current.Type, CurrentBalance + current.Price, CurrentBalance);
        }

        public void AuditLog(string transactionType, decimal previousBalance, decimal newBalance)
        {
            const string PATH = "C:\\Users\\Student\\git\\c-module-1-capstone-team-5\\19_Capstone\\Log.txt";
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
            using (StreamWriter sw = new StreamWriter(PATH))
            {
                sw.WriteLine($"DATEPLACEHOLDER {transactionType} {previousBalance} {newBalance}");
            }
        }

        public void GetUserInput()
        {
            int selection;
            bool isValid = int.TryParse(Console.ReadLine(), out selection);

            while (!isValid && selection >=1 && selection <= 3)
            {
                Console.WriteLine("You did not enter a valid choice please enter the number corresponding to your selection");
                isValid = int.TryParse(Console.ReadLine(), out selection);
            }

            switch (selection)
            {
                case 1: 
                    Console.WriteLine("Not Implemented");
                    break;
                case 2:
                    PurchaseItem("A1");
                    VM.DisplayItems();
                    break;
                case 3:
                    Console.WriteLine("Not Implemented");
                    break;
                default:
                    break;

            }


        }

        //public override void Exit()
        //{
        //    base.Exit();
        //}
    }
}
