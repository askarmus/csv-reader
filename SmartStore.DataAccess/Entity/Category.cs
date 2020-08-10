using System.Collections.Generic;

namespace SmartStore.DataAccess.Entity
{
    public class Category : BaseEntity
    {
        public int? ParentCategoryID { get; set; }
        public  Category ParentCategory { get; set; }
        public bool isFeatured { get; set; }
        public string SanitizedName { get; set; }
        public int DisplaySeqNo { get; set; }
        public int? PictureID { get; set; }
        public  Picture Picture { get; set; }
        public  List<Product> Products { get; set; }
        public  List<CategoryRecord> CategoryRecords { get; set; }
    }

    public class CategoryRecord : BaseEntity
    {
        public int CategoryID { get; set; }
        public  Category Category { get; set; }
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
