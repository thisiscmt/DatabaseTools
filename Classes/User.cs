using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace DBTools
{
    /// <summary>
    /// Stores data for the current user.
    /// </summary>
    internal class User
    {
        public enum AuthenticationType
        {
            Windows = 0,
            SQL = 1
        }

        public User()
        {
        }

        public string UserID { get; set; }

        public string Password { get; set; }

        public AuthenticationType Authentication { get; set; }

        public string Server { get; set; }
    }
}
