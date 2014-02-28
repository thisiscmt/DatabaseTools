using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBTools
{
    public abstract class JobForm : System.Windows.Forms.Form
    {
        public enum JobFormActions
        {
            Add,
            Edit
        }

        public JobForm()
        {
            this.Unload = false;
        }

        public JobFormActions Action { get; set; }
        public bool Unload { get; set; }
    }
}
