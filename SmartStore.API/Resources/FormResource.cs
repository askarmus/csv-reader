using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStore.API.Resources
{
    public class FormResource
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int PlantId { get; set; }
        public int? MeterReading { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}
