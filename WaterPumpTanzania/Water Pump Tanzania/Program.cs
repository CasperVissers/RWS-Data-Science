using CsvHelper;
using System.Globalization;

namespace Water_Pump_Tanzania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("C:\\Users\\Caspe\\Csharp\\RWS\\Data Science Assignment\\WaterPumpTanzania\\Water Pump Tanzania\\_files\\data_scientist\\water_pump_labels.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // read CSV file
            var records = csv.GetRecords<WaterPump>();


            // output
            int i = 0;
            foreach (var r in records)
            {
                Console.WriteLine($"{r.Id,-15}{r.PublicMeeting,-10}");
                i++;
                if (i > 10) break;
            }

            Console.WriteLine("Hello, World!");
        }
    }
}