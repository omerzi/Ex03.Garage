using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int c_NumOfWheels = 16;
        private const float c_MaxFuelCapacity = 120;
        private readonly float r_CargoCapacity;
        private bool m_IsDangerous;

        public Truck(string i_Model, string i_LicenseNumber, float i_EnergyLeft, EnergyType i_SourceOfEnergy, Wheel i_Wheel,
            float i_CargoCapacity, bool i_IsDangerous) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_SourceOfEnergy)
        {
            r_CargoCapacity = i_CargoCapacity;
            m_IsDangerous = i_IsDangerous;
            AddWheels(i_Wheel);
            EnergySetup(i_SourceOfEnergy);
        }

        public override void AddWheels(Wheel i_Wheel)
        {
            int i = 0;
            while (i < c_NumOfWheels)
            {
                this.Wheels.Add(i_Wheel);
                i++;
            }
        }

        public override void EnergySetup(EnergyType i_SourceOfEnergy)
        {
            if (i_SourceOfEnergy is Fuel)
            {
                i_SourceOfEnergy.MaxEnergyCapacity = c_MaxFuelCapacity;
                i_SourceOfEnergy.CurrentEnergyCapacity = c_MaxFuelCapacity;
                ((Fuel)i_SourceOfEnergy).FuelType = Fuel.eFuelType.Soler;
            }
            // אחרת לזרוק חריגה
        }
    }
}
