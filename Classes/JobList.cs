using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DBTools
{
    [XmlRoot("job_list")]
    public class JobList
    {
        public JobList()
        {
            this.Jobs = new List<Job>();
        }

        [XmlElement("jobs")]
        public List<Job> Jobs { get; set; }
    }
}
