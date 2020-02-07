using Capstone.Classes;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            string title = @"
                 _______    ______     ___    __                          __                           
                /__  __//  / ____//    | ||  / //________________________  //__(_))___________________ 
                  / //    / __//       | || / // /  _\\  / ___ \\     __  //  / //  / ___ \\  / ___ `//
                 / //    / //___       | ||/ // /  __// / // / // / //_/ //  / //  / // / // / //_/ // 
                /_//    /_____//       |____//  \___// /_// /_//  \___,_//  /_//  /_// /_//  \__,  //  
                                                                                            /_____// ";
            Console.WriteLine(title);


            //Create a new vending machine object which will stock the vending machine
            VendingMachine vm = new VendingMachine();

            //Create a new menu object passing it the vending machine object we created
            Menu mn = new Menu(vm);

            //Call the display method for the menu, all further program control handled by the menu classes
            mn.Display();
        }
    }
}
