using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water_Pump_Tanzania.Data_Reader;
using Water_Pump_Tanzania.Interfaces;

namespace Water_Pump_Tanzania.Predict
{
    internal static class PredictionMaker
    {
        /// <summary>
        /// Predict a failure for a given waterpump.
        /// </summary>
        public static void PredictFailure(int waterpumpId)
        {
            switch (WaterPumpCsv.GetWaterPumpStatus(waterpumpId))
            {
                case Status.Functional:
                    Console.WriteLine($"Waterpump {waterpumpId} is functional at this moment. Predicting when maintenance is required.");
                    break;
                case Status.NonFunctional:
                    Console.WriteLine($"Waterpump {waterpumpId} is not functional at this moment.");
                    return;
                case Status.NeedsRepair:
                    Console.WriteLine($"Waterpump {waterpumpId} needs repair at this moment.");
                    return;
            }

            // Create an input model.
            var inputModel = PredictHelper.MapToInputModel(GetWaterpump(waterpumpId));

        }

        /// <summary>
        /// Gets the waterpump data of a given waterpump with an id.
        /// </summary>
        private static WaterPumpLabels GetWaterpump(int waterpumpId)
        {
            try
            {
                return WaterPumpCsv.GetWaterPumpLabelById(waterpumpId);
            }
            catch
            {
                Console.WriteLine($"Waterpump with ID {waterpumpId} is unknown.");
            }
            return null;
        }
    }
}
