using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Item
    {
        #region Properties
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; set; }
        public string Type { get; private set; }
        #endregion

        #region Constructors
        public Item(string name, decimal price, int quantity, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }
        #endregion
    }
}
