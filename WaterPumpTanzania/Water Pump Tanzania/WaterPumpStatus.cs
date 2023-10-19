﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Pump_Tanzania
{
    internal class WaterPumpStatus
    {
        /// <summary>
        /// Identifier of the waterpoint
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Whether the waterpump is functional
        /// </summary>
        public string? StatusGroup { get; set; }
    }
}
