using System;

namespace SmartStore.DataAccess.Entity
{
    public class Comment : BaseEntity
    {
        public DateTime TimeStamp { get; set; }

        public string UserID { get; set; }
       // public  eCommerceUser User { get; set; }

        public int Rating { get; set; }
        public string Text { get; set; }
        
        public int EntityID { get; set; }
        public int RecordID { get; set; }

        public int LanguageID { get; set; }
    }
}
