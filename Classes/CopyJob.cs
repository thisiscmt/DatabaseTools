using System.Text.Json.Serialization;

namespace DBTools
{
    public class CopyJob : Job
    {
        public CopyJob()
        {
            base.Type = JobTypes.Copy;
        }

        public override JobTypes Type
        {
            get
            {
                return base.Type;
            }
        }

        [JsonRequired]
        public string NewDatabase { get; set; }
    }
}
