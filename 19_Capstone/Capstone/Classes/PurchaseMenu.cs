using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu : Menu
    {
        public PurchaseMenu(Dictionary<string, item> ) : base(Dictionary<string, item>)
        {
        }

        public decimal CurrentBalance {get; }

        public void PurchaseItem ()
        {
            
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
