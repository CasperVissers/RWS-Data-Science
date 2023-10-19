using System.Reflection;
using Water_Pump_Tanzania.Interfaces;

namespace Water_Pump_Tanzania
{
    internal class WaterPump : IWaterPumpLabels, IWaterPumpSet
    {
        public WaterPump(IWaterPumpLabels waterPumpLabels, List<WaterPumpSet> waterPumpSets)
        {
            // Copy properties
            foreach (PropertyInfo property in typeof(IWaterPumpLabels).GetProperties())
            {
                property.SetValue(this, property.GetValue(waterPumpLabels, null), null);
            }
            foreach (PropertyInfo property in typeof(IWaterPumpId).GetProperties())
            {
                property.SetValue(this, property.GetValue(waterPumpLabels, null), null);
            }
            var waterPumpSet = waterPumpSets.Where(pump => pump.Id == waterPumpLabels.Id).FirstOrDefault();
            if (waterPumpSet != null)
            {
                StatusGroup = waterPumpSet.StatusGroup;
            }
        }

        public int Id { get; set; }
        public double AmountTsh { get; set; }
        public DateTime DateRecorded { get; set; }
        public string? Funder { get; set; }
        public int GpsHeight { get; set; }
        public string? Installer { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? WptName { get; set; }
        public int NumPrivate { get; set; }
        public string? Basin { get; set; }
        public string? Subvillage { get; set; }
        public string? Region { get; set; }
        public int RegionCode { get; set; }
        public int DistrictCode { get; set; }
        public string? Lga { get; set; }
        public string? Ward { get; set; }
        public int Population { get; set; }
        public string? PublicMeeting { get; set; }
        public string? RecordedBy { get; set; }
        public string? SchemeManagement { get; set; }
        public string? SchemeName { get; set; }
        public bool Permit { get; set; }
        public int ConstructionYear { get; set; }
        public string? ExtractionType { get; set; }
        public string? ExtractionTypeGroup { get; set; }
        public string? ExtractionTypeClass { get; set; }
        public string? Management { get; set; }
        public string? ManagementGroup { get; set; }
        public string? Payment { get; set; }
        public string? PaymentType { get; set; }
        public string? WaterQuality { get; set; }
        public string? QualityGroup { get; set; }
        public string? Quantity { get; set; }
        public string? QuantityGroup { get; set; }
        public string? Source { get; set; }
        public string? SourceType { get; set; }
        public string? SourceClass { get; set; }
        public string? WaterpointType { get; set; }
        public string? WaterpointTypeGroup { get; set; }
        public string? StatusGroup { get; set; }
    }
}
