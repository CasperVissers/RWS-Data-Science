using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Pump_Tanzania.Interfaces
{
    internal interface IWaterPumpStatus : IWaterPumpId
    {
        /// <summary>
        /// Whether the waterpump is functional
        /// </summary>
        public string? StatusGroup { get; set; }
    }
}
