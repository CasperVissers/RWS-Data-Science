using CsvHelper.Configuration.Attributes;
using System.Security.AccessControl;
using Water_Pump_Tanzania.Interfaces;

namespace Water_Pump_Tanzania
{
    internal class WaterPumpLabels : IWaterPumpLabels
    {
        [Name("id")]
        public int Id { get; set; }

        [Name("amount_tsh")]
        public double AmountTsh { get; set; }

        [Name("date_recorded")]
        public DateTime DateRecorded { get; set; }

        [Name("funder")]
        public string? Funder { get; set; }

        [Name("gps_height")]
        public int GpsHeight { get; set; }

        [Name("installer")]
        public string? Installer { get; set; }

        [Name("longitude")]
        public double Longitude { get; set; }

        [Name("latitude")]
        public double Latitude { get; set; }

        [Name("wpt_name")]
        public string? WptName { get; set; }

        [Name("num_private")]
        public int NumPrivate { get; set; }

        [Name("basin")]
        public string? BasinSetter
        {
            set => Basin = StringToEnum.ToBasin(value);
        }
        [Ignore]
        public Basin Basin { get; set; }

        [Name("subvillage")]
        public string? Subvillage { get; set; }

        [Name("region")]
        public string? Region { get; set; }

        [Name("region_code")]
        public int RegionCode { get; set; }

        [Name("district_code")]
        public int DistrictCode { get; set; }

        [Name("lga")]
        public string? Lga { get; set; }

        [Name("ward")]
        public string? Ward { get; set; }

        [Name("population")]
        public int Population { get; set; }

        [Name("public_meeting")]
        public string? PublicMeeting { get; set; }

        [Name("recorded_by")]
        public string? RecordedBy { get; set; }

        [Name("scheme_management")]
        public string? SchemeManagement { get; set; }

        [Name("scheme_name")]
        public string? SchemeName { get; set; }

        [Name("permit")]
        public bool? Permit { get; set; }

        [Name("construction_year")]
        public int ConstructionYear { get; set; }

        [Name("extraction_type")]
        public string? ExtractionTypeSetter
        {
            set => ExtractionType = StringToEnum.ToExtraction(value);
        }
        [Ignore]
        public Extraction ExtractionType { get; set; }

        [Name("extraction_type_group")]
        public string? ExtractionTypeGroupSetter
        {
            set => ExtractionTypeGroup = StringToEnum.ToExtraction(value);
        }
        [Ignore]
        public Extraction ExtractionTypeGroup { get; set; }

        [Name("extraction_type_class")]
        public string? ExtractionTypeClassSetter
        {
            set => ExtractionTypeClass = StringToEnum.ToExtraction(value);
        }
        [Ignore]
        public Extraction ExtractionTypeClass { get; set; }

        [Name("management")]
        public string? ManagementSetter
        {
            set => Management = StringToEnum.ToManagement(value);
        }
        [Ignore]
        public Management Management { get; set; }

        [Name("management_group")]
        public string? ManagementGroupSetter
        {
            set => ManagementGroup = StringToEnum.ToManagementGroup(value);
        }
        [Ignore]
        public ManagementGroup ManagementGroup { get; set; }

        [Name("payment")]
        public string? PaymentSetter
        {
            set => Payment = StringToEnum.ToPayment(value);
        }
        [Ignore]
        public Payment Payment { get; set; }

        [Name("payment_type")]
        public string? PaymentTypeSetter
        {
            set => PaymentType = StringToEnum.ToPaymentType(value);
        }
        [Ignore]
        public PaymentType PaymentType { get; set; }

        [Name("water_quality")]
        public string? WaterQualitySetter
        {
            set => WaterQuality = StringToEnum.ToWaterQuality(value);
        }
        [Ignore]
        public WaterQuality WaterQuality { get; set; }

        [Name("quality_group")]
        public string? QualityGroupSetter
        {
            set => QualityGroup = StringToEnum.ToQuality(value);
        }
        [Ignore]
        public Quality QualityGroup { get; set; }

        [Name("quantity")]
        public string? QuantitySetter
        {
            set => Quantity = StringToEnum.ToQuantity(value);
        }
        [Ignore]
        public Quantity Quantity { get; set; }

        [Name("quantity_group")]
        public string? QuantityGroupSetter
        {
            set => QuantityGroup = StringToEnum.ToQuantity(value);
        }
        [Ignore]
        public Quantity QuantityGroup { get; set; }

        [Name("source")]
        public string? SourceSetter
        {
            set => Source = StringToEnum.ToSource(value);
        }
        [Ignore]
        public Source Source { get; set; }

        [Name("source_type")]
        public string? SourceTypeSetter
        {
            set => SourceType = StringToEnum.ToSource(value);
        }
        [Ignore]
        public Source SourceType { get; set; }

        [Name("source_class")]
        public string? SourceClassSetter
        {
            set => SourceClass = StringToEnum.ToSourceClass(value);
        }
        [Ignore]
        public SourceClass SourceClass { get; set; }

        [Name("waterpoint_type")]
        public string? WaterpointTypeSetter
        {
            set => WaterpointType = StringToEnum.ToWaterpoint(value);
        }
        [Ignore]
        public Waterpoint WaterpointType { get; set; }

        [Name("waterpoint_type_group")]
        public string? WaterpointTypeGroupSetter
        {
            set => WaterpointTypeGroup = StringToEnum.ToWaterpoint(value);
        }
        [Ignore]
        public Waterpoint WaterpointTypeGroup { get; set; }
    }
}
