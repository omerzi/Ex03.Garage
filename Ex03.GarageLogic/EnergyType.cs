using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergyType
    {
        private float m_MaxEnergyCapacity;  //כמות מירבית של דלק או גז
        private float m_CurrentEnergyCapacity;//כמות נוכחית של דלק או גז

        public float MaxEnergyCapacity
        {
            get { return m_MaxEnergyCapacity; }
            set { m_MaxEnergyCapacity = value; }
        }

        public float CurrentEnergyCapacity
        {
            get { return m_CurrentEnergyCapacity; }
            set { m_CurrentEnergyCapacity = value; }
        }

        public void AddEnergy(float i_AmountOfEnergy)
        {
            if(m_CurrentEnergyCapacity + i_AmountOfEnergy <= m_MaxEnergyCapacity)
            {
                m_CurrentEnergyCapacity += i_AmountOfEnergy;
            }
            else
            {
                // לזרוק חריגה
            }
        }
    }
}
