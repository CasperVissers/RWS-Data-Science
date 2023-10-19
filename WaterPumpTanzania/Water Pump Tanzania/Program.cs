using CsvHelper;
using System.Globalization;

namespace Water_Pump_Tanzania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data_Reader.WaterPumpCsv.CreateCombinedCsv();

            //Load sample data
            var sampleData = new PumpMaintenanceModel.ModelInput()
            {
                Amount_tsh = 25F,
                Gps_height = 686F,
                Basin = @"Pangani",
                Population = 250F,
                Public_meeting = true,
                Permit = true,
                Construction_year = 2009F,
                Extraction_type_class = @"Gravity",
                Management_group = @"UserGroup",
                Water_quality = @"Soft",
                Quantity_group = @"Enough",
                Source_type = @"Dam",
                Waterpoint_type_group = @"CommunalStandpipe",
            };

            //Load model and predict output
            var result = PumpMaintenanceModel.Predict(sampleData).PredictedLabel;

        }
    }
}