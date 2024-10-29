using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Deluxe_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Välkommen till Deluxe Parking!");
                Console.WriteLine("1: Checka in");
                Console.WriteLine("2: Checka ut");
                Console.WriteLine("3: Visa fordon");

                int choice = Helper.GetValidInteger();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Välj fordonstyp 1: Bil, 2: Motorcykel, 3: Buss ");

                        int vehicleType = Helper.GetValidInteger();
                        switch (vehicleType)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Ange registreringsnummer för fordonet som ska checkas ut:");
                        string regNum = Console.ReadLine();
                        //garage.CheckOutVehicle(regNum);
                        break;

                    case 3:
                        //garage.DisplayParkedVehicles();
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;



                }
            }
        }
    }
}