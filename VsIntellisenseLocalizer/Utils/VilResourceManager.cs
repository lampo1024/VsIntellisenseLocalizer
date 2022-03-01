using System.Globalization;
using System.Resources;

namespace VsIntellisenseLocalizer.Utils
{
    public class VilResourceManager
    {
        public static ResourceManager ResManager;
        private static string _currentLanguage = "en";
        private static CultureInfo _cultureInfo;
        public static void InitLocalize()
        {
            ChangeLocalize();
        }

        public static void ChangeLocalize()
        {
            _currentLanguage = VilSettings.Default.CurrentLocale;
            _cultureInfo = new CultureInfo(_currentLanguage);
            ResManager = new ResourceManager("VsIntellisenseLocalizer.LocalizeResources.Resource", typeof(frmMain).Assembly);
        }

        public static string GetResource(string resourceName)
        {
            return ResManager.GetString(resourceName, _cultureInfo);
        }
        public static T GetResource<T>(string resourceName)
        {
            return (T)ResManager.GetObject(resourceName, _cultureInfo);
        }
    }
}
