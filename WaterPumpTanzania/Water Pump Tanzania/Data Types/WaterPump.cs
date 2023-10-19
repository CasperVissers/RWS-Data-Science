using CsvHelper.Configuration.Attributes;

namespace Water_Pump_Tanzania
{
    internal class WaterPump : Interfaces.IWaterPump
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("amount_tsh")]
        public double AmountTsh { get;  set;  }
        [Name("date_recorded")]
        public DateTime DateRecorded { get;  set; }
        [Name("funder")]
        public string? Funder { get;  set; }
        [Name("gps_height")]
        public int GpsHeight { get;  set; }
        [Name("installer")]
        public string? Installer { get;  set; }
        [Name("longitude")]
        public double Longitude { get;  set; }
        [Name("latitude")]
        public double Latitude { get;  set; }
        [Name("wpt_name")]
        public string? WptName { get;  set; }
        [Name("num_private")]
        public int NumPrivate { get;  set; }
        [Name("basin")]
        public string? Basin { get;  set; }
        [Name("subvillage")]
        public string? Subvillage { get;  set; }
        [Name("region")]
        public string? Region { get;  set; }
        [Name("region_code")]
        public int RegionCode { get;  set; }
        [Name("district_code")]
        public int DistrictCode { get;  set; }
        [Name("lga")]
        public string? Lga { get;  set; }
        [Name("ward")]
        public string? Ward { get;  set; }
        [Name("population")]
        public int Population { get;  set; }
        [Name("public_meeting")]
        public string? PublicMeeting { get;  set; }
        [Name("recorded_by")]
        public string? RecordedBy { get;  set; }
        [Name("scheme_management")]
        public string? SchemeManagement { get;  set; }
        [Name("scheme_name")]
        public string? SchemeName { get;  set; }
        [Name("permit")]
        public bool Permit { get;  set; }
        [Name("construction_year")]
        public int ConstructionYear { get;  set; }
        [Name("extraction_type")]
        public string? ExtractionType { get;  set; }
        [Name("extraction_type_group")]
        public string? ExtractionTypeGroup { get;  set; }
        [Name("extraction_type_class")]
        public string? ExtractionTypeClass { get;  set; }
        [Name("management")]
        public string? Management { get;  set; }
        [Name("management_group")]
        public string? ManagementGroup { get;  set; }
        [Name("payment")]
        public string? Payment { get;  set; }
        [Name("payment_type")]
        public string? PaymentType { get;  set; }
        [Name("water_quality")]
        public string? WaterQuality { get;  set; }
        [Name("quality_group")]
        public string? QualityGroup { get;  set; }
        [Name("quantity")]
        public string? Quantity { get;  set; }
        [Name("quantity_group")]
        public string? QuantityGroup { get;  set; }
        [Name("source")]
        public string? Source { get;  set; }
        [Name("source_type")]
        public string? SourceType { get;  set; }
        [Name("source_class")]
        public string? SourceClass { get;  set; }
        [Name("waterpoint_type")]
        public string? WaterpointType { get;  set; }
        [Name("waterpoint_type_group")]
        public string? WaterpointTypeGroup { get;  set; }
    }
}
