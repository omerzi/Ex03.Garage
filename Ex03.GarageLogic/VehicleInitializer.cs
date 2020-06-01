using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInitializer
    {
        public static Vehicle CreateNewVehicle(
            Vehicle.eVehicleType i_VehicleType,
            string i_Model,
            string i_LicenseNumber,
            EnergyType i_SourceOfEnergy,
            Wheel i_Wheel)
        {
            Vehicle newVehicle = null; 
            if(i_VehicleType == Vehicle.eVehicleType.ElectricCar || i_VehicleType == Vehicle.eVehicleType.FuelCar)
            {
                newVehicle = new Car(i_Model, i_LicenseNumber, i_SourceOfEnergy, i_Wheel);
            }
            else if(i_VehicleType == Vehicle.eVehicleType.Truck)
            {
                newVehicle = new Truck(i_Model, i_LicenseNumber, i_SourceOfEnergy, i_Wheel);
            }
            else
            {
                newVehicle = new Motorcycle(i_Model, i_LicenseNumber, i_SourceOfEnergy, i_Wheel);
            }

            return newVehicle;
        }
    }
}
