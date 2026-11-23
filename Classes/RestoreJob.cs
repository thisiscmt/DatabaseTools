using System.Text.Json.Serialization;

namespace DBTools
{
    public class RestoreJob : Job
    {
        public RestoreJob()
        {
            base.Type = JobTypes.Restore;
        }

        public override JobTypes Type
        {
            get
            {
                return base.Type;
            }
        }

        [JsonRequired]
        public int RestorePosition { get; set; }

        [JsonRequired]
        public bool ClearUsers { get; set; }

        [JsonRequired]
        public string FileExtension { get; set; }
    }
}
