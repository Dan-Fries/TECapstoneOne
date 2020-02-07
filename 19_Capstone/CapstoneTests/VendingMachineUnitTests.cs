using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineUnitTests
    {
        [DataTestMethod]
        [DataRow("10.00", @"
Your change is $10.00.
You will recieve:
40 Quarters
0 Dimes
& 0 Nickels
Press 'enter' to continue.
Thank you!")]
        [DataRow("10.15", @"
Your change is $10.15.
You will recieve:
40 Quarters
1 Dimes
& 1 Nickels
Press 'enter' to continue.
Thank you!")]
        [DataRow("2.85", @"
Your change is $2.85.
You will recieve:
11 Quarters
1 Dimes
& 0 Nickels
Press 'enter' to continue.
Thank you!")]
        [DataRow("7.65", @"
Your change is $7.65.
You will recieve:
30 Quarters
1 Dimes
& 1 Nickels
Press 'enter' to continue.
Thank you!")]
        [DataRow("0", "No changed received. Thank you for purchasing!")]

        public void MakeChangeTests(string startingValue, string expectedReturn)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            vm.CurrentBalance = decimal.Parse(startingValue);

            //Act
            string actualValue = vm.MakeChange();

            //Assert
            Assert.AreEqual(expectedReturn, actualValue);
            Assert.AreEqual(0M, vm.CurrentBalance);
        }

        [DataTestMethod]
        [DataRow(2, "2.00")]
        [DataRow(5, "5.00")]
        [DataRow(0, "0.00")]
        [DataRow(12, "12.00")]
        public void FeedMoneyTests(int dollar, string expectedVal)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            decimal expectedValue = decimal.Parse(expectedVal);

            //Act
            vm.FeedMoney(dollar);
            decimal actualValue = vm.CurrentBalance;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [DataTestMethod]
        [DataRow("B9", "10.00", "The slot you entered does not exist, returning to purchase menu")]
        [DataRow("H1", "10.00", "The slot you entered does not exist, returning to purchase menu")]
        [DataRow("A4", "0.00", "Sorry but you do not have enough funds please add more and try again!")]
        [DataRow("B3", "0.50", "Sorry but you do not have enough funds please add more and try again!")]
        [DataRow("A1", "15.00", @"
You succesfully purchased Potato Crisps!
Crunch Crunch, Yum!

$3.05 has been deducted from your balance!")]
        [DataRow("C4", "15.00", @"
You succesfully purchased Heavy!
Glug Glug, Yum!

$1.50 has been deducted from your balance!")]

        public void PurchaseItemTests(string slotToPurchase, string startingBalance, string expectedReturn)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            vm.CurrentBalance = decimal.Parse(startingBalance);
            
            //Act
            string actualValue = vm.PurchaseItem(slotToPurchase);

            //Assert
            Assert.AreEqual(expectedReturn, actualValue);
        }
    }
}
