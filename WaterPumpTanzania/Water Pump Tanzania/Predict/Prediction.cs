using Water_Pump_Tanzania.Interfaces;

namespace Water_Pump_Tanzania.Predict
{
    public class Prediction : IWaterPumpId
    {
        public Prediction(int id, int year, float[] scores)
        {
            Id = id;
            Year = year;
            Scores = scores;
        }

        public int Id { get; set;}
        public int Year { get; private set; }
        public float[] Scores { get; private set; }
    }
}
