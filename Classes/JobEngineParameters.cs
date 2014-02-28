using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace DBTools
{
    internal class JobEngineParameters
    {
        private List<Job> m_jobs;
        private Server m_server;
        private User m_user;

        public JobEngineParameters(List<Job> jobs, Server server, User user)
        {
            this.m_jobs = jobs;
            this.m_server = server;
            this.m_user = user;
        }

        public List<Job> JobList
        {
            get
            {
                return this.m_jobs;
            }
        }

        public Server CurrentServer
        {
            get
            {
                return this.m_server;
            }
        }

        public User CurrentUser
        {
            get
            {
                return this.m_user;
            }
        }
    }
}
