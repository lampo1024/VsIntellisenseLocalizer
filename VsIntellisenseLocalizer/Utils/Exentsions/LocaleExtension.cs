namespace VsIntellisenseLocalizer.Utils.Exentsions
{
    public static class LocaleExtension
    {
        public static string Locale(this string resource)
        {
            return VilResourceManager.GetResource(resource);
        }

        public static string Locale(this string resource, params object[] param)
        {
            return VilResourceManager.GetResource(resource, param);
        }
    }
}
