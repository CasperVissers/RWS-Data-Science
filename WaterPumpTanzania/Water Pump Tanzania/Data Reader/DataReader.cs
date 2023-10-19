using CsvHelper;
using System.Globalization;

namespace Water_Pump_Tanzania.Data_Reader
{
    public static class DataReader
    {
        /// <summary>
        /// Reads CSV data to a list.
        /// </summary>
        /// <returns></returns>
        public static List<T> ReadCsvToList<T>(string path)
        {
            // Create reader objects
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            // Read CSV file
            var records = csv.GetRecords<T>();

            // Copy data to list
            List<T> values = new();
            foreach (var r in records)
            {
                values.Add(r);
            }
            return values;
        }
    }
}
