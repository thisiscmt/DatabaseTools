using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.SqlServer.Management.Smo;

namespace DBTools
{
    internal class JobEngine
    {
        private Server m_server;
        private User m_user;
        private Backup m_backup;
        private Restore m_restore;
        private List<string> m_jobTracker;
        private Job.JobTypes m_curJobType;
        private bool m_error;
        private bool m_cancel;
        private string m_curDatabase;

        public delegate void JobProgressEventHandler(object sender, JobEventArgs e);
        public event JobProgressEventHandler JobProgress;

        #region Constructor
        public JobEngine(Server server, User user)
        {
            this.m_server = server;
            this.m_user = user;
            this.m_jobTracker = new List<string>();
            this.m_error = false;
            this.m_cancel = false;
            this.m_curDatabase = "";
            this.m_backup = new Backup();
            this.m_backup.PercentCompleteNotification = 2;
            this.m_backup.PercentComplete += new PercentCompleteEventHandler(m_backup_PercentComplete);
            this.m_restore = new Restore();
            this.m_restore.PercentCompleteNotification = 2;
            this.m_restore.PercentComplete += new PercentCompleteEventHandler(m_restore_PercentComplete);
        }
        #endregion

        #region Methods
        public bool RunBackupJob(BackupJob job)
        {
            JobEventArgs jobEventArgs;
            string msg;
            string searchStr;
            string frontPart;
            string backPart;
            int mark;
            bool okToBackUp;
            bool backupOccurred = false;

            jobEventArgs = new JobEventArgs();
            jobEventArgs.Action = JobEventArgs.StatusAction.SetProgressMax;
            jobEventArgs.Maximum = 100;
            RaiseJobProgressEvent(jobEventArgs);
            this.m_curJobType = Job.JobTypes.Backup;

            if (job.Task == Job.JobTasks.SingleDatabase)
            {
                jobEventArgs.Action = JobEventArgs.StatusAction.MessageAndClearProgress;
                jobEventArgs.Message = "Backing up database '" + job.Database + "' ...";
                RaiseJobProgressEvent(jobEventArgs);
                this.m_curDatabase = job.Database;

                if (!BackupDatabase(job.Database, 
                                    job.Path, 
                                    job.BackupType, 
                                    job.BackupOption))
                {
                    return false;
                }
            }
            else
            {
                foreach (Database db in this.m_server.Databases)
                {
                    okToBackUp = false;

                    switch (job.Task)
                    {
                        case Job.JobTasks.AllUserDatabases:
                            if (!db.IsSystemObject)
                            {
                                okToBackUp = true;
                            }

                            break;
                        case Job.JobTasks.AllSystemDatabases:
                            if (db.IsSystemObject)
                            {
                                okToBackUp = true;
                            }

                            break;
                        case Job.JobTasks.AllDatabases:
                            okToBackUp = true;
                            break;
                        case Job.JobTasks.ByWildcard:
                            if (job.Database.StartsWith("*"))
                            {
                                searchStr = ".*" + job.Database.Substring(1, job.Database.Length - 1) + "$";
                            }
                            else if (job.Database.EndsWith("*"))
                            {
                                searchStr = "^" + job.Database.Substring(0, job.Database.Length - 1) + ".*";
                            }
                            else if (job.Database.Contains('*'))
                            {
                                // The user isn't allowed to input a search string 
                                // on the backup form with more than one wildcard, 
                                // so we don't have to worry about that here
                                mark = job.Database.IndexOf('*');

                                frontPart = job.Database.Substring(0, mark);
                                backPart = job.Database.Substring(mark + 1, job.Database.Length - mark -1);
                                searchStr = "^" + frontPart + "(.*)" + backPart + "$";
                            }
                            else
                            {
                                searchStr = "^" + job.Database + "$";
                            }

                            if (Regex.IsMatch(db.Name, searchStr, RegexOptions.IgnoreCase))
                            {
                                okToBackUp = true;
                            }

                            break;
                    }

                    if (okToBackUp)
                    {
                        jobEventArgs.Action = JobEventArgs.StatusAction.MessageAndClearProgress;
                        jobEventArgs.Message = "Backing up database '" + db.Name + "' ...";
                        RaiseJobProgressEvent(jobEventArgs);
                        backupOccurred = true;
                        this.m_curDatabase = db.Name;

                        if (!BackupDatabase(db.Name, 
                                            Path.Combine(job.Path, db.Name + ".bak"),
                                            job.BackupType, 
                                            job.BackupOption))
                        {
                            return false;
                        }
                    }
                }

                if (!backupOccurred)
                {
                    msg = "No backups occurred because no databases were found matching the conditions of the backup job." + Environment.NewLine;
                    msg = msg + "Backup task: " + job.Task.TaskDescription();

                    if (job.Task == Job.JobTasks.ByWildcard)
                    {
                        msg = Environment.NewLine + msg + "Search string: " + job.Database;
                    }

                    Utility.WriteToSystemLog("", msg);
                }
            }

            return true;
        }

        public bool RunRestoreJob(RestoreJob job)
        {
            JobEventArgs jobEventArgs;
            string dirPath;

            jobEventArgs = new JobEventArgs();
            jobEventArgs.Action = JobEventArgs.StatusAction.SetProgressMax;
            jobEventArgs.Maximum = 100;
            RaiseJobProgressEvent(jobEventArgs);
            this.m_curJobType = Job.JobTypes.Restore;

            if (job.Task == Job.JobTasks.SingleDatabase)
            {
                jobEventArgs.Action = JobEventArgs.StatusAction.MessageAndClearProgress;
                jobEventArgs.Message = "Restoring database '" + job.Database + "' ...";
                RaiseJobProgressEvent(jobEventArgs);
                this.m_curDatabase = job.Database;

                if (!RestoreDatabase(job.Database, job.Path, job.RestorePosition))
                {
                    return false;
                }

                if (job.ClearUsers)
                {
                    if (!ClearDBUsers(job.Database))
                    {
                        return false;
                    }
                }
            }
            else
            {
                switch (job.Task)
                {
                    case Job.JobTasks.ByDirectory:
                        if (!RunRestoreByDirectory(job.Path, job.FileExtension, job.ClearUsers))
                        {
                            return false;
                        }

                        break;
                    case Job.JobTasks.ZipFile:
                        dirPath = Utility.ExtractFilesFromZipArchive(job.Path);

                        if (!RunRestoreByDirectory(dirPath, job.FileExtension, job.ClearUsers))
                        {
                            return false;
                        }

                        Directory.Delete(dirPath, true);
                        break;
                }
            }

            return true;
        }

        public bool RunShrinkJob(ShrinkJob job)
        {
            JobEventArgs jobEventArgs;
            string msg;
            string searchStr;
            string frontPart;
            string backPart;
            int mark;
            bool okToShrink;
            bool shrinkOccurred = false;

            jobEventArgs = new JobEventArgs();
            jobEventArgs.Action = JobEventArgs.StatusAction.SetProgressMax;
            jobEventArgs.Maximum = 100;
            RaiseJobProgressEvent(jobEventArgs);
            this.m_curJobType = Job.JobTypes.Shrink;

            if (job.Task == Job.JobTasks.SingleDatabase)
            {
                jobEventArgs.Action = JobEventArgs.StatusAction.MessageAndClearProgress;
                jobEventArgs.Message = "Shrinking database '" + job.Database + "' ...";
                RaiseJobProgressEvent(jobEventArgs);
                this.m_curDatabase = job.Database;
                
                if (!ShrinkDatabase(job.Database, job.FileToShrink, job.FileType, job.SetToSimple, job.UpdateIndexes))
                {
                    return false;
                }
            }
            else
            {
                foreach (Database db in this.m_server.Databases)
                {
                    okToShrink = false;

                    switch (job.Task)
                    {
                        case Job.JobTasks.AllUserDatabases:
                            if (!db.IsSystemObject)
                            {
                                okToShrink = true;
                            }

                            break;
                        case Job.JobTasks.AllSystemDatabases:
                            if (db.IsSystemObject)
                            {
                                okToShrink = true;
                            }

                            break;
                        case Job.JobTasks.AllDatabases:
                            okToShrink = true;
                            break;
                        case Job.JobTasks.ByWildcard:
                            if (job.Database.StartsWith("*"))
                            {
                                searchStr = ".*" + job.Database.Substring(1, job.Database.Length - 1) + "$";
                            }
                            else if (job.Database.EndsWith("*"))
                            {
                                searchStr = "^" + job.Database.Substring(0, job.Database.Length - 1) + ".*";
                            }
                            else if (job.Database.Contains('*'))
                            {
                                // The user isn't allowed to input a search string 
                                // on the shrink form with more than one wildcard, 
                                // so we don't have to worry about that here
                                mark = job.Database.IndexOf('*');

                                frontPart = job.Database.Substring(0, mark);
                                backPart = job.Database.Substring(mark + 1, job.Database.Length - mark - 1);
                                searchStr = "^" + frontPart + "(.*)" + backPart + "$";
                            }
                            else
                            {
                                searchStr = "^" + job.Database + "$";
                            }

                            if (Regex.IsMatch(db.Name, searchStr, RegexOptions.IgnoreCase))
                            {
                                okToShrink = true;
                            }

                            break;
                    }

                    if (okToShrink)
                    {
                        jobEventArgs.Action = JobEventArgs.StatusAction.MessageAndClearProgress;
                        jobEventArgs.Message = "Shrinking database '" + db.Name + "' ...";
                        RaiseJobProgressEvent(jobEventArgs);
                        shrinkOccurred = true;
                        this.m_curDatabase = db.Name;

                        if (!ShrinkDatabase(db.Name, "", "", job.SetToSimple, job.UpdateIndexes))
                        {
                            return false;
                        }
                    }

                    if (this.m_cancel)
                    {
                        msg = "The shrink of database '" + db.Name + "' did not complete due to the following error:" + Environment.NewLine + Environment.NewLine;
                        msg = msg + "The operation was cancelled by the user.";
                        Utility.WriteToSystemLog("", msg);
                        return false;
                    }
                }

                if (!shrinkOccurred)
                {
                    msg = "No shrinks occurred because no databases were found matching the conditions of the shrink job." + Environment.NewLine;
                    msg = msg + "Shrink task: " + job.Task.TaskDescription();

                    if (job.Task == Job.JobTasks.ByWildcard)
                    {
                        msg = Environment.NewLine + msg + "Search string: " + job.Database;
                    }

                    Utility.WriteToSystemLog("", msg);
                }
            }

            return true;
        }

        public bool RunCopyJob(CopyJob job)
        {
            JobEventArgs jobEventArgs = new JobEventArgs();

            jobEventArgs.Action = JobEventArgs.StatusAction.SetProgressMax;
            jobEventArgs.Maximum = 100;
            RaiseJobProgressEvent(jobEventArgs);
            jobEventArgs.Action = JobEventArgs.StatusAction.MessageAndClearProgress;
            jobEventArgs.Message = "Copying database '" + job.Database + "' ...";
            RaiseJobProgressEvent(jobEventArgs);

            this.m_curJobType = Job.JobTypes.Copy;
            this.m_curDatabase = job.Database;
            return CopyDatabase(job.Database, job.NewDatabase);
        }

        public void AddToJobTracker(string msg)
        {
            this.m_jobTracker.Add(msg);
        }

        public IEnumerable<string> GetJobTracker()
        {
            return this.m_jobTracker;
        }

        public void SetErrorFlag()
        {
            this.m_error = true;
        }
        #endregion

        #region Events
        private void m_backup_PercentComplete(Object sender, PercentCompleteEventArgs e)
        {
            if (this.m_cancel)
            {
                this.m_backup.Abort();
            }
            else
            {
                JobEventArgs jobEventArgs = new JobEventArgs();
                jobEventArgs.JobType = this.m_curJobType;
                jobEventArgs.Action = JobEventArgs.StatusAction.IncrementProgress;

                if (jobEventArgs.JobType == Job.JobTypes.Copy)
                {
                    jobEventArgs.Percent = (int)(e.Percent / 2);
                }
                else
                {
                    jobEventArgs.Percent = e.Percent;
                }

                RaiseJobProgressEvent(jobEventArgs);
            }
        }

        private void m_restore_PercentComplete(Object sender, PercentCompleteEventArgs e)
        {
            if (this.m_cancel)
            {
                this.m_restore.Abort();
            }
            else
            {
                JobEventArgs jobEventArgs = new JobEventArgs();
                jobEventArgs.JobType = this.m_curJobType;
                jobEventArgs.Action = JobEventArgs.StatusAction.IncrementProgress;

                if (jobEventArgs.JobType == Job.JobTypes.Copy)
                {
                    jobEventArgs.Percent = 50 + (int)(e.Percent / 2);
                }
                else
                {
                    jobEventArgs.Percent = e.Percent;
                }

                RaiseJobProgressEvent(jobEventArgs);
            }
        }

        #endregion

        #region Private functions
        private bool BackupDatabase(string dbName, string filePath, BackupJob.BackupTypes backupType, 
                                    BackupJob.BackupOverwriteOptions overwriteOpt)
        {
            string sql;
            string retVal = "";

            // If xp_cmdshell is enabled, try to verify the specified directory
            // exists on the server
            if (this.m_server.Configuration.XPCmdShellEnabled.RunValue == 1)
            {
                sql = "exec xp_cmdshell 'chdir \"" + Path.GetDirectoryName(filePath) + "\"'";
                retVal = this.m_server.ConnectionContext.ExecuteScalar(sql).ToString();

                if (retVal != "")
                {
                    sql = "exec xp_cmdshell 'mkdir \"" + Path.GetDirectoryName(filePath) + "\"'";
                    retVal = this.m_server.ConnectionContext.ExecuteScalar(sql).ToString();
                }
            }
    
            this.m_backup.Database = dbName;
            this.m_backup.Devices.Clear();
            this.m_backup.Devices.AddDevice(filePath, DeviceType.File);
            this.m_backup.BackupSetName = dbName + " backup";
            
            if (backupType == BackupJob.BackupTypes.TransactionLog)
            {
                this.m_backup.Action = BackupActionType.Log;
            }
            else
            {
                this.m_backup.Action = BackupActionType.Database;
            }

            if (overwriteOpt == BackupJob.BackupOverwriteOptions.Append)
            {
                this.m_backup.Initialize = false;
            }
            else
            {
                this.m_backup.Initialize = true;
            }

            this.m_backup.SqlBackup(this.m_server);
            return true;
        }

        private bool RestoreDatabase(string dbName, string backupFilePath, int position)
        {
            DataTable fileList = null;
            DataFile df;
            LogFile lf;
            string defaultDataPath;
            string defaultLogPath;
            string dataFileName;
            string dataFilePath;
            string logFileName;
            string logFilePath;
            int dataInc = 1;
            int logInc = 1;
            int numDataFiles = 1;
            int numLogFiles = 1;
            bool retVal = false;

            try
            {
                this.m_restore.Database = dbName;
                this.m_restore.Action = RestoreActionType.Database;
                this.m_restore.ReplaceDatabase = true;
                this.m_restore.RelocateFiles.Clear();
                this.m_restore.Devices.Clear();
                this.m_restore.Devices.AddDevice(backupFilePath, DeviceType.File);
                this.m_restore.FileNumber = position;

                if (this.m_server.Settings.DefaultFile == "")
                {
                    defaultDataPath = this.m_server.Information.MasterDBPath;
                }
                else
                {
                    defaultDataPath = this.m_server.Settings.DefaultFile;
                }

                if (this.m_server.Settings.DefaultLog == "")
                {
                    defaultLogPath = this.m_server.Information.MasterDBLogPath;
                }
                else
                {
                    defaultLogPath = this.m_server.Settings.DefaultLog;
                }

                fileList = this.m_restore.ReadFileList(this.m_server);

                foreach (DataRow dr in fileList.Rows)
                {
                    if (dr["Type"].ToString() == "D")
                    {
                        dataFileName = dr["LogicalName"].ToString();

                        if (numDataFiles == 1)
                        {
                            dataFilePath = Path.Combine(defaultDataPath, dbName + ".mdf");
                        }
                        else
                        {
                            dataFilePath = Path.Combine(defaultDataPath, dbName + "_" + dataInc.ToString() + ".ndf");
                            dataInc += 1;
                        }

                        this.m_restore.RelocateFiles.Add(new RelocateFile(dataFileName, dataFilePath));
                        numDataFiles += 1;
                    }
                    else
                    {
                        logFileName = dr["LogicalName"].ToString();

                        if (numLogFiles == 1)
                        {
                            logFilePath = Path.Combine(defaultLogPath, dbName + "_log.ldf");
                        }
                        else
                        {
                            logFilePath = Path.Combine(defaultLogPath, dbName + "_log_" + logInc.ToString() + ".ldf");
                            logInc += 1;
                        }

                        this.m_restore.RelocateFiles.Add(new RelocateFile(logFileName, logFilePath));
                        numLogFiles += 1;
                    }
                }

                this.m_server.Databases.Refresh();
                if (this.m_server.Databases[dbName] != null)
                {
                    this.m_server.Databases[dbName].Drop();
                }

                this.m_restore.SqlRestore(this.m_server);
                this.m_server.Databases.Refresh();

                // Change logical file names so they match the actual database 
                // name, if needed
                for (int i = 0; i < this.m_server.Databases[dbName].FileGroups[0].Files.Count; i++)
                {
                    df = this.m_server.Databases[dbName].FileGroups[0].Files[i];

                    if (!df.Name.Contains(dbName))
                    {
                        df.Rename(Path.GetFileNameWithoutExtension(df.FileName));
                    }
                }
                for (int i = 0; i < this.m_server.Databases[dbName].LogFiles.Count; i++)
                {
                    lf = this.m_server.Databases[dbName].LogFiles[i];

                    if (!lf.Name.Contains(dbName))
                    {
                        lf.Rename(Path.GetFileNameWithoutExtension(lf.FileName));
                    }
                }
                
                retVal = true;
            }
            catch
            {
                this.m_error = true;
                throw;
            }
            finally
            {
                if (fileList != null)
                {
                    fileList.Dispose();
                }
            }

            return retVal;
        }

        private bool ShrinkDatabase(string dbName, string diskFile, string fileType, bool setToSimple, bool updateIndexes)
        {
            Database db;
            DataFile df;
            LogFile lf;
            JobEventArgs jobEventArgs;
            string backupFilePath;
            double rawSize;
            int size;

            if (this.m_server.Databases[dbName].RecoveryModel != RecoveryModel.Simple)
            {
                backupFilePath = "";
                BackupDatabase(dbName, 
                               backupFilePath, 
                               BackupJob.BackupTypes.TransactionLog, 
                               BackupJob.BackupOverwriteOptions.Overwrite);

            }

            if (string.IsNullOrEmpty(diskFile))
            {
                db = this.m_server.Databases[dbName];
                db.Shrink(10, ShrinkMethod.Default);
            }
            else
            {
                if (fileType == "Data")
                {
                    df = this.m_server.Databases[dbName].FileGroups[this.m_server.Databases[dbName].DefaultFileGroup].Files[diskFile];
                    rawSize = df.UsedSpace + (df.UsedSpace * 0.1);
                    size = (int)Math.Round(rawSize / 1024, 0);
                    df.Shrink(size, ShrinkMethod.Default);
                }
                else if (fileType == "Log")
                {
                    lf = this.m_server.Databases[dbName].LogFiles[diskFile];
                    rawSize = lf.UsedSpace + (lf.UsedSpace * 0.1);
                    size = (int)Math.Round(rawSize / 1024, 0);
                    lf.Shrink(size, ShrinkMethod.Default);
                }
                else
                {
                    return true;
                }
            }                

            if (updateIndexes)
            {
                jobEventArgs = new JobEventArgs();
                jobEventArgs.Action = JobEventArgs.StatusAction.MessageOnly;
                jobEventArgs.Message = "Updating indexes in database '" + dbName + "' ...";
                RaiseJobProgressEvent(jobEventArgs);
                
                UpdateIndexes(dbName);
            }

            return true;
        }

        private bool CopyDatabase(string sourceDBName, string destDBName)
        {
            string backupFilePath = "";
            string sql;
            bool retVal = false;

            try
            {
                backupFilePath = Path.Combine(this.m_server.Settings.BackupDirectory, sourceDBName + "_DT_" + DateTime.Now.ToString("yyyyMMddhhmmss"));

                if (!BackupDatabase(sourceDBName, 
                                    backupFilePath, 
                                    BackupJob.BackupTypes.Complete, 
                                    BackupJob.BackupOverwriteOptions.Overwrite))
                {
                    return retVal;
                }

                if (!RestoreDatabase(destDBName, backupFilePath, 1))
                {
                    return retVal;
                }

                retVal = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (this.m_server.Configuration.XPCmdShellEnabled.RunValue == 1 && backupFilePath != "")
                {
                    try
                    {
                        sql = "exec xp_cmdshell 'del \"" + backupFilePath + "\"'";
                        this.m_server.ConnectionContext.ExecuteScalar(sql);
                    }
                    catch (Exception ex)
                    {
                        Utility.WriteToSystemLog(sourceDBName, ex.Message);
                    }
                }
            }

            return retVal;
        }

        private bool ClearDBUsers(string dbName)
        {
            Database db = this.m_server.Databases[dbName];

            for (int i = 0; i < db.Users.Count; i++)
            {
                if (!db.Users[i].IsSystemObject && 
                    db.Users[i].Name.ToLower() != "guest" && 
                    db.Users[i].Name.ToLower() != "sa" && 
                    db.Users[i].Name.ToUpper() != "INFORMATION_SCHEMA")
                {
                    db.Users[i].Drop();
                }
            }

            return true;
        }

        private bool RunRestoreByDirectory(string dirPath, string fileExtension, bool clearUsers)
        {
            JobEventArgs jobEventArgs;
            string[] fileList;
            string dbName;
            string searchStr;

            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                searchStr = "*.*";
            }
            else
            {
                searchStr = "*." + fileExtension;
            }

            fileList = Directory.GetFiles(dirPath, searchStr, SearchOption.TopDirectoryOnly);
            jobEventArgs = new JobEventArgs();

            for (var i = 0; i < fileList.Length; i++)
            {
                dbName = Path.GetFileNameWithoutExtension(fileList[i]);
                jobEventArgs.Action = JobEventArgs.StatusAction.MessageAndClearProgress;
                jobEventArgs.Message = "Restoring database '" + dbName + "' ...";
                RaiseJobProgressEvent(jobEventArgs);
                this.m_curDatabase = dbName;

                if (!RestoreDatabase(dbName, fileList[i], 1))
                {
                    return false;
                }

                if (clearUsers)
                {
                    if (!ClearDBUsers(dbName))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void UpdateIndexes(string dbName)
        {
            Database db = this.m_server.Databases[dbName];
            DataTable dt = null;
            float fragPercentage;

            foreach (Table table in db.Tables)
            {
                foreach (Index idx in table.Indexes)
                {
                    idx.OnlineIndexOperation = true;
                    dt = idx.EnumFragmentation();
                    fragPercentage = float.Parse(dt.Rows[0]["AverageFragmentation"].ToString());

                    // If index fragmentation is less than or equal to 30%, 
                    // reorganize the index, otherwise rebuild it
                    if (fragPercentage <= 30)
                    {
                        idx.Reorganize();
                    }
                    else
                    {
                        idx.Rebuild();
                    }
                }
            }

            if (dt != null)
            {
                dt.Dispose();
            }
        }

        private void RaiseJobProgressEvent(JobEventArgs e)
        {
            var handler = this.JobProgress;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Properties
        public bool Error
        {
            get
            {
                return this.m_error;
            }
        }

        public bool Cancel
        {
            get
            {
                return this.m_cancel;
            }
            set
            {
                this.m_cancel = value;
            }
        }

        public string CurrentDatabase
        {
            get
            {
                return this.m_curDatabase;
            }
        }
        #endregion
    }
}
