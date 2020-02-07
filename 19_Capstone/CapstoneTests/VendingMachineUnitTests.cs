using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineUnitTests
    {
        [DataTestMethod]
        [DataRow("10.00", "0.00")]
        [DataRow("15.00", "0.00")]
        [DataRow("1.00", "0.00")]
        [DataRow("20.00", "0.00")]
        [DataRow("0.00", "0.00")]
        [DataRow("-10.00", "-10.00")]
        public void MakeChangeTests(string startingValue, string expectedValue)
        {
            //Arrange
            VendingMachine vm = new VendingMachine();
            decimal startingVal = decimal.Parse(startingValue);
            decimal expectedVal = decimal.Parse(expectedValue);

            //Act
            vm.CurrentBalance = startingVal;
            vm.MakeChange();
            decimal actualValue = vm.CurrentBalance;

            //Assert
            Assert.AreEqual(expectedVal, actualValue);
        }
    }
}
