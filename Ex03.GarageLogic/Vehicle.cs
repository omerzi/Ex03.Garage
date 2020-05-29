using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string m_Model;
        private readonly string m_LicenseNumber;
        private float m_EnergyLeft; // fuel / gas
        private EnergyType m_Source;
        private List<Wheel> m_Wheels;

        public Vehicle(string i_Model, string i_LicenseNumber, float i_EnergyLeft, EnergyType i_SourceOfEnergy)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLeft = i_EnergyLeft;
            m_Wheels = new List<Wheel>();
            m_Source = i_SourceOfEnergy;           
        }

        public string Model
        {
            get { return m_Model; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        public abstract void AddWheels(Wheel i_Wheel);
        public abstract void EnergySetup(EnergyType i_SourceOfEnergy);
    }
}
