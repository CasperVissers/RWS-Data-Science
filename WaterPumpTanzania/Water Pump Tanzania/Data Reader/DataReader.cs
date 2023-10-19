using CsvHelper;
using System.Globalization;

namespace Water_Pump_Tanzania.Data_Reader
{
    public static class DataReader
    {
        public static IEnumerable<T> ReadCsvData<T>(string path) where T : class
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<T>();
        }
    }
}
