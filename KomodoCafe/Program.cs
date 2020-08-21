using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.
            KomodoCafeUI ui = new KomodoCafeUI();
            ui.Start();
        }
    }
}
