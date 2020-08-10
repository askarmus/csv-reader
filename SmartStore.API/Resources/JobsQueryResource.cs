using System;
using System.Collections.Generic;
using System.Text;
using SmartStore.DataAccess;

namespace SmartStore.API.Resources
{
    public class JobsQueryResource : QueryResource
    {
        public int SiteId { get; set; } = 8;
        public int StaffId { get; set; } = 1141;
        public JobStatus Status { get; set; } = JobStatus.Open;
        public string Type { get; set; }
    }
}
