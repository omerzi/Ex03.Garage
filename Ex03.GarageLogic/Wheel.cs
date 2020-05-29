using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        public enum eMaxAirPressure
        {
            Motorcycle = 30,
            Car = 32,
            Truck = 28
        }
        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public void AddPressure(float i_PressureToAdd)
        {
            if(m_CurrentAirPressure + i_PressureToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_PressureToAdd;
            }
            else
            {
                //החזר שגיאה
            }
        }
    }
}
