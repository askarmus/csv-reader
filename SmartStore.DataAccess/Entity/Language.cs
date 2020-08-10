namespace SmartStore.DataAccess.Entity
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public bool IsEnabled { get; set; }
        public string ResourceFileName { get; set; }
        public bool IsRTL { get; set; }
        public bool IsDefault { get; set; }

        public string IconCode { get; set; }
    }
}
