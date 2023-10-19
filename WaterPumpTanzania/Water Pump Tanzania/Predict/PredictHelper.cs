using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
