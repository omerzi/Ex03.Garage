using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class MenuUI
    {
        private const int k_LastOption = 8;
        private const int k_FirstOption = 1;
        private GarageManager m_GarageManager = new GarageManager();
        public enum eMenuOptions
        {
            InsertNewCar = 1,
            ShowAllDrivingLicenses,
            ChangeVehicleStatus,
            AddPressureToMax,
            AddFuel,
            Charge,
            ShowFullVehicleDetails,
            Exit
        }

        private void printMainMenu()
        {
            string mainMenu = string.Format(
@"Welcome to our Garage!
1. Enter your car to our Garage.
2. Show all Driving License numbers currently at the Garage.
3. Change Vehicle status.
4. Add Vehicle wheel pressure to its maximum.
5. Fuel a gasoline Vehicle.
6. Charge an electric Vehicle.
7. Show Vehicle full details.
8. Exit Garage.
Enter selection: ");
            Console.Write(mainMenu);
        }

        public void OpenGarage()
        {
            int selection = 0;
            do
            {
                Console.Clear();
                printMainMenu();
                try
                {
                    selection = int.Parse(Console.ReadLine());
                    if (selection < k_FirstOption || selection > k_LastOption)
                    {
                        throw new ValueOutOfRangeException(k_LastOption, k_FirstOption, string.Format("{0} is not a valid option, please try again!", selection));
                    }

                    goToChoice(selection);
                }
                catch (FormatException ex)
                {
                    Console.Clear();
                    ex = new FormatException("The value you entered is not a number, please try again!");
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(2000);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(2000);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(2000);
                }
            }
             while (selection != (int)eMenuOptions.Exit);
        }

        private void goToChoice(int i_Choice)
        {
            Console.Clear();
            switch(i_Choice)
            {
                case ((int)eMenuOptions.InsertNewCar):
                    m_GarageManager.InsertNewCar();
                    break;
                case ((int)eMenuOptions.ShowAllDrivingLicenses):
                    m_GarageManager.ShowAllLicenseNumbers();
                    break;
                case ((int)eMenuOptions.ChangeVehicleStatus):
                    m_GarageManager.ChangeVehicleStatus();
                    break;
                case ((int)eMenuOptions.AddPressureToMax):
                    m_GarageManager.FillPressureToMax();
                    break;
                case ((int)eMenuOptions.AddFuel):
                    //פונקציה
                    break;
                case ((int)eMenuOptions.Charge):
                    //פונקציה
                    break;
                case ((int)eMenuOptions.ShowFullVehicleDetails):
                    //פונקציה
                    break;
            }
        }
    }
}
