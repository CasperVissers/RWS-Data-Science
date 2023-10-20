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
            CheckCurrentStateBeforePrediction(waterpumpId,
                                              () => MakePredictionInTheFuture(PredictHelper.MapToInputModel(WaterPumpCsv.GetWaterPumpLabelById(waterpumpId)), yearsToPredict, populationGrowth, staticHeadGrowth),
                                              null,
                                              null);
        }

        public static void PredictMaintenanceYear(float repairTreshhold = 0.1f, int yearsToPredict = 20, float populationGrowth = 1.01f, float staticHeadGrowth = 0.9f)
        {

        }

        private static void CheckCurrentStateBeforePrediction(int waterpumpId, Action? OnFunctional, Action? OnNonFunctional, Action? OnRepair)
        {
            switch (WaterPumpCsv.GetWaterPumpStatus(waterpumpId))
            {
                case Status.Functional:
                    Console.WriteLine($"Waterpump {waterpumpId} is functional at this moment. Predicting when maintenance is required.");
                    OnFunctional?.Invoke();
                    return;
                case Status.NonFunctional:
                    Console.WriteLine($"Waterpump {waterpumpId} is not functional at this moment.");
                    OnNonFunctional?.Invoke();
                    return;
                case Status.NeedsRepair:
                    Console.WriteLine($"Waterpump {waterpumpId} needs repair at this moment.");
                    OnRepair?.Invoke();
                    return;
            }
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
