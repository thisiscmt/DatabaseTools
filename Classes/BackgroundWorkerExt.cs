using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DBTools
{
    /// <summary>
    /// Provides the functionality of the BackgroundWorker class with additional features.
    /// </summary>
    class BackgroundWorkerExt: BackgroundWorker
    {
        private Object m_lock = new Object();
        private bool m_paused;

        public BackgroundWorkerExt()
        {
            base.WorkerReportsProgress = true;
            base.WorkerSupportsCancellation = true;
            this.m_paused = false;
        }

        public void PauseWork()
        {
            lock(this.m_lock)
            {
                this.m_paused = true;
            }
        }

        public void ResumeWork()
        {
            lock (this.m_lock)
            {
                this.m_paused = false;
            }
        }

        public bool Paused
        {
            get
            {
                lock (this.m_lock)
                {
                    return this.m_paused;
                }
            }
        }
    }
}
