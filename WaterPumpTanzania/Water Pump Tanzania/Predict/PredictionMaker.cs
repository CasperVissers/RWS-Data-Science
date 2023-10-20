using Water_Pump_Tanzania.Data_Reader;

namespace Water_Pump_Tanzania.Predict
{
    internal static class PredictionMaker
    {
        private const int CURRENT_YEAR = 2023;

        public static int IndexOfRepair
        {
            get
            {
                if (_indexOfRepair== -1)
                {
                    _indexOfRepair = PredictHelper.GetIndexOfStatusLabel(Status.NeedsRepair);
                }
                return _indexOfRepair;
            }
        }
        private static int _indexOfRepair = -1;


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
        public static void PredictMaintenanceYearForAllWaterpumps(int fromId, int toId, float repairTreshhold = 0.1f, int yearsToPredict = 20, float populationGrowth = 1.01f, float staticHeadGrowth = 0.9f)
        {
            Console.Clear();
            Console.WriteLine($"Prediction repair year for waterpumps {fromId} to {toId}." +
                $"Repair is needed when the model predicts a \"need repair\" of {repairTreshhold * 100:F2}%." +
                $"Prediction model runs untill the year {CURRENT_YEAR + yearsToPredict}." +
                $"The yearly population growth factor is {populationGrowth:F2} and yearly the static head growth factor is {staticHeadGrowth:F2}.\n");

            for (int id = fromId; id < toId; id++)
            {
                try
                {
                    CheckCurrentStateBeforePrediction(id,
                                                      () => DisplayRepairPrediction(GetPredictionWhereTrheshholdIsReached(MakePredictionInTheFuture(PredictHelper.MapToInputModel(WaterPumpCsv.GetWaterPumpLabelById(id)), yearsToPredict, populationGrowth, staticHeadGrowth), repairTreshhold)),
                                                      () => Console.WriteLine($"Waterpump {id} is not functional."),
                                                      () => Console.WriteLine($"Waterpump {id} needs repairs right now."),
                                                      false);
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
        private static void CheckCurrentStateBeforePrediction(int waterpumpId, Action? OnFunctional, Action? OnNonFunctional, Action? OnRepair, bool displayMsg = true)
        {
            switch (WaterPumpCsv.GetWaterPumpStatus(waterpumpId))
            {
                case Status.Functional:
                    if (displayMsg) Console.WriteLine($"Waterpump {waterpumpId} is functional at this moment. Predicting when repairs are required.");
                    OnFunctional?.Invoke();
                    return;
                case Status.NonFunctional:
                    if (displayMsg) Console.WriteLine($"Waterpump {waterpumpId} is not functional at this moment.");
                    OnNonFunctional?.Invoke();
                    return;
                case Status.NeedsRepair:
                    if (displayMsg) Console.WriteLine($"Waterpump {waterpumpId} needs repair at this moment.");
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
            for (int y = 0, year = CURRENT_YEAR + 1; y < yearsToPredict; y++, year++)
            {
                // Change year parameters
                inputModel.Construction_year--;
                inputModel.Amount_tsh *= staticHeadGrowth;
                inputModel.Population *= populationGrowth;

                // Make a prediction
                var result = PumpMaintenanceModel.Predict(inputModel);
                predictions.Add(new((int)inputModel.Id, year, result.Score));
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
            foreach(var prediction in predictions)
            {
                if (prediction.Scores[IndexOfRepair] > threshhold) return prediction;
            }
            return new Prediction(predictions.First().Id, -1, predictions.Last().Scores);
        }

        /// <summary>
        /// Display the expected repair prediction.
        /// </summary>
        private static void DisplayRepairPrediction(Prediction prediction)
        {
            if (prediction.Year == -1)
            {
                Console.WriteLine($"Waterpump {prediction.Id} is not expected to need repairs.");
            }
            else
            {
                Console.WriteLine($"Waterpump {prediction.Id} is expected to need repairs in the year {prediction.Year} ({prediction.Scores[IndexOfRepair]*100:F2}%).");
            }    
        }
    }
}
