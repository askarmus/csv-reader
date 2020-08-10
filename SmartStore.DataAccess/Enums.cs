using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartStore.DataAccess
{
    public enum JobStatus
    {
        New,
        Open,
        Finished,
        Closed
    }

    public enum FormTypes
    {
        PreStart,
        Inspection
    }
}
