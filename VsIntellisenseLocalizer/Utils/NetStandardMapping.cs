namespace VsIntellisenseLocalizer.Utils
{
    public class NetStandardModel
    {
        public string Version { get; set; }
        public string Target { get; set; }
    }
    public class NetStandardMapping
    {
        private static List<NetStandardModel> _netStandardMappings;

        public static List<NetStandardModel> NetStandardMappings
        {
            get
            {
                return _netStandardMappings ??= new List<NetStandardModel>
                {
                    new()
                    {
                        Version = "1.0.0",
                        Target = "netstandard1.0"
                    },
                    new()
                    {
                        Version = "1.1.0",
                        Target = "netstandard1.1"
                    },
                    new()
                    {
                        Version = "1.2.0",
                        Target = "netstandard1.2"
                    },
                    new()
                    {
                        Version = "1.3.0",
                        Target = "netstandard1.3"
                    },
                    new()
                    {
                        Version = "1.4.0",
                        Target = "netstandard1.4"
                    },
                    new()
                    {
                        Version = "1.5.0",
                        Target = "netstandard1.5"
                    },
                    new()
                    {
                        Version = "1.6.0",
                        Target = "netstandard1.6"
                    },
                    new()
                    {
                        Version = "2.0.0",
                        Target = "netstandard2.0"
                    },
                    new()
                    {
                        Version = "2.1.0",
                        Target = "netstandard2.1"
                    }
                };
            }
        }
    }
}
