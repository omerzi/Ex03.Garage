using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        public enum eGarageConstants
        {
            Zero = 0,
            One = 1,
            Two = 2,
            Seven = 7,
            Eight = 8,
            FirstOption = 1,
            ThirdOption = 3,
            FourthOption = 4,
            PhoneLength = 10
        }

        private readonly Garage m_Garage = new Garage();

        internal void InsertNewCar()
        {
            Owner newOwner = readOwner();
            bool isOwnerExists = m_Garage.AddCar(newOwner);
            if(isOwnerExists)
            {
                Console.Clear();
                Console.WriteLine(string.Format(
                    "{0} vehicle is already exists in the garage! changing vehicle status to : In Repair",
                    newOwner.OwnerName));
                System.Threading.Thread.Sleep(2000);
            }
        }

        internal void ShowAllLicenseNumbers()
        {
            string msg;
            string licenseNumbersList = string.Format(
@"Please select which licenses you would like to see:
1. All cars in 'In Repair' status.
2. All cars in 'Repaird' status.
3. All cars in 'Paid' status.
4. All cars in the garage.
Enter selection: ");
            Console.Write(licenseNumbersList);
            int licenseChoice = getValidNumber(
                (int)eGarageConstants.FirstOption,
                (int)eGarageConstants.FourthOption);
            Console.Clear();
            if (licenseChoice == (int)eGarageConstants.FourthOption)
            {
                msg = "These are all of the license numbers of the cars in the garage currently: ";
            }
            else
            {
                msg = string.Format(
                    "These are all of the license number of the cars in the garage which is in '{0}' status currently: ",
                    Enum.GetName(typeof(Owner.eVehicleStatus), licenseChoice));
            }

            Console.WriteLine(msg);
            Console.WriteLine(m_Garage.GetLicencseNumbers(licenseChoice));
            System.Threading.Thread.Sleep(2000);
        }

        internal void ChangeVehicleStatus()
        {
            string licensePlate = getLicensePlate();
            Owner.eVehicleStatus vehicleStatus = getVehicleStatus();
            m_Garage.ChangeStatus(vehicleStatus, licensePlate);
            Console.WriteLine("Successfully changed vehicle status to {0}", vehicleStatus);
            System.Threading.Thread.Sleep(2000);
        }

        internal void FillPressureToMax()
        {
            string licenseNumber = getLicensePlate();
            m_Garage.MaximizeWheelPressure(licenseNumber);
            Console.Clear();
            Console.WriteLine("The wheels were successfully inflate!");
            System.Threading.Thread.Sleep(2000);
        }

        private Owner.eVehicleStatus getVehicleStatus()
        {
            string statusList = string.Format(
@"Please select the desired status for the vehicle:
1. In Repair.
2. Repaired.
3. Paid.
Enter selection: ");
            Console.Write(statusList);
            int vehicleChoice = getValidNumber((int)eGarageConstants.FirstOption, (int)eGarageConstants.ThirdOption);
            return (Owner.eVehicleStatus)vehicleChoice;
        }

        private Owner readOwner()
        {
            string name = getOwnerName();
            string phone = getOwnerPhone();
            Vehicle vehicle = getOwnerVehicle();
            return new Owner(name, phone, vehicle);
        }

        private string getOwnerName()
        {
            Console.Write("Please enter your name: ");
            string name = getValidString("Your name ");
            return name;
        }

        private string getOwnerPhone()
        {
            bool IsValidNumber = false;
            Console.Write("Please enter your phone number (10 digits) : ");
            string phone = Console.ReadLine();
            IsValidNumber = int.TryParse(phone , out int PhoneAsInt);
            while(phone.Length != (int)eGarageConstants.PhoneLength || !IsValidNumber)
            {
                Console.Write("Invalid phone number, please enter again: ");
                phone = Console.ReadLine();
                IsValidNumber = int.TryParse(phone, out PhoneAsInt);
            }

            return phone;
        }

        private Vehicle getOwnerVehicle()
        {
            Vehicle.eVehicleType vehicleType =  getVehicleType();
            string vehicleModel = getVehicleModel();
            string licensePlate = getLicensePlate();
            EnergyType energyType = getEnergyType(vehicleType);
            Wheel wheel = getWheelData(vehicleType);
            Vehicle ownerVehicle = VehicleInitializer.CreateNewVehicle(vehicleType, vehicleModel, licensePlate, energyType, wheel);
            updateVehicleInnerData(ownerVehicle);
            return ownerVehicle;
        }

        private void updateVehicleInnerData(Vehicle i_VehicleOwner)
        {
            if (i_VehicleOwner is Car)
            {
                updateCarInnerData((Car)i_VehicleOwner);
            }
            else if (i_VehicleOwner is Motorcycle)
            {
                updateMotorcycleInnerData((Motorcycle)i_VehicleOwner);
            }
            else
            {
                updateTruckInnerData((Truck)i_VehicleOwner);
            }
        }

        private void updateCarInnerData(Car i_CarOwner)
        {
            setNumOfDoors(i_CarOwner);
            setCarColor(i_CarOwner);
        }

        private void updateMotorcycleInnerData(Motorcycle i_MotorcycleOwner)
        {
            setLicenseType(i_MotorcycleOwner);
            setEngineCapcity(i_MotorcycleOwner);
        }

        private void setEngineCapcity(Motorcycle i_MotorcycleOwner)
        {
            Console.Write("Please enter your Motorcycle engine capcity: ");
            int engineCapacity = getValidNumber((int)eGarageConstants.One, int.MaxValue);
            i_MotorcycleOwner.EngineCapacity = engineCapacity;
        }

        private void setLicenseType(Motorcycle i_MotorcycleOwner)
        {
            string licenseList = string.Format(
@"Please choose your driving license: 
1. A
2. A1
3. AA
4. B
Enter selection: ");
            Console.Write(licenseList);
            int licenseChoice = getValidNumber((int)Motorcycle.eLicenseType.A, (int)Motorcycle.eLicenseType.B);
            i_MotorcycleOwner.LicenseType = (Motorcycle.eLicenseType)licenseChoice;
        }

        private void updateTruckInnerData(Truck i_TruckOwner)
        {
            setCargoCapacity(i_TruckOwner);
            setIsDangerous(i_TruckOwner);
        }

        private void setIsDangerous(Truck i_TruckOwner)
        {
            Console.Write("Please press 1 if your truck carries dangerous materials, press 2 if it doesn't:");
            bool isValidInput = int.TryParse(Console.ReadLine(), out int isDangerous);
            while(!isValidInput || (isDangerous != (int)eGarageConstants.One && isDangerous != (int)eGarageConstants.Two))
            {
                Console.Write("Input is invalid, please choose 1 or 2");
                isValidInput = int.TryParse(Console.ReadLine(), out isDangerous);
            }

            if(isDangerous == (int) eGarageConstants.One)
            {
                i_TruckOwner.IsDangerous = true;
            }
        }

        private void setCargoCapacity(Truck i_TruckOwner)
        {
            Console.Write("Please enter your Truck cargo capacity: ");
            int cargoCapacity = getValidNumber((int)eGarageConstants.One, int.MaxValue);
            i_TruckOwner.CargoCapacity = cargoCapacity;
        }

        private void setNumOfDoors(Car i_CarOwner)
        {
            Console.Write("Please enter amount of doors in your car(2/3/4/5): ");
            int amountOfDoors = getValidNumber((int)Car.eNumOfDoors.Two, (int)Car.eNumOfDoors.Five);
            i_CarOwner.NumOfDoors = (Car.eNumOfDoors)amountOfDoors;
        }

        private void setCarColor(Car i_CarOwner)
        {
            string selectionList = string.Format(
@"Please choose your car's color:
1. Red
2. White 
3. Black
4. Silver
Enter selection: ");
            Console.Write(selectionList);
            int colorChoice = getValidNumber((int)Car.eColor.Red, (int)Car.eColor.Silver);
            i_CarOwner.Color = (Car.eColor)colorChoice;
        }

        private Wheel getWheelData(Vehicle.eVehicleType i_VehicleType)
        {
            Console.Write("Please enter your wheels manufactor name: ");
            string manufactorName = getValidString("Manufactor name");
            return new Wheel(manufactorName);
        }

        private Vehicle.eVehicleType getVehicleType()
        {
            int [] vehicleTypes = (int[])Enum.GetValues(typeof(Vehicle.eVehicleType));
            string vehicleList = string.Format(
@"Please select your vehicle's type:
1. Electric Car.
2. Electric Motorcycle.
3. Fuel Car.
4. Fuel Motorcycle.
5. Truck.
Enter selection: ");
            Console.Write(vehicleList);
            int selection = getValidNumber(vehicleTypes[(int)eGarageConstants.Zero], vehicleTypes[vehicleTypes.Length - 1]);
            return getVehicleSelection(selection);
        }

        private Vehicle.eVehicleType getVehicleSelection(int i_Selection)
        {
            Console.Clear();
            Vehicle.eVehicleType userChoice = Vehicle.eVehicleType.Truck;
            switch (i_Selection)
            {
                case (int)Vehicle.eVehicleType.ElectricCar:
                    userChoice = Vehicle.eVehicleType.ElectricCar;
                    break;
                case (int)Vehicle.eVehicleType.ElectricMotorcycle:
                    userChoice = Vehicle.eVehicleType.ElectricMotorcycle;
                    break;
                case (int)Vehicle.eVehicleType.FuelCar:
                    userChoice = Vehicle.eVehicleType.FuelCar;
                    break;
                case (int)Vehicle.eVehicleType.FuelMotorcycle:
                    userChoice = Vehicle.eVehicleType.FuelMotorcycle;
                    break;
            }

            return userChoice;
        }

        private EnergyType getEnergyType(Vehicle.eVehicleType i_VehicleType)
        {
            EnergyType energyType = null;

            if(i_VehicleType == Vehicle.eVehicleType.ElectricCar || i_VehicleType == Vehicle.eVehicleType.ElectricMotorcycle)
            {
                energyType = new Electric();
            }
            else
            {
                energyType = new Fuel();
            }

            return energyType;
        }

        private string getVehicleModel()
        {
            Console.Write("Enter your vehicle model: ");
            string model = getValidString("Vehicle's model");
            return model;
        }

        private string getLicensePlate()
        {
            Console.Write("Enter your car license plate: ");
            string licenseString = Console.ReadLine();
            bool isValidInput = int.TryParse(licenseString, out int licenseNumber);
            while (!isValidInput || licenseString.Length < (int)eGarageConstants.Seven || licenseString.Length > (int)eGarageConstants.Eight)
            {
                Console.Write("Invalid input, please enter a valid license plate: ");
                licenseString = Console.ReadLine();
                isValidInput = int.TryParse(licenseString, out licenseNumber);
            }

            return licenseString;
        }

        private string getValidString(string i_Msg)
        {
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.Write(string.Format(
                    "{0} cannot be empty or cosist only of whitespaces, please try again: ",
                    i_Msg));
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private int getValidNumber(int i_MinValue, int i_MaxValue)
        {
            bool isValidInput = int.TryParse(Console.ReadLine(), out int validInput);
            while(!isValidInput || validInput < i_MinValue || validInput > i_MaxValue)
            {
                Console.Write(string.Format(
                  "Your input is invalid, please enter a value between {0} to {1}: ",
                  i_MinValue,
                  i_MaxValue));
                isValidInput = int.TryParse(Console.ReadLine(), out validInput);
            }

            return validInput;
        }
    }
}
