using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe_Parking
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public abstract double ParkingSpacesNeeded { get; }
        public Vehicle(string color, DateTime entryTime )
        {
            RegistrationNumber = Helper.GenerateRandomLicensePlate();
            Color = color;
            EntryTime = entryTime;
        }
    }

    public class Car : Vehicle
    {
        public bool IsElectric { get; set; }
        public override double ParkingSpacesNeeded => 1; //  fixed value
        public Car(string color, DateTime entryTime, bool isElectric) : base(color, entryTime)
        {
            IsElectric = isElectric;
        }
    }

    public class Motorcycle : Vehicle
    {
        public string Brand { get; set; }
        public override double ParkingSpacesNeeded => 0.5; // fixed value
        public Motorcycle(string color, DateTime entryTime, string brand) : base(color, entryTime)
        {
            Brand = brand;
        }
    }

    public class Bus : Vehicle
    {
        public int PassengerCount { get; set; }
        public override double ParkingSpacesNeeded => 2; //  fixed value

        public Bus(string color, DateTime entryTime, int passengerCount) : base(color, entryTime)
        {
            PassengerCount = passengerCount > 0 ? passengerCount :throw new ArgumentException("Antal passagerare måste vara mer än noll");
        }
    }

}
