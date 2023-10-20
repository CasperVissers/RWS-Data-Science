namespace Water_Pump_Tanzania.Programs
{
    internal static class Startup
    {
        public enum Programs
        {
            Prepair = 1,
            Predict = 2,

            Exit = 0,
        }

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Choice a program to run (enter 0, 1 or 2):");
            Console.WriteLine($"\t{(int)Programs.Exit}) {Programs.Exit} - To prepair the data.");
            Console.WriteLine($"\t{(int)Programs.Prepair}) {Programs.Prepair} - To prepair the data.");
            Console.WriteLine($"\t{(int)Programs.Predict}) {Programs.Predict} - To make a prediction.");
            switch(Console.ReadLine())
            {
                case "0":
                    return;
                case "1":
                    PrepairData.Run();
                    break;
                case "2":
                    Predict.Run(); 
                    break;
            }
            Run();
        }
    }
}
