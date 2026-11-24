using Microsoft.SqlServer.Management.Smo;
using System.Text.Json;

namespace DBTools;

static class Program
{
    private static frmMain m_mainForm;

    #region Constants
    public const string SYSTEM_LOG_FILE = "dbtools.log";
    public const string CONFIG_FILE = "dbtools.json";
    public const string MAIN_CAPTION = "Database Tools";
    public const string ERROR_CAPTION = "Alert";

//    public static readonly JsonSerializerOptions ConfigFileSerializerOptions = new() { WriteIndented = true };
    #endregion

    #region Main function
    /// <summary>
    ///  The main entry point for the application.
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
            ApplicationConfiguration.Initialize();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ApplicationPath = Application.StartupPath;
            UserDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Database Tools");
            AppConfigFilePath = Path.Combine(UserDataPath, CONFIG_FILE);
            AppConfig = new();

            if (!Directory.Exists(UserDataPath))
            {
                Directory.CreateDirectory(UserDataPath);
            }

            if (File.Exists(AppConfigFilePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(AppConfigFilePath);
                    AppConfig = JsonSerializer.Deserialize<AppConfiguration>(jsonString);
                }
                catch
                {
                    AppConfig = new();
                }

            }
            else
            {
                AppConfig = new();
            }

            CurrentServer = new Server();
            CurrentUser = new User();

            // See if the proper command line switches are present for executing a job file silently
            cmdArgs = Environment.GetCommandLineArgs();
            if (cmdArgs.Length > 1)
            {
                argsDict = [];

                for (int i = 1; i < cmdArgs.Length; i++)
                {
                    mark = cmdArgs[i].IndexOf(':');
                    argName = cmdArgs[i][..mark];
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
        frmLogin loginForm;
        DialogResult result;
        bool retVal = false;

        using (loginForm = new frmLogin(firstLogin))
        {
            if (!loginForm.Unload)
            {
                result = loginForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    retVal = true;
                }
            }
        }

        return retVal;
    }

    public static User LoadLoginInfo()
    {
        var auth = !string.IsNullOrEmpty(AppConfig.Authentication) ? Enum.Parse<User.AuthenticationType>(AppConfig.Authentication) : User.AuthenticationType.Windows;

        User user = new()
        {
            UserID = AppConfig.UserID,
            Server = AppConfig.Server,
            Authentication = auth
        };

        return user;
    }

    public static void SaveLoginInfo(User user)
    {
        CurrentUser.Server = user.Server;

        if (user.Authentication == User.AuthenticationType.Windows)
        {
            CurrentUser.Authentication = User.AuthenticationType.Windows;
            CurrentUser.UserID = Environment.UserName;
            CurrentUser.Password = "";
            AppConfig.Authentication = User.AuthenticationType.Windows.ToString();
        }
        else
        {
            CurrentUser.Authentication = User.AuthenticationType.SQL;
            CurrentUser.UserID = user.UserID;
            CurrentUser.Password = user.Password;
            AppConfig.Authentication = User.AuthenticationType.SQL.ToString();
        }

        AppConfig.UserID = Program.CurrentUser.UserID;
        AppConfig.Server = Program.CurrentUser.Server;

        Utility.SaveAppConfig();
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

    public static string AppConfigFilePath { get; set; }

    public static Server CurrentServer { get; set; }

    public static User CurrentUser { get; set; }

    public static string CurrentJobFile { get; set; }

    public static AppConfiguration AppConfig { get; set; }

    public static bool SilentExecution { get; set; }
    #endregion
}