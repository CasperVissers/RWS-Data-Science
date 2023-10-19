using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water_Pump_Tanzania.Interfaces;

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
                if (HasUnknownData(r)) continue;
                if (HasZeroData(r)) continue;

                csvWriter.NextRecord();
                csvWriter.WriteRecord(new WaterPump(r, waterPumpSets));
            }
        }

        /// <summary>
        /// Checks whether one of the labels has an unknown value.
        /// </summary>
        /// <returns>True if one or more values have an unknown value.</returns>
        public static bool HasUnknownData(IWaterPumpLabels labels)
        {
            if (labels.Basin == Basin.Unknown) return true;
            if (labels.ExtractionType == Extraction.Unknown) return true;
            if (labels.ExtractionTypeGroup == Extraction.Unknown) return true;
            if (labels.ExtractionTypeClass == Extraction.Unknown) return true;
            if (labels.Management == Management.Unknown) return true;
            if (labels.ManagementGroup == ManagementGroup.Unknown) return true;
            if (labels.Payment == Payment.Unknown) return true;
            if (labels.PaymentType == PaymentType.Unknown) return true;
            if (labels.WaterQuality == WaterQuality.Unknown) return true;
            if (labels.QualityGroup == Quality.Unknown) return true;
            if (labels.Quantity == Quantity.Unknown) return true;
            if (labels.QuantityGroup == Quantity.Unknown) return true;
            if (labels.Source == Source.Unknown) return true;
            if (labels.SourceClass == SourceClass.Unknown) return true;
            if (labels.SourceType == Source.Unknown) return true;
            if (labels.WaterpointType == Waterpoint.Unknown) return true;
            if (labels.WaterpointTypeGroup == Waterpoint.Unknown) return true;
            return false;
        }

        /// <summary>
        /// Checks whether one of the numeric values is zero.
        /// </summary>
        /// <returns>True if one or more values are zero.</returns>
        public static bool HasZeroData(IWaterPumpLabels labels)
        {
            if (labels.AmountTsh == 0) return true;
            if (labels.GpsHeight == 0) return true;
            if (labels.Longitude == 0) return true;
            if (labels.Latitude == 0) return true;
            if (labels.Population == 0) return true;
            if (labels.ConstructionYear == 0) return true;
            return false;
        }
    }
}
