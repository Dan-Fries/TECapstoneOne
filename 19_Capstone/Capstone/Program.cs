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
            vm.DisplayItems();
            vm.Dispense("A1");
            vm.Dispense("A1");
            vm.DisplayItems();
        }
    }
}
