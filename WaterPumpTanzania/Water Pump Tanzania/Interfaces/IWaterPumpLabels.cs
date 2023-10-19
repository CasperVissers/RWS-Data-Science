using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Pump_Tanzania.Interfaces
{
    internal interface IWaterPumpLabels : IWaterPumpId
    {
        /// <summary>
        /// Total static head (amount water available to waterpoint)
        /// </summary>
        public double AmountTsh { get; set; }
        /// <summary>
        /// The date the row was entered
        /// </summary>
        public DateTime DateRecorded { get; set; }
        /// <summary>
        /// Who funded the well
        /// </summary>
        public string? Funder { get; set; }
        /// <summary>
        /// Altitude of the well
        /// </summary>
        public int GpsHeight { get; set; }
        /// <summary>
        /// Organization that installed the well
        /// </summary>
        public string? Installer { get; set; }
        /// <summary>
        /// GPS coordinate 
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// GPS coordinate 
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Name of the waterpoint if there is one
        /// </summary>
        public string? WptName { get; set; }
        public int NumPrivate { get; set; }
        /// <summary>
        /// Geographic water basin
        /// </summary>
        public string? Basin { get; set; }
        /// <summary>
        /// Geographic location
        /// </summary>
        public string? Subvillage { get; set; }
        /// <summary>
        /// Geographic location
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// Geographic location (coded)
        /// </summary>
        public int RegionCode { get; set; }
        /// <summary>
        /// Geographic location (coded)
        /// </summary>
        public int DistrictCode { get; set; }
        /// <summary>
        /// Geographic location
        /// </summary>
        public string? Lga { get; set; }
        /// <summary>
        /// Geographic location
        /// </summary>
        public string? Ward { get; set; }
        /// <summary>
        /// Population around the well
        /// </summary>
        public int Population { get; set; }
        public string? PublicMeeting { get; set; }
        /// <summary>
        /// Group entering this row of data
        /// </summary>
        public string? RecordedBy { get; set; }
        /// <summary>
        /// Who operates the waterpoint
        /// </summary>
        public string? SchemeManagement { get; set; }
        /// <summary>
        /// Who operates the waterpoint
        /// </summary>
        public string? SchemeName { get; set; }
        /// <summary>
        /// If the waterpoint is permitted
        /// </summary>
        public bool? Permit { get; set; }
        /// <summary>
        /// Year the waterpoint was constructed
        /// </summary>
        public int ConstructionYear { get; set; }
        /// <summary>
        /// The kind of extraction the waterpoint uses
        /// </summary>
        public string? ExtractionType { get; set; }
        /// <summary>
        /// The kind of extraction the waterpoint uses
        /// </summary>
        public string? ExtractionTypeGroup { get; set; }
        /// <summary>
        /// The kind of extraction the waterpoint uses
        /// </summary>
        public string? ExtractionTypeClass { get; set; }
        /// <summary>
        /// How the waterpoint is managed
        /// </summary>
        public string? Management { get; set; }
        /// <summary>
        /// How the waterpoint is managed
        /// </summary>
        public string? ManagementGroup { get; set; }
        /// <summary>
        /// What the water costs
        /// </summary>
        public string? Payment { get; set; }
        /// <summary>
        /// What the water costs
        /// </summary>
        public string? PaymentType { get; set; }
        /// <summary>
        /// The quality of the water
        /// </summary>
        public string? WaterQuality { get; set; }
        /// <summary>
        /// The quality of the water
        /// </summary>
        public string? QualityGroup { get; set; }
        /// <summary>
        /// The quantity of water
        /// </summary>
        public string? Quantity { get; set; }
        /// <summary>
        /// The quantity of water
        /// </summary>
        public string? QuantityGroup { get; set; }
        /// <summary>
        /// The source of the water
        /// </summary>
        public string? Source { get; set; }
        /// <summary>
        /// The source of the water
        /// </summary>
        public string? SourceType { get; set; }
        /// <summary>
        /// The source of the water
        /// </summary>
        public string? SourceClass { get; set; }
        /// <summary>
        /// The kind of waterpoint
        /// </summary>
        public string? WaterpointType { get; set; }
        /// <summary>
        /// The kind of waterpoint
        /// </summary>
        public string? WaterpointTypeGroup { get; set; }
    }
}
