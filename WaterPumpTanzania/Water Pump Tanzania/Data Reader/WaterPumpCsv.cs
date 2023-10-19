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
        const string WATER_PUMP_LABELS_PATH = "C:\\Users\\Caspe\\Csharp\\RWS\\Data Science Assignment\\WaterPumpTanzania\\Water Pump Tanzania\\_files\\data_scientist\\water_pump_labels.csv";
        const string WATER_PUMP_SET_PATH = "C:\\Users\\Caspe\\Csharp\\RWS\\Data Science Assignment\\WaterPumpTanzania\\Water Pump Tanzania\\_files\\data_scientist\\water_pump_set.csv";

        public static void CreateCombinedCsv()
        {
            var waterPumpSets = DataReader.ReadCsvToList<WaterPumpStatus>(WATER_PUMP_SET_PATH);


            using var reader = new StreamReader(WATER_PUMP_LABELS_PATH);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // read CSV file
            var records = csv.GetRecords<WaterPump>();


            // output
            int i = 0;
            foreach (var r in records)
            {
                WaterPumpStatusData waterPumpCombined = new(r, waterPumpSets);


                Console.WriteLine($"{r.Id,-15}{r.PublicMeeting,-10}");
                i++;
                if (i > 10) break;
            }
        }


    }
}
