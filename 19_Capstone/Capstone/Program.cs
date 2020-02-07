using Capstone.Classes;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();
            Menu mn = new Menu(vm);
            mn.Display();
        }
    }
}
