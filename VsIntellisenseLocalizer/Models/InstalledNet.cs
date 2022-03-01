namespace VsIntellisenseLocalizer.Models
{
    public class InstalledNet
    {
        public string VersionName => new DirectoryInfo(FullFolderName).Name;
        public string FullFolderName { get; set; }
    }
}
