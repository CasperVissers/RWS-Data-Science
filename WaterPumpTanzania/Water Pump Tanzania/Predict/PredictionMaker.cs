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
        public static void PredictFailure(int waterpumpId, int yearsToPredict = 20, float populationGrowth = 1.01f, float staticHeadGrowth = 0.9f)
        {
            switch (WaterPumpCsv.GetWaterPumpStatus(waterpumpId))
            {
                case Status.Functional:
                    Console.WriteLine($"Waterpump {waterpumpId} is functional at this moment. Predicting when maintenance is required.");
                    MakePredictionInTheFuture(PredictHelper.MapToInputModel(GetWaterpump(waterpumpId)), yearsToPredict, populationGrowth, staticHeadGrowth);
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

        /// <summary>
        /// Make preduction for the failure rates in the future.
        /// </summary>
        private static void MakePredictionInTheFuture(PumpMaintenanceModel.ModelInput inputModel, int yearsToPredict, float populationGrowth, float staticHeadGrowth)
        {
            for (int y = 0, cY = 2024; y <= yearsToPredict; y++, cY++)
            {
                var result = PumpMaintenanceModel.Predict(inputModel);
                DisplayPrediction(cY, result.Score);

                inputModel.Construction_year--;
                inputModel.Amount_tsh *= staticHeadGrowth;
                inputModel.Population *= populationGrowth;
            }
        }

        /// <summary>
        /// Display the results to the console.
        /// </summary>
        private static void DisplayPrediction(int year, float[] Scores)
        {
            Console.WriteLine($"Prediction for year {year}:");
            for(int i = 0; i < Scores.Length; i++)
            {
                Console.WriteLine($"{PredictHelper.Labels[i],-15}{Scores[i]:F2}");
            }
            Console.WriteLine();
        }
    }
}
