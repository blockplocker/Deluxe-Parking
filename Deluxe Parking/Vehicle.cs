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

    }
    public class Car : Vehicle
    {
        public bool IsElectric { get; set; }
        public override double ParkingSpacesNeeded => 1;
    }

    public class Motorcycle : Vehicle
    {
        public string Brand { get; set; }
        public override double ParkingSpacesNeeded => 0.5;
    }

    public class Bus : Vehicle
    {
        public int PassengerCount { get; set; }
        public override double ParkingSpacesNeeded => 2;
    }
}
