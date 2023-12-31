﻿using CsvHelper.Configuration.Attributes;
using System.Reflection;
using Water_Pump_Tanzania.Data_Reader;
using Water_Pump_Tanzania.Interfaces;

namespace Water_Pump_Tanzania
{
    internal class WaterPump : IWaterPumpLabels, IWaterPumpSet
    {
        public WaterPump(IWaterPumpLabels waterPumpLabels)
        {
            // Copy properties
            foreach (PropertyInfo property in typeof(IWaterPumpLabels).GetProperties().Where(p => p.CanWrite))
            {
                property.SetValue(this, property.GetValue(waterPumpLabels, null), null);
            }
            foreach (PropertyInfo property in typeof(IWaterPumpId).GetProperties().Where(p => p.CanWrite))
            {
                property.SetValue(this, property.GetValue(waterPumpLabels, null), null);
            }
            StatusGroup = WaterPumpCsv.GetWaterPumpStatus(Id);
        }

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
        public bool PublicMeeting { get; set; }
        [Name("recorded_by")]
        public string? RecordedBy { get; set; }
        [Name("scheme_management")]
        public string? SchemeManagement { get; set; }
        [Name("scheme_name")]
        public string? SchemeName { get; set; }
        [Name("permit")]
        public bool Permit { get; set; }
        [Name("construction_year")]
        public int ConstructionYear { get; set; }
        [Name("extraction_type")]
        public Extraction ExtractionType { get; set; }
        [Name("extraction_type_group")]
        public Extraction ExtractionTypeGroup { get; set; }
        [Name("extraction_type_class")]
        public Extraction ExtractionTypeClass { get; set; }
        [Name("management")]
        public Management Management { get; set; }
        [Name("management_group")]
        public ManagementGroup ManagementGroup { get; set; }
        [Name("payment")]
        public Payment Payment { get; set; }
        [Name("payment_type")]
        public PaymentType PaymentType { get; set; }
        [Name("water_quality")]
        public WaterQuality WaterQuality { get; set; }
        [Name("quality_group")]
        public Quality QualityGroup { get; set; }
        [Name("quantity")]
        public Quantity Quantity { get; set; }
        [Name("quantity_group")]
        public Quantity QuantityGroup { get; set; }
        [Name("source")]
        public Source Source { get; set; }
        [Name("source_type")]
        public Source SourceType { get; set; }
        [Name("source_class")]
        public SourceClass SourceClass { get; set; }
        [Name("waterpoint_type")]
        public Waterpoint WaterpointType { get; set; }
        [Name("waterpoint_type_group")]
        public Waterpoint WaterpointTypeGroup { get; set; }
        [Name("status_group")]
        public Status StatusGroup { get; set; }
    }
}
