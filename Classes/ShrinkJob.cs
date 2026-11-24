using System.Text.Json.Serialization;

namespace DBTools
{
    public class ShrinkJob : Job
    {
        public ShrinkJob()
        {
            base.Type = JobTypes.Shrink;
        }

        public override JobTypes Type
        {
            get
            {
                return base.Type;
            }
        }

        [JsonRequired]
        public string RecoveryModel { get; set; }

        [JsonRequired]
        public bool SetToSimple { get; set; }

        [JsonRequired]
        public bool UpdateIndexes { get; set; }

        [JsonRequired]
        public bool ShrinkFile { get; set; }

        [JsonRequired]
        public string FileToShrink { get; set; }

        [JsonRequired]
        public string FileType { get; set; }
    }
}
