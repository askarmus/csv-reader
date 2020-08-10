using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStore.API.Resources
{
    public class TaskResource
    {
        public int MaintenanceTimesheetID { get; set; }
        public int MTPortalId { get; set; }
        public int? JobId { get; set; }
        public int? TaskTypeId { get; set; }
        public int? TaskSubTypeId { get; set; }
        public int? StaffId { get; set; }
        public string MTDesc { get; set; }
        public string JobNo { get; set; }
        public decimal? MTHrs { get; set; }
        public DateTime? MaintenanceDate { get; set; }
        public string JobStatus { get; set; }
        public string JobServiceType { get; set; }
    }
}
