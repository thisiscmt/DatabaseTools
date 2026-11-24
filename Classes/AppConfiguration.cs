using System.Text.Json.Serialization;

namespace DBTools
{
    public class AppConfiguration
    {
        public AppConfiguration() {
            UserID = "";
            Server = "";
            Authentication = "";
            MaxMRULength = 0;
            SaveOnExit = "";
            MRUJobFiles = [];
        }

        [JsonRequired]
        public string UserID { get; set; }

        [JsonRequired]
        public string Server { get; set; }

        [JsonRequired]
        public string Authentication { get; set; }

        [JsonRequired]
        public int MaxMRULength { get; set; }

        [JsonRequired]
        public string SaveOnExit { get; set; }

        [JsonRequired]
        public string[] MRUJobFiles { get; set; }
    }
}
