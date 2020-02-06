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
            PurchaseMenu pm = new PurchaseMenu(vm);
            pm.Display();
            pm.GetUserInput();
        }
    }
}
