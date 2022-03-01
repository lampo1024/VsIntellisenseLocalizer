using VsIntellisenseLocalizer.Models;

namespace VsIntellisenseLocalizer.Utils
{
    public class InstalledNetFolderService
    {
        private static List<InstalledNetFolder> _installedNetFolders;

        public static List<InstalledNetFolder> InstalledNetFolders
        {
            get
            {
                return _installedNetFolders ??= new List<InstalledNetFolder>
                {
                    new InstalledNetFolder
                    {
                        Version = "3.1.x",
                        TargetName = "netcoreapp3.1"
                    },
                    new InstalledNetFolder
                    {
                        Version = "5.0",
                        TargetName = "net5.0"
                    },
                    new InstalledNetFolder
                    {
                        Version = "6.0",
                        TargetName = "net6.0"
                    }
                };
            }
        }

        public static InstalledNetFolder GetFolder(string version)
        {
            var folder = InstalledNetFolders.FirstOrDefault(x => version.StartsWith(x.Version));
            return folder;
        }
    }
}
