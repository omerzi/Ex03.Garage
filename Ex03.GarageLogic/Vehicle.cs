using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private float m_EnergyLeft;
        private EnergyType m_Source;
        private readonly List<Wheel> r_Wheels;

        public enum eVehicleType
        {
            ElectricCar = 1,
            ElectricMotorcycle,
            FuelCar,
            FuelMotorcycle,
            Truck
        }

        public Vehicle(string i_Model, string i_LicenseNumber, EnergyType i_SourceOfEnergy)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            r_Wheels = new List<Wheel>();
            m_Source = i_SourceOfEnergy;
        }

        public string Model
        {
            get { return r_Model; }
        }

        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
        }

        public void SetEnergyLeft()
        {
            m_EnergyLeft = (m_Source.CurrentEnergyCapacity / m_Source.MaxEnergyCapacity) * 100;
        }

        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        public EnergyType EnergyType
        {
            get { return m_Source; }
        }

        public void AddWheels(Wheel i_Wheel, int i_NumOfWheels, Wheel.eMaxAirPressure i_VehiclePressure)
        {
            for(int i = 0; i < i_NumOfWheels; i++)
            {
                i_Wheel.MaxAirPressure = (float)i_VehiclePressure;
                i_Wheel.CurrentAirPressure = (float)i_VehiclePressure;
                this.r_Wheels.Add(i_Wheel);
            }
        }

        public abstract void EnergySetup(EnergyType i_SourceOfEnergy);

        public string Details()
        {
        string vehicleDetails = string.Format(
@"License Number: {0},
Model Name: {1},
{2},
{3},
Energy Left in Precentage: {4}%
{5}",
r_LicenseNumber,
r_Model,
r_Wheels[0].Details(),
m_Source.Details(),
EnergyLeft,
InnerDetails());
            return vehicleDetails;
        }

        protected abstract object InnerDetails();
    }
}
