﻿using System;

using System.Security.Cryptography.X509Certificates;

namespace Deluxe_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IParkingGarage garage = new ParkingGarage(15, 1.5);

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Deluxe Parking!");
                    Console.WriteLine("1: Checka in");
                    Console.WriteLine("2: Checka ut");
                    Console.WriteLine("3: Visa fordon");
                    Console.WriteLine("0: Avsluta");

                    int choice = Helper.GetValidInteger();
                    switch (choice)
                    {
                        case 1:
                            CheckInVehicle(garage);
                            break;

                        case 2:
                            CheckOutVehicle(garage);
                            break;

                        case 3:
                            garage.DisplayParkedVehicles();
                            break;

                        case 0:
                            Console.WriteLine("Tack för att du använder Deluxe Parking!");
                            return;

                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ett oväntat fel inträffade: {ex.Message}");
                }
            }
        }

        private static void CheckInVehicle(IParkingGarage garage)
        {
            Console.WriteLine("Välj fordonstyp 1: Bil, 2: Motorcykel, 3: Buss ");
            int vehicleType = Helper.GetValidInteger();

            Vehicle vehicle = null;
            Console.WriteLine("Ange färg på fordonet:");
            string color = Console.ReadLine();

            switch (vehicleType)
            {
                case 1: // Car
                    Console.WriteLine("Är bilen en elbil? (ja/nej)");
                    bool isElectric = Console.ReadLine()?.ToLower() == "ja";
                    vehicle = new Car(color, DateTime.Now, isElectric);
                    break;

                case 2: // Motorcycle
                    Console.WriteLine("Ange märke för motorcykeln:");
                    string brand = Console.ReadLine();
                    vehicle = new Motorcycle(color, DateTime.Now, brand);
                    break;

                case 3: // Bus
                    Console.WriteLine("Ange antal passagerare för bussen:");
                    int passengerCount = Helper.GetValidInteger();
                    vehicle = new Bus(color, DateTime.Now, passengerCount);
                    break;

                default:
                    Console.WriteLine("Ogiltig fordonstyp.");
                    return;
            }

            if (vehicle != null)
            {
                garage.CheckInVehicle(vehicle);
            }
        }

        private static void CheckOutVehicle(IParkingGarage garage)
        {
            Console.WriteLine("Ange registreringsnummer för fordonet som ska checkas ut:");
            string regNum = Console.ReadLine().ToUpper();
            garage.CheckOutVehicle(regNum);
        }
    }
}