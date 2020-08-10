using System.Collections.Generic;

namespace SmartStore.API.Resources
{
    public class DynamicFormResource
    {
        public int DynamicFieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldDesc { get; set; }
        public string FieldType { get; set; }
        public IEnumerable<FormResultsResource> FormValues { get; set; }
    }
}
