using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Money
    {
        public decimal Nickel { get; private set; }
        public decimal Dime { get; private set; }
        public decimal Quarter { get; private set; }
        public decimal Dollar { get; private set; }
        
        public decimal Balance { get; set; }
        public Money(decimal balance)
        {
            balance = 0;
            Dollar = 1.00M;
            Quarter = 0.25M;
            Dime = 0.10M;
            Nickel = 0.05M;

        }

        public decimal GetBalance ()
        {

            return Balance;
        }
    }
}
