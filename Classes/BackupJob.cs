using System.Collections.Generic;
using System.Xml.Serialization;

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

        [XmlElement("backup_type")]
        public BackupTypes BackupType { get; set; }

        [XmlElement("backup_option")]
        public BackupOverwriteOptions BackupOption { get; set; }
    }
}
