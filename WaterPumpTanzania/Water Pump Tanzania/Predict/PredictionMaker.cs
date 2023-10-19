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
                    MakePredictionInTheFuture(PredictHelper.MapToInputModel(GetWaterpump(waterpumpId)));
                    return;
                case Status.NonFunctional:
                    Console.WriteLine($"Waterpump {waterpumpId} is not functional at this moment.");
                    return;
                case Status.NeedsRepair:
                    Console.WriteLine($"Waterpump {waterpumpId} needs repair at this moment.");
                    return;
            }
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

        private static void MakePredictionInTheFuture(PumpMaintenanceModel.ModelInput inputModel, int years = 15)
        {
            for (int y = 0, cY = 2024; y < years; y++, cY++)
            {
                inputModel.Construction_year--;
                inputModel.Amount_tsh *= 0.9f;

                var result = PumpMaintenanceModel.Predict(inputModel);
                DisplayPrediction(cY, result.Score);
            }
        }

        private static void DisplayPrediction(int year, float[] Scores)
        {
            Console.WriteLine($"Prediction for year {year}:");
            Console.WriteLine($"{PredictHelper.Labels[0],-15}{Scores[0]:F2}");
            Console.WriteLine($"{PredictHelper.Labels[1],-15}{Scores[1]:F2}");
            Console.WriteLine($"{PredictHelper.Labels[2],-15}{Scores[2]:F2}");
            Console.WriteLine();
        }
    }
}
