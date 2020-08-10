using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartStore.DataAccess;

namespace SmartStore.API.Resources
{
    public class SaveFormResource
    {
        public int StaffId { get; set; }
        public int PlantId { get; set; }
        public int? MeterReading { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string PreStartFilename { get; set; }
        public int FormType { get; set; }
    }
}
