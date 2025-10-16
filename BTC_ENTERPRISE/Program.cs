namespace BTC_ENTERPRISE
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzk4NDE2MkAzMjM5MmUzMDJlMzAzYjMyMzkzYmk4QzNZdUlrVmdUclliT2VkRDFsZU0xcnJBeTQrN1JPMDB2MnNkYlJmOHM9"); //license for 29.1.33 version
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.MainDashboard());
        }
    }
}