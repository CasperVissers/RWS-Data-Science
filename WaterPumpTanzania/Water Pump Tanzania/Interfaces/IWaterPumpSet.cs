namespace Water_Pump_Tanzania.Interfaces
{
    public interface IWaterPumpSet : IWaterPumpId
    {
        /// <summary>
        /// Whether the waterpump is functional
        /// </summary>
        public Status StatusGroup { get; set; }
    }
}
