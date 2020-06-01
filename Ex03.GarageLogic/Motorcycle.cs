using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxElectricCapacity = 1.2f;
        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_Model, string i_LicenseNumber, EnergyType i_SourceOfEnergy, Wheel i_Wheel)
            : base(i_Model, i_LicenseNumber, i_SourceOfEnergy)
        {
            EnergySetup(i_SourceOfEnergy);
            AddWheels(i_Wheel, k_NumOfWheels, Wheel.eMaxAirPressure.Motorcycle);
        }

        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B
        }

        public override void EnergySetup(EnergyType i_SourceOfEnergy)
        {
            if (i_SourceOfEnergy is Fuel)
            {
                i_SourceOfEnergy.MaxEnergyCapacity = (float)Fuel.eMaxFuelCapacity.Motorcycle;
                i_SourceOfEnergy.CurrentEnergyCapacity = (float)Fuel.eMaxFuelCapacity.Motorcycle;
                ((Fuel)i_SourceOfEnergy).FuelType = Fuel.eFuelType.Octan95;
            }
            else
            {
                i_SourceOfEnergy.MaxEnergyCapacity = k_MaxElectricCapacity;
                i_SourceOfEnergy.CurrentEnergyCapacity = k_MaxElectricCapacity;
            }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
    }
}
