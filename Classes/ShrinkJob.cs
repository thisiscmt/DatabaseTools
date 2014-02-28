using System.Collections.Generic;
using System.Xml.Serialization;

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

        [XmlElement("recovery_model")]
        public string RecoveryModel { get; set; }

        [XmlElement("set_to_simple")]
        public bool SetToSimple { get; set; }

        [XmlElement("update_indexes")]
        public bool UpdateIndexes { get; set; }

        [XmlElement("shrink_file")]
        public bool ShrinkFile { get; set; }

        [XmlElement("file_to_shrink")]
        public string FileToShrink { get; set; }

        [XmlElement("file_type")]
        public string FileType { get; set; }
    }
}
