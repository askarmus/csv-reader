using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore.Model
{
   public class ProductRecordModel
    {
        public int ProductID { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
