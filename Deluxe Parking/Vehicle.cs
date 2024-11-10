using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe_Parking
{
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Color { get; set; }
        DateTime EntryTime { get; set; }
        double ParkingSpacesNeeded { get; }
    }

    public class Car : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public bool IsElectric { get; set; }
        public double ParkingSpacesNeeded => 1; //  fixed value
        public Car(string registrationNumber, string color, DateTime entryTime, bool isElectric)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            EntryTime = entryTime;
            IsElectric = isElectric;
        }
    }

    public class Motorcycle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public string Brand { get; set; }
        public double ParkingSpacesNeeded => 0.5; // fixed value
        public Motorcycle(string registrationNumber, string color, DateTime entryTime, string brand)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            EntryTime = entryTime;
            Brand = brand;
        }
    }

    public class Bus : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public int PassengerCount { get; set; }
        public double ParkingSpacesNeeded => 2; //  fixed value

        public Bus(string registrationNumber, string color, DateTime entryTime, int passengerCount)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            EntryTime = entryTime;
            PassengerCount = passengerCount;
        }
    }

}
