using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Pump_Tanzania
{
    internal class WaterPumpStatus : Interfaces.IWaterPumpStatus
    {
        public int Id { get; set; }
        public string? StatusGroup { get; set; }
    }
}
