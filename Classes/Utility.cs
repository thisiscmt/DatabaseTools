using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Net;
using Ionic.Zip;

namespace DBTools
{
    internal static class Utility
    {
        private const string SMO_ERROR_PREFIX_1 = "System.Data.SqlClient.SqlError:";

        #region Public functions
        /// <summary>
        /// Formats a number of bytes into a more readable form.
        /// </summary>
        /// <param name="size">A number of bytes</param>
        /// <returns>A description of the size number in KB, MB, or GB, whichever best matches its value.</returns>
        public static string FormatSize(long size)
        {
            string sizeDesc = "";

            if (size < 1024)
            {
                sizeDesc = "1 KB";
            }
            else if (size >= 1024 && size < (1024 * 1024))
            {
                sizeDesc = Math.Round((Double)(size / 1024.0), 1, MidpointRounding.ToEven).ToString() + " KB";

            }
            else if (size >= (1024 * 1000) && size < (1024 * 1024 * 1024))
            {
                sizeDesc = Math.Round((Double) (size / (1024.0 * 1024.0)), 1, MidpointRounding.ToEven).ToString() + " MB";
            }
            else
            {
                sizeDesc = Math.Round((Double)(size / (1024.0 * 1024.0 * 1024.0)), 1, MidpointRounding.ToEven).ToString() + " GB";
            }

            return sizeDesc;
        }

        public static string GenerateListItemKey()
        {
            return Guid.NewGuid().ToString();
        }

        public static string AbbreviatePath(string path, int maxLength)
        {
            string newPath;

            if (path.Length <= maxLength)
            {
                newPath = path;
            }
            else
            {
                // To shorten the path we remove the part for the file's parent 
                // directory. We need to check for a UNC path since we may only 
                // want to take the first two chars to build the new path rather 
                // than the first three for a regular drive root
                if (path.StartsWith("\\"))
                {
                    newPath = "\\\\...\\" + Path.GetFileName(path);
                }
                else
                {
                    newPath = path.Substring(0, 3) + "...\\" + Path.GetFileName(path);
                }

                if (newPath.Length > maxLength)
                {
                    newPath = newPath.Substring(0, maxLength);
                }
            }

            return newPath;
        }
        
        /// <summary>
        /// Check if the application is running on the current database server.
        /// </summary>
        /// <returns>True if the local machine is the server, False otherwise.</returns>
        public static bool RunningOnServer()
        {
            IPHostEntry host;
            bool retVal = false;
            string server = Program.CurrentServer.Name.ToLower();
            string localMachine = Environment.MachineName.ToLower();
            string localIP = "";

            // Remove the instance name if there is one
            if (server.Contains("\\"))
            {
                server = server.Substring(0, server.IndexOf('\\'));
            }

            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            
            if (server == localMachine ||
                server == localIP ||
                server == "(local)" || 
                server == "localhost" || 
                server == "127.0.0.1" || 
                server == "::1")
            {
                retVal = true;
            }

            return retVal;
        }

        public static string BrowseForFileOpen(string extension, string filter, string fileName = "", bool fileExists = true)
        {
            OpenFileDialog openDialog = null;
            string filePath = "";

            try
            {
                openDialog = new OpenFileDialog();
                openDialog.DefaultExt = extension;
                openDialog.Filter = filter;
                openDialog.Title = "Open File";
                openDialog.CheckFileExists = fileExists;
                openDialog.CheckPathExists = true;
                openDialog.ShowReadOnly = false;
                openDialog.FileName = fileName;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openDialog.FileName;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (openDialog != null)
                {
                    openDialog.Dispose();
                }
            }

            return filePath;
        }

        public static string BrowseForFileSave(string extension, string filter, string defaultFile = "", string defaultDir = "")
        {
            SaveFileDialog saveDialog = null;
            string filePath = "";

            try
            {
                saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = extension;
                saveDialog.Filter = filter;
                saveDialog.Title = "Save File";
                saveDialog.CheckFileExists = false;
                saveDialog.CheckPathExists = false;
                saveDialog.FileName = defaultFile;

                if (defaultDir != "")
                {
                    saveDialog.InitialDirectory = defaultDir;
                }

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveDialog.FileName;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (saveDialog != null)
                {
                    saveDialog.Dispose();
                }
            }

            return filePath;
        }

        public static string ExtractFilesFromZipArchive(string filePath)
        {
            ZipFile zip;
            string tempPath;

            tempPath = Path.Combine(Environment.SystemDirectory.Substring(0, 3), Path.GetRandomFileName());

            using (zip = new ZipFile(filePath))
            {
                zip.Encryption = EncryptionAlgorithm.None;
                zip.ExtractAll(tempPath, ExtractExistingFileAction.OverwriteSilently);
            }

            return tempPath;
        }

        public static void RunJobsSilently(string jobFilePath)
        {
            JobEngine jobEngine;
            JobList jobList;
            string msg;
            string dbName = "";
            bool success;

            try
            {
                if (!File.Exists(jobFilePath))
                {
                    Utility.WriteToSystemLog("", "Unable to find file '" + jobFilePath + "'. No jobs have been run.");
                    return;
                }

                jobEngine = new JobEngine(Program.CurrentServer, Program.CurrentUser);
                jobList = GetJobList(jobFilePath);

                if (jobList != null)
                {
                    foreach (Job job in jobList.Jobs)
                    {
                        dbName = job.Database;
                        success = false;

                        switch (job.Type)
                        {
                            case Job.JobTypes.Backup:
                                success = jobEngine.RunBackupJob((BackupJob)job);
                                break;
                            case Job.JobTypes.Restore:
                                success = jobEngine.RunRestoreJob((RestoreJob)job);
                                break;
                            case Job.JobTypes.Shrink:
                                success = jobEngine.RunShrinkJob((ShrinkJob)job);
                                break;
                            case Job.JobTypes.Copy:
                                success = jobEngine.RunCopyJob((CopyJob)job);
                                break;
                        }

                        if (success)
                        {
                            if (job.Type == Job.JobTypes.Copy)
                            {
                                msg = job.Type.ToString() + " job for database '" + job.Database + "' was completed successfully.";
                            }
                            else
                            {
                                msg = job.Type.ToString() + " job with task '" + job.Task.TaskDescription() + "' for database '" + job.Database + "' was completed successfully.";
                            }

                            jobEngine.AddToJobTracker(msg);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (jobEngine.Error)
                    {
                        Utility.WriteToSystemLog("", jobEngine.GetJobTracker());
                    }
                    else
                    {
                        msg = "Database jobs in file '" + jobFilePath + "' were completed successfully.";
                        Utility.ShowMessage(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    msg = ex.Message;
                }
                else
                {
                    msg = ex.Message + Environment.NewLine + ex.InnerException.Message;
                }

                Utility.WriteToSystemLog(dbName, msg);
            }
        }

        public static JobList GetJobList(string filePath)
        {
            StreamReader sr = null;
            XmlSerializer xs;
            JobList jobList = null;

            try
            {
                sr = new StreamReader(filePath);
                xs = new XmlSerializer(typeof(JobList), new Type[] { typeof(BackupJob), typeof(RestoreJob), typeof(ShrinkJob), typeof(CopyJob) });
                jobList = (JobList)xs.Deserialize(sr);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
            }

            return jobList;
        }

        public static string BuildMessage(Exception ex)
        {
            bool done = false;
            string retVal = ex.Message;
            Exception innerEx = ex.InnerException;

            // Build a string that contains all exception messages in the call stack
            do
            {
                if (innerEx != null)
                {
                    retVal = retVal + Environment.NewLine + innerEx.Message;
                    innerEx = innerEx.InnerException;
                }
                else
                {
                    done = true;
                }
            }
            while (!done);

            return retVal;
        }

        public static void WriteToSystemLog(string dbName, string msg)
        {
            try
            {
                RunWriteToSystemLog(dbName, new List<string> { msg });
            }
            catch (Exception ex)
            {
                HandleException("Program", "WriteToSystemLog", ex.Source, ex.Message, ex.InnerException);
            }
        }

        public static void WriteToSystemLog(string dbName, IEnumerable<string> msgs)
        {
            try
            {
                RunWriteToSystemLog(dbName, msgs);
            }
            catch (Exception ex)
            {
                HandleException("Program", "WriteToSystemLog", ex.Source, ex.Message, ex.InnerException);
            }
        }

        public static string StripPrefixes(string msg)
        {
            string retVal = msg;

            try
            {
                if (msg.StartsWith(SMO_ERROR_PREFIX_1))
                {
                    retVal = msg.Replace(SMO_ERROR_PREFIX_1, "").Trim();
                }

                return retVal;
            }
            catch (Exception ex)
            {
                HandleException("Program", "StripPrefixes", ex.Source, ex.Message, ex);
            }

            return msg;
        }

        public static void LockControl(Control ctl)
        {
            ctl.Enabled = false;

            if (ctl is TextBox || ctl is ComboBox)
            {
                ctl.BackColor = SystemColors.ButtonFace;
            }
        }

        public static void UnlockControl(Control ctl)
        {
            ctl.Enabled = true;

            if (ctl is TextBox || ctl is ComboBox)
            {
                ctl.BackColor = SystemColors.Window;
            }
        }

        public static string AppendSeparator(string path)
        {
            if (path.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                return path;
            }
            else
            {
                return path + Path.DirectorySeparatorChar;
            }
        }

        public static void ShowMessage(string msg)
        {
            if (Program.SilentExecution)
            {
                WriteToSystemLog("", StripPrefixes(msg));
            }
            else
            {
                MessageBox.Show(StripPrefixes(msg), Program.MAIN_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void ShowError(string msg)
        {
            if (Program.SilentExecution)
            {
                WriteToSystemLog("", StripPrefixes(msg));
            }
            else
            {
                MessageBox.Show(StripPrefixes(msg), Program.ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void HandleException(string modName, string procedure, string source, string desc, Exception ex = null, bool showMsgBox = true)
        {
            string msg;

            try
            {
                msg = "An application error occurred, the error information is as follows:" + Environment.NewLine + System.Environment.NewLine;
                msg = msg + "Module: " + modName + Environment.NewLine;
                msg = msg + "Procedure: " + procedure + Environment.NewLine;
                msg = msg + "Source: " + source + Environment.NewLine + Environment.NewLine;

                if (ex == null)
                {
                    msg = msg + "Error Description: " + StripPrefixes(desc);
                }
                else
                {
                    msg = msg + "Error Description: " + StripPrefixes(desc) + Environment.NewLine + Environment.NewLine;
                    msg = msg + StripPrefixes(ex.Message);
                }

                if (showMsgBox && !Program.SilentExecution)
                {
                    MessageBox.Show(msg, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (procedure != "WriteToSystemLog")
                {
                    WriteToSystemLog("", msg);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Private functions
        private static void RunWriteToSystemLog(string dbName, IEnumerable<string> msgs)
        {
            TextWriter sysLog = null;
            string[] subStrs;
            string newMsg;

            try
            {
                if (msgs.Count() > 0)
                {
                    if (File.Exists(Program.UserDataPath + "\\" + Program.SYSTEM_LOG_FILE))
                    {
                        sysLog = File.AppendText(Program.UserDataPath + "\\" + Program.SYSTEM_LOG_FILE);
                    }
                    else
                    {
                        sysLog = File.CreateText(Program.UserDataPath + "\\" + Program.SYSTEM_LOG_FILE);
                    }

                    foreach (string msg in msgs)
                    {
                        newMsg = msg.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
                        subStrs = newMsg.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

                        for (int i = 0; i < subStrs.Length; i++)
                        {
                            sysLog.Write(DateTime.Now.ToString("M/d/yyyy h:mm tt") + ". ");
                            sysLog.WriteLine(StripPrefixes(subStrs[i]));
                        }
                    }

                    if (!string.IsNullOrEmpty(dbName))
                    {
                        sysLog.Write(DateTime.Now.ToString("M/d/yyyy h:mm tt") + ". ");
                        sysLog.WriteLine(string.Format("Database processed: {0}", dbName));
                    }

                    sysLog.WriteLine("--------------------");
                }
            }
            catch (Exception ex)
            {
                HandleException("Program", "RunWriteToSystemLog", ex.Source, ex.Message, ex);
            }
            finally
            {
                if (sysLog != null)
                {
                    sysLog.Dispose();
                }
            }
        }
        #endregion
    }
}
