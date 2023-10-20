﻿namespace Water_Pump_Tanzania.Programs
{
    internal static class PrepairData
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Starting prepair data program...");

            Data_Reader.WaterPumpCsv.CreateCombinedCsv();

            Console.WriteLine("Finished prepair data program! Press enter to continue.");
            Console.ReadLine();
        }
    }
}
