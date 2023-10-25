using System.Globalization;
using Water_Pump_Tanzania.Predict;

namespace Water_Pump_Tanzania.Programs
{
    internal static class Predict
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Starting prediction program...");

            //MakePrediction();
            PredictRepairYear();

            Console.WriteLine("Finished prediction program! Press enter to continue.");
            Console.ReadLine();
        }

        /// <summary>
        /// Predicts the repair rate for a single waterpump over a number of years.
        /// </summary>
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
                    Console.WriteLine(ex.Message);
                    MakePrediction();
                }
            }
        }

        /// <summary>
        /// Predicts the year of repair for a set of waterpumps.
        /// </summary>
        private static void PredictRepairYear()
        {
            try
            {
                int fromId = 0, toId = 100, yearsToPredict = 10; float threshold = 0.15f, populationGrowth = 1.01f, staticHeadGrowth = 0.9f;
                try
                {
                    // Get range
                    Console.WriteLine("Enter range of waterpump IDs to use (e.g. 1000-3000)");
                    var input = Console.ReadLine();
                    var range = input.Split("-");
                    fromId = int.Parse(range[0]);
                    toId = int.Parse(range[1]);
                    if (fromId > toId) throw new ArgumentOutOfRangeException();

                    // Get treshhold
                    Console.WriteLine("Enter repair prediction threshold (e.g. 0.15 -> 15%)");
                    input = Console.ReadLine();
                    threshold = float.Parse(input, CultureInfo.InvariantCulture);

                    // Get years
                    Console.WriteLine("Enter number of years to predict (e.g. 15)");
                    input = Console.ReadLine();
                    yearsToPredict = int.Parse(input);

                    // Get population growth
                    Console.WriteLine("Enter yearly population growth (e.g. 1.01 for a growth of 1% each year)");
                    input = Console.ReadLine();
                    populationGrowth = float.Parse(input, CultureInfo.InvariantCulture);

                    // Get population growth
                    Console.WriteLine("Enter yearly static growth (e.g. 0.9 for a decrease of 10% each year)");
                    input = Console.ReadLine();
                    staticHeadGrowth = float.Parse(input, CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try agian.");
                    PredictRepairYear();
                }
                PredictionMaker.PredictMaintenanceYearForAllWaterpumps(fromId, toId, threshold, yearsToPredict, populationGrowth, staticHeadGrowth);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
