using System.Collections.Generic;
using System.Xml.Serialization;

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

        [XmlElement("restore_position")]
        public int RestorePosition { get; set; }

        [XmlElement("clear_users")]
        public bool ClearUsers { get; set; }

        [XmlElement("file_extension")]
        public string FileExtension { get; set; }
    }
}
