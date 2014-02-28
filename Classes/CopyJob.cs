using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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

        [XmlElement("new_database")]
        public string NewDatabase { get; set; }
    }
}
