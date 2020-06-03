using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Electric : EnergyType
    {
        public override string Details()
        {
            string electricDetails = string.Format(
@"Max Power Capacity: {0},
Current Power Capacity: {1},
Type: {2}",
base.MaxEnergyCapacity,
base.CurrentEnergyCapacity,
EnergyType.eEnergyType.Electric);
            return electricDetails;
        }
        
    }
}
