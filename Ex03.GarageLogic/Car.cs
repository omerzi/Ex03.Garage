using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int c_NumOfWheels = 4;
        private const float c_MaxFuelCapacity = 60;
        private const float c_MaxElectricCapacity = 2.1f;
        private readonly eNumOfDoors r_NumOfCarDoors;
        private eColor m_CarColor;

        public Car(float i_EnergyLeft, string i_LicenseNumber, string i_Model, EnergyType i_SourceOfEnergy, Wheel i_Wheel,
           eNumOfDoors i_NumOfCarDoors, eColor i_Color) : base(i_Model, i_LicenseNumber, i_EnergyLeft, i_SourceOfEnergy)
        {
            r_NumOfCarDoors = i_NumOfCarDoors;
            m_CarColor = i_Color;
            EnergySetup(i_SourceOfEnergy);
            AddWheels(i_Wheel);
        }

        public enum eColor
        {
            Red,
            White,
            Black,
            Silver
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        public eNumOfDoors NumOfDoors
        {
            get { return r_NumOfCarDoors; }
        }

        public eColor Color
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
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
                ((Fuel)i_SourceOfEnergy).FuelType = Fuel.eFuelType.Octan96;
            }
            else
            {
                i_SourceOfEnergy.MaxEnergyCapacity = c_MaxElectricCapacity;
                i_SourceOfEnergy.CurrentEnergyCapacity = c_MaxElectricCapacity;
            }
        }
    }
}
