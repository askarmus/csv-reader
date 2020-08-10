using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStore.API.Resources
{
    public class FormResultsResource
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string FieldValue { get; set; }
    }
}
