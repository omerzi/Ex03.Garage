using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private float m_CargoCapacity;
        private bool m_IsDangerous;

        public Truck(string i_Model, string i_LicenseNumber, EnergyType i_SourceOfEnergy, Wheel i_Wheel)
            : base(i_Model, i_LicenseNumber, i_SourceOfEnergy)
        {
            AddWheels(i_Wheel, k_NumOfWheels, Wheel.eMaxAirPressure.Truck);
            EnergySetup(i_SourceOfEnergy);
            m_IsDangerous = false;
        }

        public override void EnergySetup(EnergyType i_SourceOfEnergy)
        {
            if (i_SourceOfEnergy is Fuel)
            {
                i_SourceOfEnergy.MaxEnergyCapacity = (float)Fuel.eMaxFuelCapacity.Truck;
                i_SourceOfEnergy.CurrentEnergyCapacity = (float)Fuel.eMaxFuelCapacity.Truck;
                ((Fuel)i_SourceOfEnergy).FuelType = Fuel.eFuelType.Soler;
            }
            else
            {
                throw new FormatException("A truck energy type should be only fuel!");
            }
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; }
            set { m_CargoCapacity = value; }
        }

        public bool IsDangerous
        {
            get { return m_IsDangerous; }
            set { m_IsDangerous = value; }
        }
    }
}
