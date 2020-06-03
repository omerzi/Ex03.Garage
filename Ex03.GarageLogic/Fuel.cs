using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel : EnergyType
    {
        private eFuelType m_FuelType;
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        public enum eMaxFuelCapacity
        {
            Car = 60,
            Motorcycle = 7,
            Truck = 120
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public override string Details()
        {
            string fuelDetails = string.Format(
@"Max Fuel Tank Capacity: {0},
Current Fuel Tank Capacity: {1},
Type: {2},
Fuel Type: {3}",
base.MaxEnergyCapacity,
base.CurrentEnergyCapacity,
EnergyType.eEnergyType.Fuel,
m_FuelType);
            return fuelDetails;
        }
    }
}
