using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DBTools
{
    public class Job
    {
        public enum JobTypes
        {
            Backup = 0,
            Restore = 1,
            Shrink = 2,
            Copy = 3
        }

        public enum JobTasks
        {
            SingleDatabase = 0,
            AllUserDatabases = 1,
            AllSystemDatabases = 2,
            AllDatabases = 3,
            ByDirectory = 4,
            ByWildcard = 5,
            ZipFile = 6
        }

        public Job()
        {
        }

        public static List<string> GetTaskDescriptions(JobTypes jobType)
        {
            List<string> taskDescriptions = new List<string>();

            switch (jobType)
            {
                case JobTypes.Backup:
                case JobTypes.Shrink:
                    taskDescriptions.Add(JobTasks.SingleDatabase.TaskDescription());
                    taskDescriptions.Add(JobTasks.AllUserDatabases.TaskDescription());
                    taskDescriptions.Add(JobTasks.AllSystemDatabases.TaskDescription());
                    taskDescriptions.Add(JobTasks.AllDatabases.TaskDescription());
                    taskDescriptions.Add(JobTasks.ByWildcard.TaskDescription());
                    break;
                case JobTypes.Restore:
                    taskDescriptions.Add(JobTasks.SingleDatabase.TaskDescription());
                    taskDescriptions.Add(JobTasks.ByDirectory.TaskDescription());
                    taskDescriptions.Add(JobTasks.ZipFile.TaskDescription());
                    break;
            }

            return taskDescriptions;
        }

        public static JobTasks GetTaskValue(string desc)
        {
            JobTasks value = JobTasks.SingleDatabase;

            switch (desc)
            {
                case "Single database":
                    value = JobTasks.SingleDatabase;
                    break;
                case "All user databases":
                    value = JobTasks.AllUserDatabases;
                    break;
                case "All system databases":
                    value = JobTasks.AllSystemDatabases;
                    break;
                case "All databases":
                    value = JobTasks.AllDatabases;
                    break;
                case "By directory":
                    value = JobTasks.ByDirectory;
                    break;
                case "By wildcard":
                    value = JobTasks.ByWildcard;
                    break;
                case "Zip file":
                    value = JobTasks.ZipFile;
                    break;
            }

            return value;
        }

        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("database")]
        public string Database { get; set; }

        [XmlElement("type")]
        public virtual JobTypes Type { get; set; }

        [XmlElement("task")]
        public JobTasks Task { get; set; }

        [XmlElement("path")]
        public string Path { get; set; }
    }
}
