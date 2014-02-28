namespace DBTools
{
    internal static class ExtensionMethods
    {
        public static string TaskDescription(this Job.JobTasks e)
        {
            string retVal;

            switch (e)
            {
                case Job.JobTasks.SingleDatabase:
                    retVal = "Single database";
                    break;
                case Job.JobTasks.AllUserDatabases:
                    retVal = "All user databases";
                    break;
                case Job.JobTasks.AllSystemDatabases:
                    retVal = "All system databases";
                    break;
                case Job.JobTasks.AllDatabases:
                    retVal = "All databases";
                    break;
                case Job.JobTasks.ByDirectory:
                    retVal = "By directory";
                    break;
                case Job.JobTasks.ByWildcard:
                    retVal = "By wildcard";
                    break;
                case Job.JobTasks.ZipFile:
                    retVal = "Zip file";
                    break;
                default:
                    retVal = "";
                    break;
            }

            return retVal;
        }
    }
}
