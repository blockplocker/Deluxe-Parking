using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe_Parking
{
    public class Helper
    {
        
        public static int GetValidInteger()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }
        }
    }
}
