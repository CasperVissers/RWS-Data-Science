using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water_Pump_Tanzania.Predict;

namespace Water_Pump_Tanzania.Programs
{
    internal static class Predict
    {
        public static void Run()
        {
            Console.WriteLine("Starting prediction program...");

            MakePrediction();

            Console.WriteLine("Finished prediction program!");
        }

        private static void MakePrediction()
        {
            Console.WriteLine("Enter waterpump ID to predict.");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var id))
            {
                try
                {
                    PredictionMaker.PredictFailure(id);
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine(ex);
                    MakePrediction();
                }
            }
            
        }

    }
}
