using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;

namespace DBTools
{
    internal static class ServerUtility
    {
        public static bool ConnectToServer(User user)
        {
            bool retVal = false;

            if (Program.CurrentServer.ConnectionContext.IsOpen)
            {
                Program.CurrentServer.ConnectionContext.Disconnect();
                Program.CurrentServer = new Server();
            }

            Program.CurrentServer.ConnectionContext.NonPooledConnection = true;
            Program.CurrentServer.ConnectionContext.ServerInstance = user.Server;

            if (user.Authentication == User.AuthenticationType.Windows)
            {
                Program.CurrentServer.ConnectionContext.LoginSecure = true;
            }
            else
            {
                Program.CurrentServer.ConnectionContext.LoginSecure = false;
                Program.CurrentServer.ConnectionContext.Login = user.UserID;
                Program.CurrentServer.ConnectionContext.Password = user.Password;
            }

            try
            {
                Program.CurrentServer.ConnectionContext.Connect();
                retVal = true;
            }
            catch (Exception ex)
            {
                string msg;

                if (ex.InnerException == null)
                {
                    msg = ex.Message;
                }
                else
                {
                    msg = ex.InnerException.Message;
                }

                Utility.ShowError(msg);
            }

            return retVal;
        }

        public static void RefreshServerConnection()
        {
            if (Program.CurrentServer.ConnectionContext.IsOpen)
            {
                Program.CurrentServer.ConnectionContext.Disconnect();
                Program.CurrentServer.ConnectionContext.Connect();
            }
        }

        public static List<string> GetServerAliases()
        {
            List<string> aliases = new List<string>();
            ManagedComputer localComputer;

            localComputer = new ManagedComputer(System.Environment.MachineName);

            if (localComputer.ServerAliases != null)
            {
                try
                {
                    foreach (ServerAlias alias in localComputer.ServerAliases)
                    {
                        aliases.Add(alias.Name);
                    }
                }
                catch
                {
                }
            }

            return aliases;
        }

        public static void InitDatabaseList(ComboBox cb)
        {
            Program.CurrentServer.Databases.Refresh();

            if (cb.Items.Count == 0)
            {
                foreach (Database db in Program.CurrentServer.Databases)
                {
                    cb.Items.Add(db.Name);
                }
            }
            else
            {
                if (cb.Items.Count != Program.CurrentServer.Databases.Count)
                {
                    cb.Items.Clear();

                    foreach (Database db in Program.CurrentServer.Databases)
                    {
                        cb.Items.Add(db.Name);
                    }
                }
            }
        }
    }
}
