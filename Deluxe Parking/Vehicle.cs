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
        double CalculateParkingCost(TimeSpan duration); // vehicles can calculate their own parking cost
    }

    public class Car : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public bool IsElectric { get; set; }
        public double ParkingSpacesNeeded => 1; //  fixed value
        public Car(string color, DateTime entryTime, bool isElectric)
        {
            RegistrationNumber = Helper.GenerateRandomLicensePlate();
            Color = color;
            EntryTime = entryTime;
            IsElectric = isElectric;
        }
        public double CalculateParkingCost(TimeSpan duration)
        {
            double rate = IsElectric ? 1.0 : 1.5; // Different rate for electric cars
            return duration.TotalMinutes * rate;
        }
    }

    public class Motorcycle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public string Brand { get; set; }
        public double ParkingSpacesNeeded => 0.5; // fixed value
        public Motorcycle(string color, DateTime entryTime, string brand)
        {
            RegistrationNumber = Helper.GenerateRandomLicensePlate();
            Color = color;
            EntryTime = entryTime;
            Brand = brand;
        }
        public double CalculateParkingCost(TimeSpan duration)
        {
            return duration.TotalMinutes * 0.75; // Different rate for motorcycles
        }
    }

    public class Bus : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public int PassengerCount { get; set; }
        public double ParkingSpacesNeeded => 2; //  fixed value

        public Bus(string color, DateTime entryTime, int passengerCount)
        {
            RegistrationNumber = Helper.GenerateRandomLicensePlate();
            Color = color;
            EntryTime = entryTime;
            PassengerCount = passengerCount;
        }
        public double CalculateParkingCost(TimeSpan duration) 
        {
            return duration.TotalMinutes * 2.0; // Different rate for buses
        }
    }

}
