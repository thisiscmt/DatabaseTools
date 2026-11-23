using System.Text.Json.Serialization;

namespace DBTools
{
    public class BackupJob : Job
    {
        public enum BackupTypes
        {
            Complete = 0,
            TransactionLog = 1
        }

        public enum BackupOverwriteOptions
        {
            Append = 0,
            Overwrite = 1
        }

        public BackupJob()
        {
            base.Type = JobTypes.Backup;
        }

        public override JobTypes Type
        {
            get
            {
                return base.Type;
            }
        }

        [JsonRequired]
        public BackupTypes BackupType { get; set; }

        [JsonRequired]
        public BackupOverwriteOptions BackupOption { get; set; }

        [JsonRequired]
        public bool RollingBackups { get; set; }

        [JsonRequired]
        public int MaxBackups { get; set; }
    }
}
