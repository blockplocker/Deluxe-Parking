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
        private static Random random = new Random();

        public static string GenerateRandomLicensePlate()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string characters = new string(Enumerable.Repeat(letters, 3).Select(s => s[random.Next(s.Length)]).ToArray());
            string numbers = random.Next(100, 1000).ToString(); 
            return characters + numbers;
        }
    }
}
