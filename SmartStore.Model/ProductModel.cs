using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore.Model
{
   public class ProductModel
    {
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Cost { get; set; }
        public bool isFeatured { get; set; }
        public int ThumbnailPictureID { get; set; }
        public string SKU { get; set; }
        public string Tags { get; set; }
        public string Barcode { get; set; }
        public string Supplier { get; set; }
       
    }
}
