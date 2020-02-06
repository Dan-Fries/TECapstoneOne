using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Money
    {
        

        
        public Money()
        { 
            
        }

        public void MakeChange(decimal balance) 
        {
            const decimal Quarter = .25M;
            const decimal Dime = .10M;
            const decimal Nickel = .05M;
            int numberOfQuarters = 0;
            int numberOfDimes = 0;
            int numberOfNickels = 0;
            
            
            
            while (balance <= 0)
            {
                Console.WriteLine("No changed received. Thank you for purchasing!");
                return;
            }
            while (balance >= .25M)
            {
                numberOfQuarters = (int)Math.Truncate(balance / Quarter);
                balance = balance % .25M;
            }
            while (balance >= .10M)
            {
                numberOfDimes = (int)Math.Truncate(balance / Dime);
                balance = balance % .10M;
            }
            while (balance >= .05M)
            {
                numberOfNickels = (int)Math.Truncate(balance / Nickel);
                balance = balance % .05M;
            }

            Console.WriteLine($@"Your change is {balance}.
                                You will recieve:
                                    {numberOfQuarters} Quarters
                                    {numberOfDimes} Dimes
                                  & {numberOfNickels} Nickels
                                Press 'enter' to continue.
                                Thank you!");
            Console.ReadLine();
            

        }
       
    }
}
