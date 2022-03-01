using VsIntellisenseLocalizer.Utils;

namespace VsIntellisenseLocalizer
{
    public static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VilResourceManager.InitLocalize();
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}