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
        public Basin Basin { get; set; }

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
        public Extraction ExtractionType { get; set; }

        /// <summary>
        /// The kind of extraction the waterpoint uses
        /// </summary>
        public Extraction ExtractionTypeGroup { get; set; }

        /// <summary>
        /// The kind of extraction the waterpoint uses
        /// </summary>
        public Extraction ExtractionTypeClass { get; set; } 

        /// <summary>
        /// How the waterpoint is managed
        /// </summary>
        public Management Management { get; set; }

        /// <summary>
        /// How the waterpoint is managed
        /// </summary>
        public ManagementGroup ManagementGroup { get; set; }

        /// <summary>
        /// What the water costs
        /// </summary>
        public Payment Payment { get; set; }

        /// <summary>
        /// What the water costs
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// The quality of the water
        /// </summary>
        public WaterQuality WaterQuality { get; set; }

        public Quality QualityGroup { get; set; }

        /// <summary>
        /// <summary>
        /// The quantity of water
        /// </summary>
        public Quantity Quantity { get; set; }

        /// <summary>
        /// The quantity of water
        /// </summary>
        public Quantity QuantityGroup { get; set; }

        /// <summary>
        /// The source of the water
        /// </summary>
        public Source Source { get; set; }
        
        /// <summary>
        /// The source of the water
        /// </summary>
        public Source SourceType { get; set; }

        /// <summary>
        /// The source of the water
        /// </summary>
        public SourceClass SourceClass { get; set; }

        /// <summary>
        /// The kind of waterpoint
        /// </summary>
        public Waterpoint WaterpointType { get; set; }
        
        /// <summary>
        /// The kind of waterpoint
        /// </summary>
        public Waterpoint WaterpointTypeGroup { get; set; }
    }
}
