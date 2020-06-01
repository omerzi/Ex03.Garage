using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private float m_EnergyLeft; // fuel / gas
        private EnergyType m_Source;
        private List<Wheel> m_Wheels;

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
            m_Wheels = new List<Wheel>();
            m_Source = i_SourceOfEnergy;
            m_EnergyLeft = (m_Source.CurrentEnergyCapacity / m_Source.MaxEnergyCapacity) * 100;
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
            get { return (m_Source.CurrentEnergyCapacity / m_Source.MaxEnergyCapacity) * 100; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        public void AddWheels(Wheel i_Wheel, int i_NumOfWheels, Wheel.eMaxAirPressure i_VehiclePressure)
        {
            for(int i = 0; i < i_NumOfWheels; i++)
            {
                i_Wheel.MaxAirPressure = (float)i_VehiclePressure;
                i_Wheel.CurrentAirPressure = (float)i_VehiclePressure;
                this.m_Wheels.Add(i_Wheel);
            }
        }

        public abstract void EnergySetup(EnergyType i_SourceOfEnergy);
    }
}
