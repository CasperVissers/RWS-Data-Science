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

        private static List<WaterPumpSet> WaterPumpSets
        {
            get
            {
                _waterPummpSets ??= DataReader.ReadCsvToList<WaterPumpSet>(WATER_PUMP_SET_PATH);
                return _waterPummpSets;
            }
        }
        private static List<WaterPumpSet> _waterPummpSets;


        public static void CreateCombinedCsv()
        {
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
                // Check for incomplete data
                if (HasUnknownData(r)) continue;
                if (HasZeroData(r)) continue;
                if (HasNullOrEmptyStringData(r)) continue;

                /// Check for non functional pump
                var waterpump = new WaterPump(r);
                if (IsNonfunctionalWaterpump(waterpump)) continue;

                // Write to output
                csvWriter.NextRecord();
                csvWriter.WriteRecord(waterpump);
            }
        }

        /// <summary>
        /// Checks whether one of the labels has an unknown value.
        /// </summary>
        /// <returns>True if one or more values have an unknown value.</returns>
        public static bool HasUnknownData(IWaterPumpLabels labels)
        {
            if (labels.Basin == Basin.Unknown) return true;
            //if (labels.ExtractionType == Extraction.Unknown) return true;
            //if (labels.ExtractionTypeGroup == Extraction.Unknown) return true;
            if (labels.ExtractionTypeClass == Extraction.Unknown) return true;
            if (labels.Management == Management.Unknown) return true;
            //if (labels.ManagementGroup == ManagementGroup.Unknown) return true;
            //if (labels.Payment == Payment.Unknown) return true;
            //if (labels.PaymentType == PaymentType.Unknown) return true;
            if (labels.WaterQuality == WaterQuality.Unknown) return true;
            //if (labels.QualityGroup == Quality.Unknown) return true;
            //if (labels.Quantity == Quantity.Unknown) return true;
            if (labels.QuantityGroup == Quantity.Unknown) return true;
            //if (labels.Source == Source.Unknown) return true;
            //if (labels.SourceClass == SourceClass.Unknown) return true;
            if (labels.SourceType == Source.Unknown) return true;
            //if (labels.WaterpointType == Waterpoint.Unknown) return true;
            if (labels.WaterpointTypeGroup == Waterpoint.Unknown) return true;
            return false;
        }

        /// <summary>
        /// Checks whether one of the numeric values is zero.
        /// </summary>
        /// <returns>True if one or more values are zero.</returns>
        public static bool HasZeroData(IWaterPumpLabels labels)
        {
            //if (labels.AmountTsh == 0) return true;
            if (labels.GpsHeight == 0) return true;
            //if (labels.Longitude == 0) return true;
            //if (labels.Latitude == 0) return true;
            if (labels.Population == 0) return true;
            if (labels.ConstructionYear == 0) return true;
            return false;
        }

        /// <summary>
        /// Checks wheter one of the string fields is null or empty.
        /// </summary>
        /// <returns>True if one or more fields are null or zero</returns>
        public static bool HasNullOrEmptyStringData(IWaterPumpLabels labels)
        {
            //if (string.IsNullOrEmpty(labels.Funder)) return true;
            //if (string.IsNullOrEmpty(labels.Installer)) return true;
            //if (string.IsNullOrEmpty(labels.WptName)) return true;
            //if (string.IsNullOrEmpty(labels.Subvillage)) return true;
            //if (string.IsNullOrEmpty(labels.Region)) return true;
            //if (string.IsNullOrEmpty(labels.Lga)) return true;
            //if (string.IsNullOrEmpty(labels.Ward)) return true;
            //if (string.IsNullOrEmpty(labels.RecordedBy)) return true;
            //if (string.IsNullOrEmpty(labels.SchemeManagement)) return true;
            //if (string.IsNullOrEmpty(labels.SchemeName)) return true;
            return false;
        }

        /// <summary>
        /// Check wheter the waterpump is nonfunctional.
        /// </summary>
        /// <returns>True if the pump is non funcitonal</returns>
        public static bool IsNonfunctionalWaterpump(IWaterPumpSet labels)
        {
            return labels.StatusGroup == Status.NonFunctional;
        }

        /// <summary>
        /// Get a waterpump label based on the provided id.
        /// </summary>
        /// <exception cref="KeyNotFoundException">When no waterpump with the given id is found.</exception>
        public static WaterPumpLabels GetWaterPumpLabelById(int id)
        {
            // Create reader objects
            using var reader = new StreamReader(WATER_PUMP_LABELS_PATH);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            // Read CSV file
            var records = csvReader.GetRecords<WaterPumpLabels>();

            // Search for id.
            foreach(var r in records)
            {
                if (r.Id == id) return r;
            }

            throw new KeyNotFoundException($"Waterpump with ID {id} cannot be found!");
        }

        /// <summary>
        /// Gets the current state of a waterpump.
        /// </summary>
        /// <exception cref="KeyNotFoundException">When no waterpump with the given id is found.</exception>
        public static Status GetWaterPumpStatus(int id)
        {
            var waterPump = WaterPumpSets.Where(pump => pump.Id == id).FirstOrDefault();
            if (waterPump != null) return waterPump.StatusGroup;
            throw new KeyNotFoundException($"Waterpump with ID {id} cannot be found!");
        }
    }
}
