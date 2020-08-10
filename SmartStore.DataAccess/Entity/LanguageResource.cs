namespace SmartStore.DataAccess.Entity
{
    public class LanguageResource : BaseEntity
    {
        public string Key { get; set; }
        public int LanguageID { get; set; }
        public string Value { get; set; }
    }
}
