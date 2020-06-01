using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Owner> m_GarageClients = new Dictionary<string, Owner>();

        public Dictionary<string, Owner> GarageClients
        {
            get { return m_GarageClients; }
        }

        public bool AddCar(Owner i_NewOwner)
        {
            string ownerLicensePlate = i_NewOwner.VehicleLicensePlate;
            bool isAlreadyExists = false;
            if (m_GarageClients.ContainsKey(ownerLicensePlate))
            {
                i_NewOwner.VehicleStatus = Owner.eVehicleStatus.InRepair;
                isAlreadyExists = true;
            }
            else
            {
                m_GarageClients.Add(ownerLicensePlate, i_NewOwner);
            }

            return isAlreadyExists;
        }

        public StringBuilder GetLicencseNumbers(int i_LicenseChoice)
        {
            StringBuilder licenseNumbers = new StringBuilder();
            foreach (Owner current in m_GarageClients.Values)
            {
                if (i_LicenseChoice == 4)
                {
                    licenseNumbers.AppendLine(current.VehicleLicensePlate);
                }
                else if (current.VehicleStatus == (Owner.eVehicleStatus)i_LicenseChoice)
                {
                    licenseNumbers.AppendLine(current.VehicleLicensePlate);
                }
            }

            return licenseNumbers;
        }

        public void ChangeStatus(Owner.eVehicleStatus i_VehicleChoice, string i_LicenseNumber)
        {
            isInGarage(i_LicenseNumber);
            m_GarageClients[i_LicenseNumber].VehicleStatus = i_VehicleChoice;
        }

        public void MaximizeWheelPressure(string i_LicenseNumber)
        {
            isInGarage(i_LicenseNumber);
            foreach (Wheel currentWheel in m_GarageClients[i_LicenseNumber].Vehicle.Wheels)
            {
                currentWheel.AddPressure(currentWheel.MaxAirPressure - currentWheel.CurrentAirPressure);
            }
        }

        private void isInGarage(string i_LicensePlate)
        {
            if (!m_GarageClients.ContainsKey(i_LicensePlate))
            {
                throw new ArgumentException("The License Number you entered isn't exist in the garage!");
            }
        }
    }
}
