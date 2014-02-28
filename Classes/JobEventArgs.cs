using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBTools
{
    internal class JobEventArgs : EventArgs
    {
        public enum StatusAction
        {
            MessageOnly,
            MessageAndClearProgress,
            ClearProgress,
            SetProgressMax,
            IncrementProgress
        }

        public StatusAction Action { get; set; }
        public Job.JobTypes JobType { get; set; }
        public int Percent { get; set; }
        public string Message { get; set; }
        public int Maximum { get; set; }
    }
}
