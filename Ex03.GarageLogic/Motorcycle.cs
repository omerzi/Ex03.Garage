using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int c_NumOfWheels = 2;
        private const float c_MaxFuelCapacity = 7;
        private const float c_MaxElectricCapacity = 1.2f;
        private readonly int r_EngineCapacity;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_Model, string i_LicenseNumber, float i_EnergyLeft, int i_EngineCapacity,
            EnergyType i_SourceOfEnergy, eLicenseType i_LicenseType, Wheel i_Wheel) : base(i_Model,i_LicenseNumber,i_EnergyLeft, i_SourceOfEnergy)
        {
            m_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
            EnergySetup(i_SourceOfEnergy);
            AddWheels(i_Wheel);
        }

        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        public override void EnergySetup(EnergyType i_SourceOfEnergy)
        {
            if (i_SourceOfEnergy is Fuel)
            {
                i_SourceOfEnergy.MaxEnergyCapacity = c_MaxFuelCapacity;
                i_SourceOfEnergy.CurrentEnergyCapacity = c_MaxFuelCapacity;
                ((Fuel)i_SourceOfEnergy).FuelType = Fuel.eFuelType.Octan95;
            }
            else
            {
                i_SourceOfEnergy.MaxEnergyCapacity = c_MaxElectricCapacity;
                i_SourceOfEnergy.CurrentEnergyCapacity = c_MaxElectricCapacity;
            }
        }

        public override void AddWheels(Wheel i_Wheel)
        {
            int i = 0;
            while(i < c_NumOfWheels)
            {
                this.Wheels.Add(i_Wheel);
                i++;
            }
        }
    }
}
