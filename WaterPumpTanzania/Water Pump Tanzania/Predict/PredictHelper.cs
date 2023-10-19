using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water_Pump_Tanzania.Interfaces;

namespace Water_Pump_Tanzania.Predict
{
    public static class PredictHelper
    {
        /// <summary>
        /// Get the label names of the prediction model.
        /// </summary>
        public static string[] GetLabels()
        {
            var labelBuffer = new VBuffer<ReadOnlyMemory<char>>();
            PumpMaintenanceModel.PredictEngine.Value.OutputSchema["Score"].Annotations.GetValue("SlotNames", ref labelBuffer);
            return labelBuffer.DenseValues().Select(l => l.ToString()).ToArray();
        }

        /// <summary>
        /// Get the status labels of the prediction model.
        /// </summary>
        public static Status[] GetStatusLabels()
        {
            string[] labels = GetLabels();
            Status[] statusLabels = new Status[labels.Length];
            for(int i = 0; i < statusLabels.Length; i++)
            {
                if (Enum.TryParse(typeof(Status), labels[i], out var label))
                {
                    statusLabels[i] = (Status) label;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Unkown status {labels[i]}");
                }
            }
            return statusLabels;
        }

        /// <summary>
        /// Maps the pump data to an input model.
        /// </summary>
        public static PumpMaintenanceModel.ModelInput MapToInputModel(IWaterPumpLabels labels)
        {
            return new PumpMaintenanceModel.ModelInput()
            {
                Id = labels.Id,
                Amount_tsh = (float) labels.AmountTsh,
                Date_recorded = labels.DateRecorded,
                Funder = labels.Funder,
                Gps_height = labels.GpsHeight,
                Installer = labels.Installer,
                Longitude = (float)labels.Longitude,
                Latitude = (float)labels.Latitude,
                Wpt_name = labels.WptName,
                Num_private = labels.NumPrivate,
                Basin = labels.Basin.ToString(),
                Subvillage = labels.Subvillage,
                Region = labels.Region,
                Region_code = labels.RegionCode,
                District_code = labels.DistrictCode,
                Lga = labels.Lga,
                Ward = labels.Ward,
                Population = labels.Population,
                Public_meeting = labels.PublicMeeting,
                Recorded_by = labels.RecordedBy,
                Scheme_management = labels.SchemeManagement,
                Scheme_name = labels.SchemeName,
                Permit = labels.Permit,
                Construction_year = labels.ConstructionYear,
                Extraction_type = labels.ExtractionType.ToString(),
                Extraction_type_group = labels.ExtractionTypeGroup.ToString(),
                Extraction_type_class = labels.ExtractionTypeClass.ToString(),
                Management = labels.Management.ToString(),
                Management_group = labels.ManagementGroup.ToString(),
                Payment = labels.Payment.ToString(),
                Payment_type = labels.PaymentType.ToString(),
                Water_quality = labels.WaterQuality.ToString(),
                Quality_group = labels.QualityGroup.ToString(),
                Quantity = labels.Quantity.ToString(),
                Quantity_group = labels.QualityGroup.ToString(),
                Source = labels.Source.ToString(),
                Source_type = labels.SourceType.ToString(),
                Source_class = labels.SourceClass.ToString(),
                Waterpoint_type = labels.WaterpointType.ToString(),
                Waterpoint_type_group = labels.WaterpointTypeGroup.ToString(),
            };
        }
    }
}
