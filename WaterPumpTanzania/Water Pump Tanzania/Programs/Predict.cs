using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water_Pump_Tanzania.Predict;

namespace Water_Pump_Tanzania.Programs
{
    internal static class Predict
    {
        public static void Run()
        {
            Console.WriteLine("Starting prediction program...");

            //Load sample data
            var sampleData = new PumpMaintenanceModel.ModelInput()
            {
                Amount_tsh = 25F,
                Gps_height = 686F,
                Basin = Basin.Rufiji.ToString(),
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
            var result = PumpMaintenanceModel.Predict(sampleData);


            var status = PredictHelper.GetStatusLabels();



            Console.WriteLine("Finished prediction program!");
        }


    }
}
