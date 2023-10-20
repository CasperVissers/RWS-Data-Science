using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water_Pump_Tanzania.Data_Reader;
using Water_Pump_Tanzania.Interfaces;
using static System.Formats.Asn1.AsnWriter;

namespace Water_Pump_Tanzania.Predict
{
    internal static class PredictionMaker
    {
        private const int CURRENT_YEAR = 2023;

        /// <summary>
        /// Predict a failure for a given waterpump.
        /// </summary>
        public static void PredictFailure(int waterpumpId, int yearsToPredict = 20, float populationGrowth = 1.01f, float staticHeadGrowth = 0.9f)
        {
            CheckCurrentStateBeforePrediction(waterpumpId,
                                              () => DisplayPredictions(MakePredictionInTheFuture(PredictHelper.MapToInputModel(WaterPumpCsv.GetWaterPumpLabelById(waterpumpId)), yearsToPredict, populationGrowth, staticHeadGrowth)),
                                              null,
                                              null);
        }

        /// <summary>
        /// Predict for a number of waterpumps the year when repairs are required.
        /// </summary>
        public static void PredictMaintenanceYearForAllWaterpumps(float repairTreshhold = 0.1f, int yearsToPredict = 20, float populationGrowth = 1.01f, float staticHeadGrowth = 0.9f)
        {
            for (int id = 0; id < 1000; id++)
            {
                try
                {
                    CheckCurrentStateBeforePrediction(id,
                                                      () => DisplayFailurePrediction(GetPredictionWhereTrheshholdIsReached(MakePredictionInTheFuture(PredictHelper.MapToInputModel(WaterPumpCsv.GetWaterPumpLabelById(id)), yearsToPredict, populationGrowth, staticHeadGrowth), repairTreshhold)),
                                                      null,
                                                      null);
                }
                catch { }
            }
        }

        /// <summary>
        /// Checks the status of the current waterpump before making a prediction about repairs.
        /// </summary>
        /// <param name="waterpumpId"></param>
        /// <param name="OnFunctional">What to do when the status is Functional</param>
        /// <param name="OnNonFunctional">What to do when the status is Non Functional</param>
        /// <param name="OnRepair">What to do when the status is Needs Repair</param>
        private static void CheckCurrentStateBeforePrediction(int waterpumpId, Action? OnFunctional, Action? OnNonFunctional, Action? OnRepair)
        {
            switch (WaterPumpCsv.GetWaterPumpStatus(waterpumpId))
            {
                case Status.Functional:
                    Console.WriteLine($"Waterpump {waterpumpId} is functional at this moment. Predicting when repairs are required.");
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
        private static List<Prediction> MakePredictionInTheFuture(PumpMaintenanceModel.ModelInput inputModel, int yearsToPredict, float populationGrowth, float staticHeadGrowth)
        {
            var predictions = new List<Prediction>();
            for (int y = 0, year = CURRENT_YEAR; y <= yearsToPredict; y++, year++)
            {
                var result = PumpMaintenanceModel.Predict(inputModel);
                predictions.Add(new ((int) inputModel.Id, year, result.Score));

                // Change year parameters
                inputModel.Construction_year--;
                inputModel.Amount_tsh *= staticHeadGrowth;
                inputModel.Population *= populationGrowth;
            }
            return predictions;
        }

        /// <summary>
        /// Display the results to the console.
        /// </summary>
        private static void DisplayPredictions(List<Prediction> predictions)
        {
            foreach (var prediction in predictions)
            {
                Console.WriteLine($"Prediction for year {prediction.Year}:");
                for (int i = 0; i < prediction.Scores.Length; i++)
                {
                    Console.WriteLine($"{PredictHelper.Labels[i],-15}{prediction.Scores[i]:F2}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Checks if the repair threshhold is reached. If it is, the prediction
        /// of that year is returned.
        /// </summary>
        /// <returns>The prediction where the threshold is reached. Or it returns a 
        /// prediction with the year -1 if the treshhold is not reached.</returns>
        private static Prediction GetPredictionWhereTrheshholdIsReached(List<Prediction> predictions, float threshhold)
        {
            var index = PredictHelper.GetIndexOfStatusLabel(Status.NeedsRepair);
            foreach(var prediction in predictions)
            {
                if (prediction.Scores[index] > threshhold) return prediction;
            }
            return new Prediction(predictions.First().Id, -1, predictions.Last().Scores);
        }

        private static void DisplayFailurePrediction(Prediction prediction)
        {
            if (prediction.Year == -1)
            {
                Console.WriteLine($"Waterpump {prediction.Id} is not expected to need repairs.");
            }
            else
            {
                Console.WriteLine($"Waterpump {prediction.Id} needs repairs in the year {prediction.Year}.");
            }    
        }
    }
}
