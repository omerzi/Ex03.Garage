using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Owner
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_PhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public Owner(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            OwnerName = i_OwnerName;
            PhoneNumber = i_PhoneNumber;
            VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public string VehicleLicensePlate
        {
            get { return m_Vehicle.LicenseNumber; }
        }
        public eVehicleStatus VehicleStatus 
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired,
            Paid,
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        public string Details()
        {
            string ownerDetails = string.Format(
@"Owner Name: {0},
Phone Number: {1},
Vehicle Status In Garage: {2},
{3}",
m_OwnerName,
m_PhoneNumber,
m_VehicleStatus,
m_Vehicle.Details());
            return ownerDetails;
        }
    }
}
