using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu : Menu
    {
        private static Dictionary<string, Item> MenuList;

        public PurchaseMenu() : base(MenuList)
        {

        }

        public decimal CurrentBalance { get; }

       

        #region Methods



        public void DisplayItems()
        {
            foreach (KeyValuePair<string, Item> kvp in MenuList)
            {
                Console.WriteLine($"{kvp.Key}) {kvp.Value.Name} - {kvp.Value.Price} - {kvp.Value.Quantity}");
            }
        }

        public void PurchaseItem()
        {

        }

        public override void Exit()
        {
            base.Exit();
        }



        #endregion
    }
}
