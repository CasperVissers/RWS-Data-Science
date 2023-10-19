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
        const string WATER_PUMP_PATH = "C:\\Users\\Caspe\\Csharp\\RWS\\Data Science Assignment\\WaterPumpTanzania\\Water Pump Tanzania\\_files\\data_scientist\\water_pump.csv";

        public static void CreateCombinedCsv()
        {
            var waterPumpSets = DataReader.ReadCsvToList<WaterPumpSet>(WATER_PUMP_SET_PATH);

            // Create reader objects
            using var reader = new StreamReader(WATER_PUMP_LABELS_PATH);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            // Read CSV file
            var records = csvReader.GetRecords<WaterPumpLabels>();

            // Create writer objects
            using var writer = new StreamWriter(WATER_PUMP_PATH);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            
            // Create header
            csvWriter.WriteHeader<WaterPump>();

            // output
            foreach (var r in records)
            {
                csvWriter.NextRecord();
                csvWriter.WriteRecord(new WaterPump(r, waterPumpSets));
            }
        }
    }
}
