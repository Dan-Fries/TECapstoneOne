using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Menu : IReportable
    {
        List<item> Items = new List<item>();

        public Menu (Dictionary<string, item>)
        {

        }

        public void Display ()
        {

        }

        public string Read ()
        {
            return null;
        }

        virtual public void Exit ()
        {

        }

        public string Reporting()
        {
            throw new NotImplementedException();
        }
    }
}
