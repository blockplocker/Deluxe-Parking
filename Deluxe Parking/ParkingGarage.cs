﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe_Parking
{
    public class ParkingGarage
    {
        private int TotalSpaces;
        //private double PricePerMinute;   Removed since the price is now calculated by the vehicle
        private double[] parkingSpaces;
        private List<(IVehicle Vehicle, int StartIndex)> parkedVehicles = new List<(IVehicle, int)>();
        private static Random random = new Random();

        public ParkingGarage(int totalSpaces)
        {
            TotalSpaces = totalSpaces;
            parkingSpaces = new double[TotalSpaces];
        }

        // Method to check in a vehicle and assign it a parking space
        public bool CheckInVehicle(IVehicle vehicle)
        {
            try
            {
                double requiredSpace = vehicle.ParkingSpacesNeeded;

                for (int i = 0; i < TotalSpaces; i++)
                {
                    if (IsSpaceAvailable(i, requiredSpace))
                    {
                        AllocateSpace(i, requiredSpace, vehicle);
                        parkedVehicles.Add((vehicle, i));
                        Console.WriteLine($"Fordonet med registreringsnummret {vehicle.RegistrationNumber} parkerade på plats {i + 1}.");
                        return true;
                    }
                }

                Console.WriteLine("Tyvärr finns det inte tillräckligt med plats för detta fordon.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid incheckning: {ex.Message}");
                return false;
            }
        }

        // Method to check if space is available for the required parking space
        private bool IsSpaceAvailable(int index, double requiredSpace)
        {
            if (index + requiredSpace - 1 >= TotalSpaces) return false;

            double spaceNeeded = requiredSpace;
            for (int i = index; i < index + requiredSpace; i++)
            {
                if (parkingSpaces[i] >= 1) return false; // Full spot, cannot be used
                spaceNeeded -= (1 - parkingSpaces[i]); // Decrement needed space by available fractional space
            }
            return spaceNeeded <= 0; // True if enough fractional space was found
        }

        // Method to allocate parking space
        private void AllocateSpace(int index, double requiredSpace, IVehicle vehicle)
        {
            for (int i = index; i < index + requiredSpace; i++)
            {
                parkingSpaces[i] += vehicle.ParkingSpacesNeeded; // Mark space as partially/fully occupied
            }
        }

        // Method to check out a vehicle by its license plate
        public void CheckOutVehicle(string registrationNumber)
        {
            try
            {
                var parkedVehicle = parkedVehicles.FirstOrDefault(v => v.Vehicle.RegistrationNumber == registrationNumber);
                if (parkedVehicle.Vehicle != null)
                {
                    var vehicle = parkedVehicle.Vehicle;
                    int startIndex = parkedVehicle.StartIndex;
                    TimeSpan parkedDuration = DateTime.Now - vehicle.EntryTime;

                    //double parkingCost = parkedDuration.TotalMinutes * PricePerMinute; // Calculate cost based on time
                    double parkingCost = vehicle.CalculateParkingCost(parkedDuration); // Use the vehicle's own method to calculate cost

                    ReleaseSpace(startIndex, vehicle.ParkingSpacesNeeded);
                    parkedVehicles.Remove(parkedVehicle);
                    Console.WriteLine($"Fordonet med registreringsnummret {registrationNumber} har checkat ut. Tid parkerad: {parkedDuration.TotalMinutes:F1} minuter. Total kostnad: {parkingCost:F2} kr.");
                }
                else
                {
                    Console.WriteLine("Fordonet hittades inte.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid utcheckning: {ex.Message}");
            }
        }

        // Method to release parking space
        private void ReleaseSpace(int startIndex, double requiredSpace)
        {
            for (int i = startIndex; i < startIndex + requiredSpace; i++)
            {
                parkingSpaces[i] -= requiredSpace; // Decrease occupancy
            }
        }

        // Display all parked vehicles with spots information
        public void DisplayParkedVehicles()
        {
            try
            {
                Console.WriteLine("Nuvarande parkeringsstatus:");

                // Sort the parkedVehicles list based on the StartIndex
                List<(IVehicle Vehicle, int StartIndex)> sortedParkedVehicles = parkedVehicles.OrderBy(v => v.StartIndex).ToList();

                foreach (var (vehicle, startIndex) in sortedParkedVehicles)
                {
                    int endIndex = startIndex + (int)Math.Ceiling(vehicle.ParkingSpacesNeeded) - 1; // Determine the range of parking spots occupied by this vehicle

                    string spotInfo = endIndex > startIndex ? $"Plats {startIndex + 1}-{endIndex + 1}" : $"Plats {startIndex + 1}"; // Format the spot information

                    string vehicleInfo = $"{vehicle.GetType().Name} {vehicle.RegistrationNumber} {vehicle.Color}"; // Get the base vehicle information

                    // Add unique attributes based on vehicle type
                    if (vehicle is Car car)
                        vehicleInfo += car.IsElectric ? " Elbil" : "";
                    else if (vehicle is Motorcycle motorcycle)
                        vehicleInfo += " " + motorcycle.Brand;
                    else if (vehicle is Bus bus)
                        vehicleInfo += " " + bus.PassengerCount;

                    Console.WriteLine($"{spotInfo}: {vehicleInfo}"); // Display the formatted information for this vehicle
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid visning av parkerade fordon: {ex.Message}");
            }
        }
    }
}