using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Pump_Tanzania.Data_Reader
{
    internal static class WaterPumpCsv
    {
        public static void CreateCombinedCsv()
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
        }
    }
}
