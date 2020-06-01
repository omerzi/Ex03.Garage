using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private const float k_MaxElectricCapacity = 2.1f;
        private eNumOfDoors m_NumOfCarDoors;
        private eColor m_CarColor;

        public Car(string i_Model, string i_LicenseNumber, EnergyType i_SourceOfEnergy, Wheel i_Wheel)
            : base(i_Model, i_LicenseNumber, i_SourceOfEnergy)
        {
            EnergySetup(i_SourceOfEnergy);
            AddWheels(i_Wheel, k_NumOfWheels, Wheel.eMaxAirPressure.Car);
        }

        public enum eColor
        {
            Red = 1,
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
            get { return m_NumOfCarDoors; }
            set { m_NumOfCarDoors = value; }
        }

        public eColor Color
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public override void EnergySetup(EnergyType i_SourceOfEnergy)
        {
            if (i_SourceOfEnergy is Fuel)
            {
                i_SourceOfEnergy.MaxEnergyCapacity = (float)Fuel.eMaxFuelCapacity.Car;
                i_SourceOfEnergy.CurrentEnergyCapacity = (float)Fuel.eMaxFuelCapacity.Car;
                ((Fuel)i_SourceOfEnergy).FuelType = Fuel.eFuelType.Octan96;
            }
            else
            {
                i_SourceOfEnergy.MaxEnergyCapacity = k_MaxElectricCapacity;
                i_SourceOfEnergy.CurrentEnergyCapacity = k_MaxElectricCapacity;
            }
        }
    }
}
