using Capstone.Classes;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();
            vm.Stock();
            Menu mainMenu = new Menu(vm);
            mainMenu.Display();
        }
    }
}
