using System.Text.RegularExpressions;

namespace VsIntellisenseLocalizer.Models
{
    public class IntelliSenseFile
    {
        public IntelliSenseFile()
        {
            TargetVersionList = new List<string>();
            Resources = new List<DownloadResource>();
        }
        public string Version { get; set; }
        public List<string> TargetVersionList { get; set; }
        public List<DownloadResource> Resources { get; set; }
    }

    public class DownloadResource
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string FileName => Path.GetFileName(new Uri(Url).AbsolutePath);
        public string FileNameWithoutExt => Path.GetFileNameWithoutExtension(FileName);

        public string Lang
        {
            get
            {
                var pattern = @"dotnet-intellisense-.*?-(.*?)$";
                return Regex.Match(FileNameWithoutExt, pattern).Groups[1].Value;
            }
        }
    }
}