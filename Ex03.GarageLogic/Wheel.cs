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
        private float m_MaxAirPressure;

        public enum eMaxAirPressure
        {
            Truck = 28,
            Motorcycle = 30,
            Car = 32,
        }
        public Wheel(string i_Manufacturer)
        {
            m_Manufacturer = i_Manufacturer;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public void AddPressure(float i_PressureToAdd)
        {
            if(m_CurrentAirPressure + i_PressureToAdd <= MaxAirPressure)
            {
                m_CurrentAirPressure += i_PressureToAdd;
            }
            else
            {
                string msg = string.Format("You can't add more pressure than your maximum!");
                throw new ValueOutOfRangeException(MaxAirPressure, m_CurrentAirPressure, msg);
            }
        }
    }
}
