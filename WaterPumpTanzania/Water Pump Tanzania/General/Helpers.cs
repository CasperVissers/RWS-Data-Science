namespace Water_Pump_Tanzania
{
    internal static class Helpers
    {
        /// <summary>
        /// Gets the absolute path of a relative path.
        /// </summary>
        public static string GetAbsolutePath(string relativePath)
        {
            return Path.Combine(Environment.CurrentDirectory, relativePath);
        }
    }
}
