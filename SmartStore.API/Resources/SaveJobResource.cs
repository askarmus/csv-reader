using System;
using System.Collections.Generic;
using System.Text;
using SmartStore.DataAccess;

namespace SmartStore.API.Resources
{
    public class SaveJobResource
    {
        public int JobId { get; set; }
        public int JobPortalId { get; set; }
        public int PlantId { get; set; }
        public string JobNumber { get; set; }
        public string JobServiceType { get; set; }
        public string JobStatus { get; set; }
        public DateTime? JobDate { get; set; }
        public string JobTime { get; set; }
    }
}
