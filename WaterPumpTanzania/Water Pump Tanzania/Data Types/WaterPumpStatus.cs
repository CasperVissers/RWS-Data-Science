using CsvHelper.Configuration.Attributes;

namespace Water_Pump_Tanzania
{
    internal class WaterPumpStatus : Interfaces.IWaterPumpStatus
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("status_group")]
        public string? StatusGroup { get; set; }
    }
}
