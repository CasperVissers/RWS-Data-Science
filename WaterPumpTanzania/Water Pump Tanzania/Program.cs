using CsvHelper;
using System.Globalization;

namespace Water_Pump_Tanzania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data_Reader.WaterPumpCsv.CreateCombinedCsv();
        }
    }
}