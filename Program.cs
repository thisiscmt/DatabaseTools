using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Nini.Config;

// Icons used in this application are from www.famfamfam.com

namespace DBTools
{
    static class Program
    {
        private static frmMain m_mainForm;

        #region Constants
        public const string SYSTEM_LOG_FILE = "dbtools.log";
        public const string MAIN_CAPTION = "Database Tools";
        public const string ERROR_CAPTION = "Alert";
        private const string CONFIG_FILE = "dbtools.ini";
        #endregion

        #region Main function
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] cmdArgs;
            string argName;
            string argValue;
            Dictionary<string, string> argsDict;
            bool missingArgs = false;
            int mark;

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ApplicationPath = System.Windows.Forms.Application.StartupPath;
                UserDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Properties.Settings.Default.AppDataFolder);

                if (!Directory.Exists(UserDataPath))
                {
                    Directory.CreateDirectory(UserDataPath);
                }
                if (!File.Exists(UserDataPath + "\\" + CONFIG_FILE))
                {
                    File.CreateText(UserDataPath + "\\" + CONFIG_FILE).Close();
                }

                ConfigFile = new IniConfigSource(UserDataPath + "\\" + CONFIG_FILE);
                ConfigFile.CaseSensitive = false;
                CurrentServer = new Server();
                CurrentUser = new User();

                // See if the proper command line switches are present for 
                // executing a job file silently
                cmdArgs = Environment.GetCommandLineArgs();
                if (cmdArgs.Length > 1)
                {
                    argsDict = new Dictionary<string, string>();

                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        mark = cmdArgs[i].IndexOf(':');
                        argName = cmdArgs[i].Substring(0, mark);
                        argValue = cmdArgs[i].Substring(mark + 1, cmdArgs[i].Length - mark - 1);
                        argsDict.Add(argName, argValue);
                    }

                    if (argsDict.ContainsKey("/jobfile") && argsDict.ContainsKey("/server"))
                    {
                        CurrentUser.Authentication = User.AuthenticationType.Windows;

                        if (argsDict.ContainsKey("/auth") && argsDict["/auth"].ToLower() == "sql")
                        {
                            if (argsDict.ContainsKey("/user") && argsDict.ContainsKey("/password"))
                            {
                                CurrentUser.Authentication = User.AuthenticationType.SQL;
                                CurrentUser.UserID = argsDict["/user"];
                                CurrentUser.Password = argsDict["/password"];
                            }
                            else
                            {
                                Utility.WriteToSystemLog("", "Missing a SQL user name or password from the command line. No jobs have been run.");
                                missingArgs = true;
                            }
                        }

                        if (!missingArgs)
                        {
                            SilentExecution = true;
                            CurrentUser.Server = argsDict["/server"];
                            ServerUtility.ConnectToServer(CurrentUser);
                            Utility.RunJobsSilently(argsDict["/jobfile"]);
                        }

                        return;
                    }
                }

                m_mainForm = new frmMain();

                if (!m_mainForm.Unload)
                {
                    m_mainForm.Show();

                    if (ShowLoginForm(true))
                    {
                        m_mainForm.Initialize(Program.CurrentUser.Server);
                        Application.Run(m_mainForm);
                    }
                    else
                    {
                        m_mainForm.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("Program", "Main", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Global functions
        public static bool ShowLoginForm(bool firstLogin = false)
        {
            frmLogin loginForm = null;
            DialogResult result;
            bool retVal = false;

            using (loginForm = new frmLogin(firstLogin))
            {
                if (!loginForm.Unload)
                {
                    result = loginForm.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        retVal = true;
                    }
                }
            }

            return retVal;
        }

        public static User LoadLoginInfo()
        {
            User user = new User();
            IConfig mruSection = ConfigFile.Configs["MRU"];
            
            if (mruSection != null)
            {
                user.UserID = mruSection.GetString("UserID");
                user.Server = mruSection.GetString("Server");
                user.Authentication = (User.AuthenticationType)Enum.Parse(typeof(User.AuthenticationType), mruSection.GetString("Authentication"));
            }

            return user;
        }

        public static void SaveLoginInfo(User user)
        {
            IConfig mruSection = ConfigFile.Configs["MRU"];

            CurrentUser.Server = user.Server;

            if (mruSection == null)
            {
                mruSection = ConfigFile.Configs.Add("MRU");
            }

            if (user.Authentication == User.AuthenticationType.Windows)
            {
                CurrentUser.Authentication = User.AuthenticationType.Windows;
                CurrentUser.UserID = Environment.UserName;
                CurrentUser.Password = "";
                mruSection.Set("Authentication", User.AuthenticationType.Windows.ToString());
            }
            else
            {
                CurrentUser.Authentication = User.AuthenticationType.SQL;
                CurrentUser.UserID = user.UserID;
                CurrentUser.Password = user.Password;
                mruSection.Set("Authentication", User.AuthenticationType.SQL.ToString());
            }

            mruSection.Set("UserID", Program.CurrentUser.UserID);
            mruSection.Set("Server", Program.CurrentUser.Server);
            ConfigFile.Save();
        }
        #endregion

        #region Properties
        public static frmMain MainForm
        {
            get
            {
                return m_mainForm;
            }
        }

        public static string ApplicationPath { get; set; }
        public static string UserDataPath { get; set; }
        public static Server CurrentServer { get; set; }
        public static User CurrentUser { get; set; }
        public static string CurrentJobFile { get; set; }
        public static IniConfigSource ConfigFile { get; set; }
        public static bool SilentExecution { get; set; }
        #endregion
    }
}
