using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Owner> r_GarageClients = new Dictionary<string, Owner>();

        public Dictionary<string, Owner> GarageClients
        {
            get { return r_GarageClients; }
        }

        public bool AddCar(Owner i_NewOwner)
        {
            string ownerLicensePlate = i_NewOwner.VehicleLicensePlate;
            bool isAlreadyExists = false;
            if (r_GarageClients.ContainsKey(ownerLicensePlate))
            {
                i_NewOwner.VehicleStatus = Owner.eVehicleStatus.InRepair;
                isAlreadyExists = true;
            }
            else
            {
                r_GarageClients.Add(ownerLicensePlate, i_NewOwner);
            }

            return isAlreadyExists;
        }


        public StringBuilder GetLicencseNumbers(int i_LicenseChoice)
        {
            StringBuilder licenseNumbers = new StringBuilder();
            foreach (Owner current in r_GarageClients.Values)
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
            r_GarageClients[i_LicenseNumber].VehicleStatus = i_VehicleChoice;
        }

        public void MaximizeWheelPressure(string i_LicenseNumber)
        {
            foreach (Wheel currentWheel in r_GarageClients[i_LicenseNumber].Vehicle.Wheels)
            {
                currentWheel.AddPressure(currentWheel.MaxAirPressure - currentWheel.CurrentAirPressure);
            }
        }

        public void IsFuelMatch(Fuel.eFuelType i_FuelType, string i_LicenseNumber)
        {
            if(r_GarageClients[i_LicenseNumber].Vehicle.EnergyType is Electric)
            {
                throw new ArgumentException("You can't add fuel to an electric car!");
            }
            else if(i_FuelType != ((Fuel)r_GarageClients[i_LicenseNumber].Vehicle.EnergyType).FuelType)
            {
                throw new ArgumentException("The fuel type you selected doesn't match to the vehicle fuel type!");
            }
        }

        public void InGarage(string i_LicensePlate)
        {
            if (!r_GarageClients.ContainsKey(i_LicensePlate))
            {
                throw new ArgumentException("The License Number you entered isn't exist in the garage!");
            }
        }

        public void AddVehicleEnergy(float i_AmountOfFuel, string i_LicenseNumber)
        {
            r_GarageClients[i_LicenseNumber].Vehicle.EnergyType.AddEnergy(i_AmountOfFuel);
        }

        public string GetVehicleDetails(string licensePlate)
        {
            return r_GarageClients[licensePlate].Details();
        }
    }
}
