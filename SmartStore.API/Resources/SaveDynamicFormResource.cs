using System.Collections.Generic;

namespace SmartStore.API.Resources
{
    public class SaveDynamicFormResource
    {
        //public int DynamicFieldId { get; set; }
        //public string FieldType { get; set; }
        //public FormResultsResource FormValues { get; set; }
        public int Id { get; set; }
        public int JobId { get; set; }
        public int DynamicFieldId { get; set; }
        public string FieldValue { get; set; }
    }
}
